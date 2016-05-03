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

        public GimbalController()
        {
            InitializeComponent();
            // if we need to validate again:
            // http://stackoverflow.com/questions/463299/how-do-i-make-a-textbox-that-only-accepts-numbers
            FormClosing += GimbalController_FormClosing;
        }

        private void GimbalController_Load(object sender, EventArgs e)
        {
            RefreshCommPorts();
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

        private void AddToOutput(string line, bool fromGimbal = false)
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
        private void AddToOutput(string format, params object[] args)
        {
            AddToOutput(String.Format(format, args));
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
                double pitch = (double)nudRawPitch.Value;
                double yaw = (double)nudRawYaw.Value;
                SendAngles(pitch, yaw);
            }
            else if (tabcInputs.SelectedTab == tabAboslute)
            {
                // these tryparses should really never fail because we validate our inputs but just to be
                double acX = (double)nudACX.Value;
                double acY = (double)nudACY.Value;
                double acZ = (double)nudACZ.Value;
                double tX = (double)nudTargetX.Value;
                double tY = (double)nudTargetY.Value;
                double tZ = (double)nudTargetZ.Value;
                SendAbsolute(acX, acY, acZ, tX, tY, tZ);
            }
            else if(tabcInputs.SelectedTab == tabGeo)
            {
                // but just to be sure
                double acLat = (double)nudACLat.Value;
                double acLon = (double)nudACLon.Value;
                double acAlt = (double)nudACAlt.Value;
                double tLat = (double)nudTargetLat.Value;
                double tLon = (double)nudTargetLon.Value;
                double tAlt = (double)nudTargetAlt.Value;
                SendGeo(acLat, acLon, acAlt, tLat, tLon, tAlt);
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
            AddToOutput("Sent Angles: ({0:0.00}, {1:0.00})", pitch, yaw);
            SetAngles(pitch, yaw);
        }

        private void SendAbsolute(double acX, double acY, double acZ, double tX, double tY, double tZ)
        {
            // convert our AC and target coordinate to absolute coordiantes
            double pitch, yaw;
            TrackingMath.TrackToTarget(acX, acY, acZ, tX, tY, tZ, out pitch, out yaw);
            AddToOutput("Convert Abs To Angles: (({0:0.00}, {1:0.00}, {2:0.00}), ({3:0.00}, {4:0.00}, {5:0.00})) -> ({6:0.00}, {7:0.00})",
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
            AddToOutput("Convert Geo AC To Abs: ({0:0.0000}, {1:0.0000}, {2:0.00}) -> ({3:0.00}, {4:0.00}, {5:0.00})",
                acLat, acLon, acAlt,
                acX, acY, acZ);

            // convert our target to ECEF
            double tX, tY, tZ;
            CoordinateSystems.LLAToECEFDeg(tLat, tLon, tAlt, out tX, out tY, out tZ);
            AddToOutput("Convert Geo Target To Abs: ({0:0.0000}, {1:0.0000}, {2:0.00}) -> ({3:0.00}, {4:0.00}, {5:0.00})",
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
                AddToOutput("Closed Serial Port");
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
                AddToOutput("Opened " + _port.PortName);
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
                    AddToOutput(line, true);
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR READING FROM PORT: " + ex);
            }
        }
    }
}
