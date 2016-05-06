using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using GimbalInterface;

namespace GimbalController
{
    public partial class GimbalController : Form
    {
        private const int MaxLineOutput = 100;
        private const int MinLineOutput = 20;
        private const int DefaultBaudRate = 9600;
        private static readonly TimeSpan MinDelay = TimeSpan.FromSeconds(1);// must wait at least X second between clicks

        private SerialPort _port;
        private DateTime _lastSendTime = DateTime.Now;
        private GimbalProtocol _gimbal;

        private double AnglePitch { get { return (double)nudAnglePitch.Value; } }
        private double AngleYaw { get { return (double)nudAngleYaw.Value; } }

        private double ACX { get { return (double)nudACX.Value; } }
        private double ACY { get { return (double)nudACY.Value; } }
        private double ACZ { get { return (double)nudACZ.Value; } }
        private double TargetX { get { return (double)nudTargetX.Value; } }
        private double TargetY { get { return (double)nudTargetY.Value; } }
        private double TargetZ { get { return (double)nudTargetZ.Value; } }

        private double ACLat { get { return (double)nudACLat.Value; } }
        private double ACLon { get { return (double)nudACLon.Value; } }
        private double ACAlt { get { return (double)nudACAlt.Value; } }
        private double TargetLat { get { return (double)nudTargetLat.Value; } }
        private double TargetLon { get { return (double)nudTargetLon.Value; } }
        private double TargetAlt { get { return (double)nudTargetAlt.Value; } }

        private BindingList<TrackerLocation> _trackerLcoations;

        public GimbalController()
        {
            InitializeComponent();
            // if we need to validate again:
            // http://stackoverflow.com/questions/463299/how-do-i-make-a-textbox-that-only-accepts-numbers
            FormClosing += GimbalController_FormClosing;
            // add output update events
            nudAnglePitch.ValueChanged += (s, e) => { UpdateAngleOutputs(); };
            nudAngleYaw.ValueChanged += (s, e) => { UpdateAngleOutputs(); };
            // add absolute update events
            nudACX.ValueChanged += (s, e) => { UpdateAbsoluteOutputs(); };
            nudACY.ValueChanged += (s, e) => { UpdateAbsoluteOutputs(); };
            nudACZ.ValueChanged += (s, e) => { UpdateAbsoluteOutputs(); };
            nudTargetX.ValueChanged += (s, e) => { UpdateAbsoluteOutputs(); };
            nudTargetY.ValueChanged += (s, e) => { UpdateAbsoluteOutputs(); };
            nudTargetZ.ValueChanged += (s, e) => { UpdateAbsoluteOutputs(); };
            // add geo update
            nudACLat.ValueChanged += (s, e) => { UpdateGeoOutputs(); };
            nudACLon.ValueChanged += (s, e) => { UpdateGeoOutputs(); };
            nudACAlt.ValueChanged += (s, e) => { UpdateGeoOutputs(); };
            nudTargetLat.ValueChanged += (s, e) => { UpdateGeoOutputs(); };
            nudTargetLon.ValueChanged += (s, e) => { UpdateGeoOutputs(); };
            nudTargetAlt.ValueChanged += (s, e) => { UpdateGeoOutputs(); };
            // init our tracker dgv
            _trackerLcoations = new BindingList<TrackerLocation>();
            for(int i = 0; i < 5; i++)
            {
                _trackerLcoations.Add(new TrackerLocation
                {
                    Name = "NAME_" + i,
                    Lat = 1.5 * i,
                    Lon = 2.5 * i,
                    Alt = 3.5 * i
                });
            }
        }

        private void UpdateAngleOutputs()
        {
            lblAngleOutputPitchValue.Text = AnglePitch.ToString("0.00");
            lblAngleOutputYawValue.Text = AngleYaw.ToString("0.00");
        }

        private void UpdateAbsoluteOutputs()
        {
            double pitch, yaw;
            TrackingMath.TrackToTarget(ACX, ACY, ACZ, TargetX, TargetY, TargetZ, out pitch, out yaw);
            lblAbsoluteOutputPitchValue.Text = pitch.ToString("0.00");
            lblAbsoluteOutputYawValue.Text = yaw.ToString("0.00");
        }

        private void UpdateGeoOutputs()
        {
            // convert our AC to ECEF
            double acX, acY, acZ;
            CoordinateSystems.LLAToECEFDeg(ACLat, ACLon, ACAlt, out acX, out acY, out acZ);
            lblGeoOutputACXValue.Text = acX.ToString("0.00");
            lblGeoOutputACYValue.Text = acY.ToString("0.00");
            lblGeoOutputACZValue.Text = acZ.ToString("0.00");
            // convert our target to ECEF
            double tX, tY, tZ;
            CoordinateSystems.LLAToECEFDeg(TargetLat, TargetLon, TargetAlt, out tX, out tY, out tZ);
            lblGeoOutputTargetXValue.Text = tX.ToString("0.00");
            lblGeoOutputTargetYValue.Text = tY.ToString("0.00");
            lblGeoOutputTargetZValue.Text = tZ.ToString("0.00");

            // swap the y axis so that north points up
            acY = -acY;
            tY = -tY;

            // now convert to pitch and yaw
            double pitch, yaw;
            TrackingMath.TrackToTarget(acX, acY, acZ, tX, tY, tZ, out pitch, out yaw);
            lblGeoOutputPitchValue.Text = pitch.ToString("0.00");
            lblGeoOutputYawValue.Text = yaw.ToString("0.00");
        }

