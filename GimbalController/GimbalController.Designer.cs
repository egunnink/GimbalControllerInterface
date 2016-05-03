namespace GimbalController
{
    partial class GimbalController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabcInputs = new System.Windows.Forms.TabControl();
            this.tabAngles = new System.Windows.Forms.TabPage();
            this.lblAngleInputYaw = new System.Windows.Forms.Label();
            this.nudRawYaw = new System.Windows.Forms.NumericUpDown();
            this.lblAngleInputPitch = new System.Windows.Forms.Label();
            this.nudRawPitch = new System.Windows.Forms.NumericUpDown();
            this.tabGeo = new System.Windows.Forms.TabPage();
            this.lblTargetAltUnits = new System.Windows.Forms.Label();
            this.lblTargetAlt = new System.Windows.Forms.Label();
            this.lblTargetLonUnit = new System.Windows.Forms.Label();
            this.lblTargetLon = new System.Windows.Forms.Label();
            this.lblTargetLatUnits = new System.Windows.Forms.Label();
            this.lblTargetLat = new System.Windows.Forms.Label();
            this.lblTargetGeo = new System.Windows.Forms.Label();
            this.lblACAltUnits = new System.Windows.Forms.Label();
            this.lblACAlt = new System.Windows.Forms.Label();
            this.lblACLonUnit = new System.Windows.Forms.Label();
            this.lblACLon = new System.Windows.Forms.Label();
            this.lblACLatUnits = new System.Windows.Forms.Label();
            this.lblACLat = new System.Windows.Forms.Label();
            this.lblACGeo = new System.Windows.Forms.Label();
            this.tabAboslute = new System.Windows.Forms.TabPage();
            this.lblTargetZ = new System.Windows.Forms.Label();
            this.lblTargetY = new System.Windows.Forms.Label();
            this.lblTargetX = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblACZ = new System.Windows.Forms.Label();
            this.lblACY = new System.Windows.Forms.Label();
            this.lblACX = new System.Windows.Forms.Label();
            this.lblACRel = new System.Windows.Forms.Label();
            this.lbConsole = new System.Windows.Forms.ListBox();
            this.lblConsole = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.nudACLat = new System.Windows.Forms.NumericUpDown();
            this.nudACLon = new System.Windows.Forms.NumericUpDown();
            this.nudACAlt = new System.Windows.Forms.NumericUpDown();
            this.nudTargetAlt = new System.Windows.Forms.NumericUpDown();
            this.nudTargetLon = new System.Windows.Forms.NumericUpDown();
            this.nudTargetLat = new System.Windows.Forms.NumericUpDown();
            this.cbCommPorts = new System.Windows.Forms.ComboBox();
            this.lblCommPorts = new System.Windows.Forms.Label();
            this.btnCommPortRefresh = new System.Windows.Forms.Button();
            this.nudACZ = new System.Windows.Forms.NumericUpDown();
            this.nudACY = new System.Windows.Forms.NumericUpDown();
            this.nudACX = new System.Windows.Forms.NumericUpDown();
            this.nudTargetZ = new System.Windows.Forms.NumericUpDown();
            this.nudTargetY = new System.Windows.Forms.NumericUpDown();
            this.nudTargetX = new System.Windows.Forms.NumericUpDown();
            this.gbAngleInputs = new System.Windows.Forms.GroupBox();
            this.gbAngleOutputs = new System.Windows.Forms.GroupBox();
            this.lblAngleYawUnits = new System.Windows.Forms.Label();
            this.lblAnglePitchUnits = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAngleOutputPitch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAngleOuptut = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabcInputs.SuspendLayout();
            this.tabAngles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRawYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRawPitch)).BeginInit();
            this.tabGeo.SuspendLayout();
            this.tabAboslute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudACLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACLon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetLon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetX)).BeginInit();
            this.gbAngleInputs.SuspendLayout();
            this.gbAngleOutputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabcInputs
            // 
            this.tabcInputs.Controls.Add(this.tabAngles);
            this.tabcInputs.Controls.Add(this.tabAboslute);
            this.tabcInputs.Controls.Add(this.tabGeo);
            this.tabcInputs.Location = new System.Drawing.Point(12, 12);
            this.tabcInputs.Name = "tabcInputs";
            this.tabcInputs.SelectedIndex = 0;
            this.tabcInputs.Size = new System.Drawing.Size(221, 272);
            this.tabcInputs.TabIndex = 0;
            // 
            // tabAngles
            // 
            this.tabAngles.Controls.Add(this.gbAngleOutputs);
            this.tabAngles.Controls.Add(this.gbAngleInputs);
            this.tabAngles.Location = new System.Drawing.Point(4, 22);
            this.tabAngles.Name = "tabAngles";
            this.tabAngles.Padding = new System.Windows.Forms.Padding(3);
            this.tabAngles.Size = new System.Drawing.Size(213, 246);
            this.tabAngles.TabIndex = 0;
            this.tabAngles.Text = "Angles";
            this.tabAngles.UseVisualStyleBackColor = true;
            // 
            // lblAngleInputYaw
            // 
            this.lblAngleInputYaw.AutoSize = true;
            this.lblAngleInputYaw.Location = new System.Drawing.Point(6, 42);
            this.lblAngleInputYaw.Name = "lblAngleInputYaw";
            this.lblAngleInputYaw.Size = new System.Drawing.Size(28, 13);
            this.lblAngleInputYaw.TabIndex = 3;
            this.lblAngleInputYaw.Text = "Yaw";
            // 
            // nudRawYaw
            // 
            this.nudRawYaw.Location = new System.Drawing.Point(47, 40);
            this.nudRawYaw.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudRawYaw.Name = "nudRawYaw";
            this.nudRawYaw.Size = new System.Drawing.Size(54, 20);
            this.nudRawYaw.TabIndex = 2;
            // 
            // lblAngleInputPitch
            // 
            this.lblAngleInputPitch.AutoSize = true;
            this.lblAngleInputPitch.Location = new System.Drawing.Point(6, 16);
            this.lblAngleInputPitch.Name = "lblAngleInputPitch";
            this.lblAngleInputPitch.Size = new System.Drawing.Size(31, 13);
            this.lblAngleInputPitch.TabIndex = 1;
            this.lblAngleInputPitch.Text = "Pitch";
            // 
            // nudRawPitch
            // 
            this.nudRawPitch.Location = new System.Drawing.Point(47, 14);
            this.nudRawPitch.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudRawPitch.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nudRawPitch.Name = "nudRawPitch";
            this.nudRawPitch.Size = new System.Drawing.Size(54, 20);
            this.nudRawPitch.TabIndex = 0;
            // 
            // tabGeo
            // 
            this.tabGeo.Controls.Add(this.nudTargetAlt);
            this.tabGeo.Controls.Add(this.nudTargetLon);
            this.tabGeo.Controls.Add(this.nudTargetLat);
            this.tabGeo.Controls.Add(this.nudACAlt);
            this.tabGeo.Controls.Add(this.nudACLon);
            this.tabGeo.Controls.Add(this.nudACLat);
            this.tabGeo.Controls.Add(this.lblTargetAltUnits);
            this.tabGeo.Controls.Add(this.lblTargetAlt);
            this.tabGeo.Controls.Add(this.lblTargetLonUnit);
            this.tabGeo.Controls.Add(this.lblTargetLon);
            this.tabGeo.Controls.Add(this.lblTargetLatUnits);
            this.tabGeo.Controls.Add(this.lblTargetLat);
            this.tabGeo.Controls.Add(this.lblTargetGeo);
            this.tabGeo.Controls.Add(this.lblACAltUnits);
            this.tabGeo.Controls.Add(this.lblACAlt);
            this.tabGeo.Controls.Add(this.lblACLonUnit);
            this.tabGeo.Controls.Add(this.lblACLon);
            this.tabGeo.Controls.Add(this.lblACLatUnits);
            this.tabGeo.Controls.Add(this.lblACLat);
            this.tabGeo.Controls.Add(this.lblACGeo);
            this.tabGeo.Location = new System.Drawing.Point(4, 22);
            this.tabGeo.Name = "tabGeo";
            this.tabGeo.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeo.Size = new System.Drawing.Size(213, 246);
            this.tabGeo.TabIndex = 1;
            this.tabGeo.Text = "Geo";
            this.tabGeo.UseVisualStyleBackColor = true;
            // 
            // lblTargetAltUnits
            // 
            this.lblTargetAltUnits.AutoSize = true;
            this.lblTargetAltUnits.Location = new System.Drawing.Point(134, 187);
            this.lblTargetAltUnits.Name = "lblTargetAltUnits";
            this.lblTargetAltUnits.Size = new System.Drawing.Size(15, 13);
            this.lblTargetAltUnits.TabIndex = 19;
            this.lblTargetAltUnits.Text = "m";
            // 
            // lblTargetAlt
            // 
            this.lblTargetAlt.AutoSize = true;
            this.lblTargetAlt.Location = new System.Drawing.Point(6, 187);
            this.lblTargetAlt.Name = "lblTargetAlt";
            this.lblTargetAlt.Size = new System.Drawing.Size(19, 13);
            this.lblTargetAlt.TabIndex = 18;
            this.lblTargetAlt.Text = "Alt";
            // 
            // lblTargetLonUnit
            // 
            this.lblTargetLonUnit.AutoSize = true;
            this.lblTargetLonUnit.Location = new System.Drawing.Point(134, 161);
            this.lblTargetLonUnit.Name = "lblTargetLonUnit";
            this.lblTargetLonUnit.Size = new System.Drawing.Size(25, 13);
            this.lblTargetLonUnit.TabIndex = 16;
            this.lblTargetLonUnit.Text = "deg";
            // 
            // lblTargetLon
            // 
            this.lblTargetLon.AutoSize = true;
            this.lblTargetLon.Location = new System.Drawing.Point(6, 161);
            this.lblTargetLon.Name = "lblTargetLon";
            this.lblTargetLon.Size = new System.Drawing.Size(25, 13);
            this.lblTargetLon.TabIndex = 15;
            this.lblTargetLon.Text = "Lon";
            // 
            // lblTargetLatUnits
            // 
            this.lblTargetLatUnits.AutoSize = true;
            this.lblTargetLatUnits.Location = new System.Drawing.Point(134, 135);
            this.lblTargetLatUnits.Name = "lblTargetLatUnits";
            this.lblTargetLatUnits.Size = new System.Drawing.Size(25, 13);
            this.lblTargetLatUnits.TabIndex = 13;
            this.lblTargetLatUnits.Text = "deg";
            // 
            // lblTargetLat
            // 
            this.lblTargetLat.AutoSize = true;
            this.lblTargetLat.Location = new System.Drawing.Point(6, 135);
            this.lblTargetLat.Name = "lblTargetLat";
            this.lblTargetLat.Size = new System.Drawing.Size(22, 13);
            this.lblTargetLat.TabIndex = 12;
            this.lblTargetLat.Text = "Lat";
            // 
            // lblTargetGeo
            // 
            this.lblTargetGeo.AutoSize = true;
            this.lblTargetGeo.Location = new System.Drawing.Point(6, 110);
            this.lblTargetGeo.Name = "lblTargetGeo";
            this.lblTargetGeo.Size = new System.Drawing.Size(82, 13);
            this.lblTargetGeo.TabIndex = 11;
            this.lblTargetGeo.Text = "Target Location";
            // 
            // lblACAltUnits
            // 
            this.lblACAltUnits.AutoSize = true;
            this.lblACAltUnits.Location = new System.Drawing.Point(134, 80);
            this.lblACAltUnits.Name = "lblACAltUnits";
            this.lblACAltUnits.Size = new System.Drawing.Size(15, 13);
            this.lblACAltUnits.TabIndex = 9;
            this.lblACAltUnits.Text = "m";
            // 
            // lblACAlt
            // 
            this.lblACAlt.AutoSize = true;
            this.lblACAlt.Location = new System.Drawing.Point(6, 80);
            this.lblACAlt.Name = "lblACAlt";
            this.lblACAlt.Size = new System.Drawing.Size(19, 13);
            this.lblACAlt.TabIndex = 8;
            this.lblACAlt.Text = "Alt";
            // 
            // lblACLonUnit
            // 
            this.lblACLonUnit.AutoSize = true;
            this.lblACLonUnit.Location = new System.Drawing.Point(134, 54);
            this.lblACLonUnit.Name = "lblACLonUnit";
            this.lblACLonUnit.Size = new System.Drawing.Size(25, 13);
            this.lblACLonUnit.TabIndex = 6;
            this.lblACLonUnit.Text = "deg";
            // 
            // lblACLon
            // 
            this.lblACLon.AutoSize = true;
            this.lblACLon.Location = new System.Drawing.Point(6, 54);
            this.lblACLon.Name = "lblACLon";
            this.lblACLon.Size = new System.Drawing.Size(25, 13);
            this.lblACLon.TabIndex = 5;
            this.lblACLon.Text = "Lon";
            // 
            // lblACLatUnits
            // 
            this.lblACLatUnits.AutoSize = true;
            this.lblACLatUnits.Location = new System.Drawing.Point(134, 28);
            this.lblACLatUnits.Name = "lblACLatUnits";
            this.lblACLatUnits.Size = new System.Drawing.Size(25, 13);
            this.lblACLatUnits.TabIndex = 3;
            this.lblACLatUnits.Text = "deg";
            // 
            // lblACLat
            // 
            this.lblACLat.AutoSize = true;
            this.lblACLat.Location = new System.Drawing.Point(6, 28);
            this.lblACLat.Name = "lblACLat";
            this.lblACLat.Size = new System.Drawing.Size(22, 13);
            this.lblACLat.TabIndex = 2;
            this.lblACLat.Text = "Lat";
            // 
            // lblACGeo
            // 
            this.lblACGeo.AutoSize = true;
            this.lblACGeo.Location = new System.Drawing.Point(6, 3);
            this.lblACGeo.Name = "lblACGeo";
            this.lblACGeo.Size = new System.Drawing.Size(84, 13);
            this.lblACGeo.TabIndex = 1;
            this.lblACGeo.Text = "Aircraft Location";
            // 
            // tabAboslute
            // 
            this.tabAboslute.Controls.Add(this.nudTargetZ);
            this.tabAboslute.Controls.Add(this.nudTargetY);
            this.tabAboslute.Controls.Add(this.nudTargetX);
            this.tabAboslute.Controls.Add(this.nudACZ);
            this.tabAboslute.Controls.Add(this.lblTargetZ);
            this.tabAboslute.Controls.Add(this.nudACY);
            this.tabAboslute.Controls.Add(this.lblTargetY);
            this.tabAboslute.Controls.Add(this.nudACX);
            this.tabAboslute.Controls.Add(this.lblTargetX);
            this.tabAboslute.Controls.Add(this.label7);
            this.tabAboslute.Controls.Add(this.lblACZ);
            this.tabAboslute.Controls.Add(this.lblACY);
            this.tabAboslute.Controls.Add(this.lblACX);
            this.tabAboslute.Controls.Add(this.lblACRel);
            this.tabAboslute.Location = new System.Drawing.Point(4, 22);
            this.tabAboslute.Name = "tabAboslute";
            this.tabAboslute.Padding = new System.Windows.Forms.Padding(3);
            this.tabAboslute.Size = new System.Drawing.Size(213, 246);
            this.tabAboslute.TabIndex = 2;
            this.tabAboslute.Text = "Aboslute";
            this.tabAboslute.UseVisualStyleBackColor = true;
            // 
            // lblTargetZ
            // 
            this.lblTargetZ.AutoSize = true;
            this.lblTargetZ.Location = new System.Drawing.Point(6, 187);
            this.lblTargetZ.Name = "lblTargetZ";
            this.lblTargetZ.Size = new System.Drawing.Size(14, 13);
            this.lblTargetZ.TabIndex = 38;
            this.lblTargetZ.Text = "Z";
            // 
            // lblTargetY
            // 
            this.lblTargetY.AutoSize = true;
            this.lblTargetY.Location = new System.Drawing.Point(6, 161);
            this.lblTargetY.Name = "lblTargetY";
            this.lblTargetY.Size = new System.Drawing.Size(14, 13);
            this.lblTargetY.TabIndex = 35;
            this.lblTargetY.Text = "Y";
            // 
            // lblTargetX
            // 
            this.lblTargetX.AutoSize = true;
            this.lblTargetX.Location = new System.Drawing.Point(6, 135);
            this.lblTargetX.Name = "lblTargetX";
            this.lblTargetX.Size = new System.Drawing.Size(14, 13);
            this.lblTargetX.TabIndex = 32;
            this.lblTargetX.Text = "X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Target Location";
            // 
            // lblACZ
            // 
            this.lblACZ.AutoSize = true;
            this.lblACZ.Location = new System.Drawing.Point(6, 80);
            this.lblACZ.Name = "lblACZ";
            this.lblACZ.Size = new System.Drawing.Size(14, 13);
            this.lblACZ.TabIndex = 28;
            this.lblACZ.Text = "Z";
            // 
            // lblACY
            // 
            this.lblACY.AutoSize = true;
            this.lblACY.Location = new System.Drawing.Point(6, 54);
            this.lblACY.Name = "lblACY";
            this.lblACY.Size = new System.Drawing.Size(14, 13);
            this.lblACY.TabIndex = 25;
            this.lblACY.Text = "Y";
            // 
            // lblACX
            // 
            this.lblACX.AutoSize = true;
            this.lblACX.Location = new System.Drawing.Point(6, 28);
            this.lblACX.Name = "lblACX";
            this.lblACX.Size = new System.Drawing.Size(14, 13);
            this.lblACX.TabIndex = 22;
            this.lblACX.Text = "X";
            // 
            // lblACRel
            // 
            this.lblACRel.AutoSize = true;
            this.lblACRel.Location = new System.Drawing.Point(6, 3);
            this.lblACRel.Name = "lblACRel";
            this.lblACRel.Size = new System.Drawing.Size(84, 13);
            this.lblACRel.TabIndex = 21;
            this.lblACRel.Text = "Aircraft Location";
            // 
            // lbConsole
            // 
            this.lbConsole.FormattingEnabled = true;
            this.lbConsole.Location = new System.Drawing.Point(239, 34);
            this.lbConsole.Name = "lbConsole";
            this.lbConsole.Size = new System.Drawing.Size(345, 251);
            this.lbConsole.TabIndex = 0;
            // 
            // lblConsole
            // 
            this.lblConsole.AutoSize = true;
            this.lblConsole.Location = new System.Drawing.Point(239, 18);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Size = new System.Drawing.Size(45, 13);
            this.lblConsole.TabIndex = 1;
            this.lblConsole.Text = "Console";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(12, 286);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // nudACLat
            // 
            this.nudACLat.DecimalPlaces = 7;
            this.nudACLat.Location = new System.Drawing.Point(34, 26);
            this.nudACLat.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudACLat.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nudACLat.Name = "nudACLat";
            this.nudACLat.Size = new System.Drawing.Size(94, 20);
            this.nudACLat.TabIndex = 20;
            // 
            // nudACLon
            // 
            this.nudACLon.DecimalPlaces = 7;
            this.nudACLon.Location = new System.Drawing.Point(34, 54);
            this.nudACLon.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudACLon.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudACLon.Name = "nudACLon";
            this.nudACLon.Size = new System.Drawing.Size(94, 20);
            this.nudACLon.TabIndex = 21;
            // 
            // nudACAlt
            // 
            this.nudACAlt.DecimalPlaces = 2;
            this.nudACAlt.Location = new System.Drawing.Point(34, 80);
            this.nudACAlt.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudACAlt.Name = "nudACAlt";
            this.nudACAlt.Size = new System.Drawing.Size(94, 20);
            this.nudACAlt.TabIndex = 22;
            // 
            // nudTargetAlt
            // 
            this.nudTargetAlt.DecimalPlaces = 2;
            this.nudTargetAlt.Location = new System.Drawing.Point(34, 187);
            this.nudTargetAlt.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTargetAlt.Name = "nudTargetAlt";
            this.nudTargetAlt.Size = new System.Drawing.Size(94, 20);
            this.nudTargetAlt.TabIndex = 25;
            // 
            // nudTargetLon
            // 
            this.nudTargetLon.DecimalPlaces = 7;
            this.nudTargetLon.Location = new System.Drawing.Point(34, 161);
            this.nudTargetLon.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudTargetLon.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudTargetLon.Name = "nudTargetLon";
            this.nudTargetLon.Size = new System.Drawing.Size(94, 20);
            this.nudTargetLon.TabIndex = 24;
            // 
            // nudTargetLat
            // 
            this.nudTargetLat.DecimalPlaces = 7;
            this.nudTargetLat.Location = new System.Drawing.Point(34, 133);
            this.nudTargetLat.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudTargetLat.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nudTargetLat.Name = "nudTargetLat";
            this.nudTargetLat.Size = new System.Drawing.Size(94, 20);
            this.nudTargetLat.TabIndex = 23;
            // 
            // cbCommPorts
            // 
            this.cbCommPorts.FormattingEnabled = true;
            this.cbCommPorts.Location = new System.Drawing.Point(382, 6);
            this.cbCommPorts.Name = "cbCommPorts";
            this.cbCommPorts.Size = new System.Drawing.Size(121, 21);
            this.cbCommPorts.TabIndex = 4;
            this.cbCommPorts.SelectedIndexChanged += new System.EventHandler(this.cbCommPorts_SelectedIndexChanged);
            // 
            // lblCommPorts
            // 
            this.lblCommPorts.AutoSize = true;
            this.lblCommPorts.Location = new System.Drawing.Point(313, 9);
            this.lblCommPorts.Name = "lblCommPorts";
            this.lblCommPorts.Size = new System.Drawing.Size(63, 13);
            this.lblCommPorts.TabIndex = 5;
            this.lblCommPorts.Text = "Comm Ports";
            // 
            // btnCommPortRefresh
            // 
            this.btnCommPortRefresh.Location = new System.Drawing.Point(509, 6);
            this.btnCommPortRefresh.Name = "btnCommPortRefresh";
            this.btnCommPortRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnCommPortRefresh.TabIndex = 6;
            this.btnCommPortRefresh.Text = "Refresh";
            this.btnCommPortRefresh.UseVisualStyleBackColor = true;
            this.btnCommPortRefresh.Click += new System.EventHandler(this.btnCommPortRefresh_Click);
            // 
            // nudACZ
            // 
            this.nudACZ.DecimalPlaces = 2;
            this.nudACZ.Location = new System.Drawing.Point(34, 75);
            this.nudACZ.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudACZ.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudACZ.Name = "nudACZ";
            this.nudACZ.Size = new System.Drawing.Size(94, 20);
            this.nudACZ.TabIndex = 41;
            // 
            // nudACY
            // 
            this.nudACY.DecimalPlaces = 2;
            this.nudACY.Location = new System.Drawing.Point(34, 49);
            this.nudACY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudACY.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudACY.Name = "nudACY";
            this.nudACY.Size = new System.Drawing.Size(94, 20);
            this.nudACY.TabIndex = 40;
            // 
            // nudACX
            // 
            this.nudACX.DecimalPlaces = 2;
            this.nudACX.Location = new System.Drawing.Point(34, 21);
            this.nudACX.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudACX.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudACX.Name = "nudACX";
            this.nudACX.Size = new System.Drawing.Size(94, 20);
            this.nudACX.TabIndex = 39;
            // 
            // nudTargetZ
            // 
            this.nudTargetZ.DecimalPlaces = 2;
            this.nudTargetZ.Location = new System.Drawing.Point(34, 182);
            this.nudTargetZ.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTargetZ.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudTargetZ.Name = "nudTargetZ";
            this.nudTargetZ.Size = new System.Drawing.Size(94, 20);
            this.nudTargetZ.TabIndex = 44;
            // 
            // nudTargetY
            // 
            this.nudTargetY.DecimalPlaces = 2;
            this.nudTargetY.Location = new System.Drawing.Point(34, 156);
            this.nudTargetY.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTargetY.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudTargetY.Name = "nudTargetY";
            this.nudTargetY.Size = new System.Drawing.Size(94, 20);
            this.nudTargetY.TabIndex = 43;
            // 
            // nudTargetX
            // 
            this.nudTargetX.DecimalPlaces = 2;
            this.nudTargetX.Location = new System.Drawing.Point(34, 128);
            this.nudTargetX.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTargetX.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudTargetX.Name = "nudTargetX";
            this.nudTargetX.Size = new System.Drawing.Size(94, 20);
            this.nudTargetX.TabIndex = 42;
            // 
            // gbAngleInputs
            // 
            this.gbAngleInputs.Controls.Add(this.lblAngleYawUnits);
            this.gbAngleInputs.Controls.Add(this.lblAnglePitchUnits);
            this.gbAngleInputs.Controls.Add(this.lblAngleInputYaw);
            this.gbAngleInputs.Controls.Add(this.lblAngleInputPitch);
            this.gbAngleInputs.Controls.Add(this.nudRawYaw);
            this.gbAngleInputs.Controls.Add(this.nudRawPitch);
            this.gbAngleInputs.Location = new System.Drawing.Point(6, 6);
            this.gbAngleInputs.Name = "gbAngleInputs";
            this.gbAngleInputs.Size = new System.Drawing.Size(201, 100);
            this.gbAngleInputs.TabIndex = 7;
            this.gbAngleInputs.TabStop = false;
            this.gbAngleInputs.Text = "Inputs";
            // 
            // gbAngleOutputs
            // 
            this.gbAngleOutputs.Controls.Add(this.lblAngleOuptut);
            this.gbAngleOutputs.Controls.Add(this.label5);
            this.gbAngleOutputs.Controls.Add(this.label1);
            this.gbAngleOutputs.Controls.Add(this.label2);
            this.gbAngleOutputs.Controls.Add(this.lblAngleOutputPitch);
            this.gbAngleOutputs.Controls.Add(this.label4);
            this.gbAngleOutputs.Location = new System.Drawing.Point(6, 112);
            this.gbAngleOutputs.Name = "gbAngleOutputs";
            this.gbAngleOutputs.Size = new System.Drawing.Size(201, 128);
            this.gbAngleOutputs.TabIndex = 8;
            this.gbAngleOutputs.TabStop = false;
            this.gbAngleOutputs.Text = "Outputs";
            // 
            // lblAngleYawUnits
            // 
            this.lblAngleYawUnits.AutoSize = true;
            this.lblAngleYawUnits.Location = new System.Drawing.Point(107, 42);
            this.lblAngleYawUnits.Name = "lblAngleYawUnits";
            this.lblAngleYawUnits.Size = new System.Drawing.Size(25, 13);
            this.lblAngleYawUnits.TabIndex = 5;
            this.lblAngleYawUnits.Text = "deg";
            // 
            // lblAnglePitchUnits
            // 
            this.lblAnglePitchUnits.AutoSize = true;
            this.lblAnglePitchUnits.Location = new System.Drawing.Point(107, 16);
            this.lblAnglePitchUnits.Name = "lblAnglePitchUnits";
            this.lblAnglePitchUnits.Size = new System.Drawing.Size(25, 13);
            this.lblAnglePitchUnits.TabIndex = 4;
            this.lblAnglePitchUnits.Text = "deg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Yaw";
            // 
            // lblAngleOutputPitch
            // 
            this.lblAngleOutputPitch.AutoSize = true;
            this.lblAngleOutputPitch.Location = new System.Drawing.Point(6, 16);
            this.lblAngleOutputPitch.Name = "lblAngleOutputPitch";
            this.lblAngleOutputPitch.Size = new System.Drawing.Size(31, 13);
            this.lblAngleOutputPitch.TabIndex = 7;
            this.lblAngleOutputPitch.Text = "Pitch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Pitch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Yaw";
            // 
            // lblAngleOuptut
            // 
            this.lblAngleOuptut.AutoSize = true;
            this.lblAngleOuptut.Location = new System.Drawing.Point(107, 16);
            this.lblAngleOuptut.Name = "lblAngleOuptut";
            this.lblAngleOuptut.Size = new System.Drawing.Size(31, 13);
            this.lblAngleOuptut.TabIndex = 12;
            this.lblAngleOuptut.Text = "Pitch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Yaw";
            // 
            // GimbalController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 313);
            this.Controls.Add(this.btnCommPortRefresh);
            this.Controls.Add(this.lblCommPorts);
            this.Controls.Add(this.cbCommPorts);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblConsole);
            this.Controls.Add(this.lbConsole);
            this.Controls.Add(this.tabcInputs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GimbalController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gimbal Controller";
            this.Load += new System.EventHandler(this.GimbalController_Load);
            this.tabcInputs.ResumeLayout(false);
            this.tabAngles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRawYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRawPitch)).EndInit();
            this.tabGeo.ResumeLayout(false);
            this.tabGeo.PerformLayout();
            this.tabAboslute.ResumeLayout(false);
            this.tabAboslute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudACLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACLon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetLon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudACX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetX)).EndInit();
            this.gbAngleInputs.ResumeLayout(false);
            this.gbAngleInputs.PerformLayout();
            this.gbAngleOutputs.ResumeLayout(false);
            this.gbAngleOutputs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabcInputs;
        private System.Windows.Forms.TabPage tabAngles;
        private System.Windows.Forms.TabPage tabGeo;
        private System.Windows.Forms.TabPage tabAboslute;
        private System.Windows.Forms.ListBox lbConsole;
        private System.Windows.Forms.Label lblAngleInputYaw;
        private System.Windows.Forms.NumericUpDown nudRawYaw;
        private System.Windows.Forms.Label lblAngleInputPitch;
        private System.Windows.Forms.NumericUpDown nudRawPitch;
        private System.Windows.Forms.Label lblConsole;
        private System.Windows.Forms.Label lblTargetAltUnits;
        private System.Windows.Forms.Label lblTargetAlt;
        private System.Windows.Forms.Label lblTargetLonUnit;
        private System.Windows.Forms.Label lblTargetLon;
        private System.Windows.Forms.Label lblTargetLatUnits;
        private System.Windows.Forms.Label lblTargetLat;
        private System.Windows.Forms.Label lblTargetGeo;
        private System.Windows.Forms.Label lblACAltUnits;
        private System.Windows.Forms.Label lblACAlt;
        private System.Windows.Forms.Label lblACLonUnit;
        private System.Windows.Forms.Label lblACLon;
        private System.Windows.Forms.Label lblACLatUnits;
        private System.Windows.Forms.Label lblACLat;
        private System.Windows.Forms.Label lblACGeo;
        private System.Windows.Forms.Label lblTargetZ;
        private System.Windows.Forms.Label lblTargetY;
        private System.Windows.Forms.Label lblTargetX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblACZ;
        private System.Windows.Forms.Label lblACY;
        private System.Windows.Forms.Label lblACX;
        private System.Windows.Forms.Label lblACRel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.NumericUpDown nudACAlt;
        private System.Windows.Forms.NumericUpDown nudACLon;
        private System.Windows.Forms.NumericUpDown nudACLat;
        private System.Windows.Forms.NumericUpDown nudTargetAlt;
        private System.Windows.Forms.NumericUpDown nudTargetLon;
        private System.Windows.Forms.NumericUpDown nudTargetLat;
        private System.Windows.Forms.ComboBox cbCommPorts;
        private System.Windows.Forms.Label lblCommPorts;
        private System.Windows.Forms.Button btnCommPortRefresh;
        private System.Windows.Forms.NumericUpDown nudTargetZ;
        private System.Windows.Forms.NumericUpDown nudTargetY;
        private System.Windows.Forms.NumericUpDown nudTargetX;
        private System.Windows.Forms.NumericUpDown nudACZ;
        private System.Windows.Forms.NumericUpDown nudACY;
        private System.Windows.Forms.NumericUpDown nudACX;
        private System.Windows.Forms.GroupBox gbAngleOutputs;
        private System.Windows.Forms.GroupBox gbAngleInputs;
        private System.Windows.Forms.Label lblAngleYawUnits;
        private System.Windows.Forms.Label lblAnglePitchUnits;
        private System.Windows.Forms.Label lblAngleOutputPitch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAngleOuptut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