        private void GimbalController_Load(object sender, EventArgs e)
        {
            RefreshCommPorts();
            UpdateAngleOutputs();
            UpdateAbsoluteOutputs();
            UpdateGeoOutputs();
            // setup our dgv
            dgvTrackerLocations.AutoSize = true;
            dgvTrackerLocations.AllowDrop = true;
            dgvTrackerLocations.DataSource = _trackerLcoations;
            dgvTrackerLocations.MouseMove += dgvTrackerLocations_MouseMove;
            dgvTrackerLocations.MouseDown += dgvTrackerLocations_MouseDown;
            dgvTrackerLocations.DragOver += dgvTrackerLocations_DragOver;
            dgvTrackerLocations.DragDrop += dgvTrackerLocations_DragDrop;

        }

        private void GimbalController_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_port != null)
            {
                _port.Dispose();
            }
        }

        private void btnCommPortRefresh_Click(object sender, EventArgs e)
        {
            RefreshCommPorts();
        }

        private Rectangle _trackerDragHitbox;
        private int _trackerRowIndexFromMouseDown;
        private int _trackerRowIndexOfItemUnderMouseToDrop;

        private void dgvTrackerLocations_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (_trackerDragHitbox != Rectangle.Empty &&
                    !_trackerDragHitbox.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dgvTrackerLocations.DoDragDrop(
                    dgvTrackerLocations.Rows[_trackerRowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void dgvTrackerLocations_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            _trackerRowIndexFromMouseDown = dgvTrackerLocations.HitTest(e.X, e.Y).RowIndex;
            if (_trackerRowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                _trackerDragHitbox = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                _trackerDragHitbox = Rectangle.Empty;
        }

        private void dgvTrackerLocations_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvTrackerLocations_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgvTrackerLocations.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            _trackerRowIndexOfItemUnderMouseToDrop =
                dgvTrackerLocations.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                dgvTrackerLocations.Rows.RemoveAt(_trackerRowIndexFromMouseDown);
                dgvTrackerLocations.Rows.Insert(_trackerRowIndexOfItemUnderMouseToDrop, rowToMove);

            }
        }

        private void RefreshCommPorts()
        {
            cbCommPorts.Items.Clear();// clear any old items
            // fill our combobox with the available ports
            try
            {
                cbCommPorts.Items.Add("None");// always make the first item none so people can disconnect
                string[] ports = SerialPort.GetPortNames();
                foreach (var port in ports)
                {
                    cbCommPorts.Items.Add(port);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UNABLE TO QUREY OPEN PORTS: " + ex);
            }
        }

        private void AddToConsole(string line, bool fromGimbal = false)
        {
            // adapted from: http://stackoverflow.com/questions/252323/how-do-i-add-a-console-like-element-to-a-c-sharp-winforms-program
            lbConsole.Items.Add((fromGimbal ? "[GIMBAL] " : "[CTRL] ") + line);
            if(lbConsole.Items.Count > MaxLineOutput)
            {
                int ammountToRemove = lbConsole.Items.Count - MinLineOutput;
                for(int i = 0; i < ammountToRemove; i++)
                {
                    lbConsole.Items.RemoveAt(0);
                }
            }
            else
            {
                lbConsole.SelectedIndex = lbConsole.Items.Count - 1;
            }
        }
        private void AddToConsole(string format, params object[] args)
        {
            AddToConsole(String.Format(format, args));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // reject any messages that happen too early
            DateTime now = DateTime.Now;
            TimeSpan delta = now - _lastSendTime;
            if (delta < MinDelay)
                return;
            _lastSendTime = now;

            if(tabcInputs.SelectedTab == tabAngles)
            {
                SendAngles( AnglePitch,
                            AngleYaw);
            }
            else if (tabcInputs.SelectedTab == tabAboslute)
            {
                SendAbsolute(ACX, ACY, ACZ, 
                             TargetX, TargetY, TargetZ);
            }
            else if(tabcInputs.SelectedTab == tabGeo)
            {
                SendGeo(ACLat, ACLon, ACAlt,
                        TargetLat, TargetLon, TargetAlt);
            }
            // TODO maybe error this should never happen though
        }

        internal static double Clamp(double val, double min, double max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }

        private static void ValidatePY(ref double pitch, ref double yaw)
        {
            pitch = Clamp(pitch, -90.0, 90.0);
            yaw = Clamp(yaw, 0.0, 360.0);
        }

        private void SetAngles(double pitch, double yaw)
        {
            try
            {
                // all our math is done with doubles but the gimbal will
                // evenutally need to work with floats
                _gimbal.SetAngles((float)pitch, (float)yaw);
                return;
            }
            catch (IOException e)
            {
                Console.WriteLine("FAILED TO SEND: " + e);
                Error("Failed to send: port disconnected");
            }
            catch (Exception e)
            {
                Console.WriteLine("UNKNOWN ERROR: " + e);
                Error("Failed to send: unknown error");
            }
            // we failed so disconnect
            ClosePort();
            RefreshCommPorts();
        }

        private void SendAngles(double pitch, double yaw)
        {
            // should already be validated but just to be sure
            ValidatePY(ref pitch, ref yaw);
            AddToConsole("Sent Angles: ({0:0.00}, {1:0.00})", pitch, yaw);
            SetAngles(pitch, yaw);
        }

        private void SendAbsolute(double acX, double acY, double acZ, double tX, double tY, double tZ)
        {
            // convert our AC and target coordinate to absolute coordiantes
            double pitch, yaw;
            TrackingMath.TrackToTarget(acX, acY, acZ, tX, tY, tZ, out pitch, out yaw);
            AddToConsole("Convert Abs To Angles: (({0:0.00}, {1:0.00}, {2:0.00}), ({3:0.00}, {4:0.00}, {5:0.00})) -> ({6:0.00}, {7:0.00})",
                acX, acY, acZ,
                tX, tY, tZ,
                pitch, yaw);
            SendAngles(pitch, yaw);
        }

        private static void ValidateLLA(ref double lat, ref double lon, ref double alt)
        {
            lat = Clamp(lat, -90.0, 90.0);
            lon = Clamp(lon, -180.0, 180.0);
            // no upper limit on alt for now
            if (alt < 0.0)
                alt = 0.0;
        }

        private void SendGeo(double acLat, double acLon, double acAlt, double tLat, double tLon, double tAlt)
        {
            // should already be validated but just to be sure
            ValidateLLA(ref acLat, ref acLon, ref acAlt);
            ValidateLLA(ref tLat, ref tLon, ref tAlt);

            // convert our AC to ECEF
            double acX, acY, acZ;
            CoordinateSystems.LLAToECEFDeg(acLat, acLon, acAlt, out acX, out acY, out acZ);
            AddToConsole("Convert Geo AC To Abs: ({0:0.0000}, {1:0.0000}, {2:0.00}) -> ({3:0.00}, {4:0.00}, {5:0.00})",
                acLat, acLon, acAlt,
                acX, acY, acZ);

            // convert our target to ECEF
            double tX, tY, tZ;
            CoordinateSystems.LLAToECEFDeg(tLat, tLon, tAlt, out tX, out tY, out tZ);
            AddToConsole("Convert Geo Target To Abs: ({0:0.0000}, {1:0.0000}, {2:0.00}) -> ({3:0.00}, {4:0.00}, {5:0.00})",
                tLat, tLon, tAlt,
                tX, tY, tZ);

            // flip our y axis so that north points in the direction of our gimbal
            acY = -acY;
            tY = -tY;

            // send the cooridnates to relative
            SendAbsolute(acX, acY, acZ, tX, tY, tZ);
        }

        private void ClosePort()
        {
            if (_port != null)
            {
                // its much cleaner and safer to dispose and create a new serial port
                AddToConsole("Closed Serial Port");
                try
                {
                    _port.Dispose();
                }
                catch(IOException e)
                {
                    Console.WriteLine("PORT WAS REMOVED PRIOR TO CLOSING: " + e);
                }
                _port = null;
            }
            btnSend.Enabled = false;
        }

        private void RecreatePort(string portName)
        {
            _port = new SerialPort()
            {
                BaudRate = DefaultBaudRate,
                PortName = portName
            };
            _port.DataReceived += Port_DataReceived;// add the proper data recieved event
        }

        private void OpenPort()
        {
            // this should never happen but just to be safe
            if (_port == null)
                return;
            try
            {
                // try to open our port
                _port.Open();
                _gimbal = new GimbalProtocol(_port.BaseStream);
                AddToConsole("Opened " + _port.PortName);
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("PORT OPEN ERROR: " + ex);
                Error("Failed to open " + _port.PortName);
                _port.Dispose();
                _port = null;
            }
        }

        private void cbCommPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            // always close our old port
            ClosePort();
            if(cb.SelectedIndex == 0)
            {
                // ignore opening the port if we have the first item 
                // selected which is always the none port
                return;
            }
            var portName = cb.SelectedItem.ToString();
            RecreatePort(portName);
            OpenPort();
        }
        
        private void Error(string msg)
        {
            Invoke(new Action(() => { MessageBox.Show(this, msg); }));
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var port = sender as SerialPort;
            try
            {
                string line = port.ReadLine();
                Invoke(new Action(() =>
                {
                    AddToConsole(line, true);
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR READING FROM PORT: " + ex);
            }
        }

        private void btnLauchTracker_Click(object sender, EventArgs e)
        {

        }
    }
}
