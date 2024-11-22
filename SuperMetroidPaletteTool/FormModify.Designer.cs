namespace SuperMetroidPaletteTool
{
    partial class FormModify
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModify));
            groupBoxColor_MOD = new GroupBox();
            panelColor_MOD = new Panel();
            textBoxInputColor_MOD = new TextBox();
            groupBoxColor_ORIG = new GroupBox();
            panelColor_ORIG = new Panel();
            textBoxInputColor_ORIG = new TextBox();
            trackBarBrightness = new TrackBar();
            label1 = new Label();
            numericUpDownBrightness = new NumericUpDown();
            numericUpDownContrast = new NumericUpDown();
            label2 = new Label();
            trackBarContrast = new TrackBar();
            numericUpDownHue = new NumericUpDown();
            label3 = new Label();
            trackBarHue = new TrackBar();
            numericUpDownSaturation = new NumericUpDown();
            label4 = new Label();
            trackBarSaturation = new TrackBar();
            buttonApply = new Button();
            buttonCancel = new Button();
            timerUpdateColor = new System.Windows.Forms.Timer(components);
            numericUpDownMoveTowardHue_Hue = new NumericUpDown();
            label5 = new Label();
            trackBarMoveTowardHue_Hue = new TrackBar();
            numericUpDownMoveTowardHue_Strength = new NumericUpDown();
            label6 = new Label();
            trackBarMoveTowardHue_Strength = new TrackBar();
            groupBox1 = new GroupBox();
            label10 = new Label();
            numericUpDownAddSaturation = new NumericUpDown();
            label7 = new Label();
            trackBarAddSaturation = new TrackBar();
            numericUpDownScaleLightness = new NumericUpDown();
            label8 = new Label();
            trackBarScaleLightness = new TrackBar();
            numericUpDownAddLightness = new NumericUpDown();
            label9 = new Label();
            trackBarAddLightness = new TrackBar();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label12 = new Label();
            checkBoxClampSaturationMax = new CheckBox();
            checkBoxClampLightnessMax = new CheckBox();
            label11 = new Label();
            checkBoxClampLightnessMin = new CheckBox();
            checkBoxClampSaturationMin = new CheckBox();
            panelForScroll = new Panel();
            toolTip1 = new ToolTip(components);
            buttonResetValues = new Button();
            groupBoxColor_MOD.SuspendLayout();
            groupBoxColor_ORIG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBrightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarHue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMoveTowardHue_Hue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMoveTowardHue_Hue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMoveTowardHue_Strength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMoveTowardHue_Strength).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAddSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAddSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownScaleLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarScaleLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAddLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAddLightness).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            panelForScroll.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxColor_MOD
            // 
            groupBoxColor_MOD.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxColor_MOD.Controls.Add(panelColor_MOD);
            groupBoxColor_MOD.Controls.Add(textBoxInputColor_MOD);
            groupBoxColor_MOD.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxColor_MOD.Location = new Point(12, 488);
            groupBoxColor_MOD.Name = "groupBoxColor_MOD";
            groupBoxColor_MOD.Size = new Size(560, 40);
            groupBoxColor_MOD.TabIndex = 25;
            groupBoxColor_MOD.TabStop = false;
            groupBoxColor_MOD.Text = "Result - Modified Color";
            groupBoxColor_MOD.Paint += groupBoxColor_MOD_Paint;
            // 
            // panelColor_MOD
            // 
            panelColor_MOD.Location = new Point(3, 15);
            panelColor_MOD.Margin = new Padding(0);
            panelColor_MOD.Name = "panelColor_MOD";
            panelColor_MOD.Size = new Size(256, 16);
            panelColor_MOD.TabIndex = 2;
            panelColor_MOD.Paint += panelColor_MOD_Paint;
            // 
            // textBoxInputColor_MOD
            // 
            textBoxInputColor_MOD.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInputColor_MOD.Font = new Font("Consolas", 8.25F);
            textBoxInputColor_MOD.Location = new Point(263, 12);
            textBoxInputColor_MOD.Margin = new Padding(4);
            textBoxInputColor_MOD.Name = "textBoxInputColor_MOD";
            textBoxInputColor_MOD.ReadOnly = true;
            textBoxInputColor_MOD.Size = new Size(293, 20);
            textBoxInputColor_MOD.TabIndex = 1;
            textBoxInputColor_MOD.Text = "dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000";
            // 
            // groupBoxColor_ORIG
            // 
            groupBoxColor_ORIG.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxColor_ORIG.Controls.Add(panelColor_ORIG);
            groupBoxColor_ORIG.Controls.Add(textBoxInputColor_ORIG);
            groupBoxColor_ORIG.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxColor_ORIG.Location = new Point(12, 12);
            groupBoxColor_ORIG.Name = "groupBoxColor_ORIG";
            groupBoxColor_ORIG.Size = new Size(560, 40);
            groupBoxColor_ORIG.TabIndex = 24;
            groupBoxColor_ORIG.TabStop = false;
            groupBoxColor_ORIG.Text = "Original Color";
            groupBoxColor_ORIG.Paint += groupBoxColorORIG_Paint;
            // 
            // panelColor_ORIG
            // 
            panelColor_ORIG.Cursor = Cursors.Hand;
            panelColor_ORIG.Location = new Point(3, 15);
            panelColor_ORIG.Margin = new Padding(0);
            panelColor_ORIG.Name = "panelColor_ORIG";
            panelColor_ORIG.Size = new Size(256, 16);
            panelColor_ORIG.TabIndex = 1;
            toolTip1.SetToolTip(panelColor_ORIG, "Click a color to toggle whether it will be modified by this operation.\r\nClicking and dragging also works to toggle multiple.");
            panelColor_ORIG.Paint += panelColor_ORIG_Paint;
            panelColor_ORIG.MouseClick += panelColor_ORIG_MouseClick;
            panelColor_ORIG.MouseDown += panelColor_ORIG_MouseDown;
            panelColor_ORIG.MouseMove += panelColor_ORIG_MouseMove;
            panelColor_ORIG.MouseUp += panelColor_ORIG_MouseUp;
            // 
            // textBoxInputColor_ORIG
            // 
            textBoxInputColor_ORIG.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInputColor_ORIG.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxInputColor_ORIG.Location = new Point(263, 12);
            textBoxInputColor_ORIG.Margin = new Padding(4);
            textBoxInputColor_ORIG.Name = "textBoxInputColor_ORIG";
            textBoxInputColor_ORIG.ReadOnly = true;
            textBoxInputColor_ORIG.Size = new Size(292, 20);
            textBoxInputColor_ORIG.TabIndex = 0;
            textBoxInputColor_ORIG.Text = "0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000, 0000";
            // 
            // trackBarBrightness
            // 
            trackBarBrightness.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarBrightness.AutoSize = false;
            trackBarBrightness.LargeChange = 10000;
            trackBarBrightness.Location = new Point(147, 22);
            trackBarBrightness.Maximum = 200000;
            trackBarBrightness.Minimum = -200000;
            trackBarBrightness.Name = "trackBarBrightness";
            trackBarBrightness.Size = new Size(299, 28);
            trackBarBrightness.SmallChange = 1000;
            trackBarBrightness.TabIndex = 26;
            trackBarBrightness.TickFrequency = 100000;
            toolTip1.SetToolTip(trackBarBrightness, resources.GetString("trackBarBrightness.ToolTip"));
            trackBarBrightness.ValueChanged += trackBarBrightness_ValueChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(6, 21);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 27;
            label1.Text = "Brightness (%)";
            label1.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            // 
            // numericUpDownBrightness
            // 
            numericUpDownBrightness.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownBrightness.DecimalPlaces = 3;
            numericUpDownBrightness.Font = new Font("Segoe UI", 9F);
            numericUpDownBrightness.Location = new Point(452, 22);
            numericUpDownBrightness.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownBrightness.Minimum = new decimal(new int[] { 1000000, 0, 0, -2147483648 });
            numericUpDownBrightness.Name = "numericUpDownBrightness";
            numericUpDownBrightness.Size = new Size(98, 23);
            numericUpDownBrightness.TabIndex = 28;
            toolTip1.SetToolTip(numericUpDownBrightness, resources.GetString("numericUpDownBrightness.ToolTip"));
            numericUpDownBrightness.ValueChanged += numericUpDownBrightness_ValueChanged;
            // 
            // numericUpDownContrast
            // 
            numericUpDownContrast.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownContrast.DecimalPlaces = 3;
            numericUpDownContrast.Font = new Font("Segoe UI", 9F);
            numericUpDownContrast.Location = new Point(452, 51);
            numericUpDownContrast.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownContrast.Minimum = new decimal(new int[] { 1000000, 0, 0, -2147483648 });
            numericUpDownContrast.Name = "numericUpDownContrast";
            numericUpDownContrast.Size = new Size(98, 23);
            numericUpDownContrast.TabIndex = 31;
            toolTip1.SetToolTip(numericUpDownContrast, resources.GetString("numericUpDownContrast.ToolTip"));
            numericUpDownContrast.ValueChanged += numericUpDownContrast_ValueChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(6, 50);
            label2.Name = "label2";
            label2.Size = new Size(135, 20);
            label2.TabIndex = 30;
            label2.Text = "Contrast (%)";
            label2.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // trackBarContrast
            // 
            trackBarContrast.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarContrast.AutoSize = false;
            trackBarContrast.LargeChange = 10000;
            trackBarContrast.Location = new Point(147, 51);
            trackBarContrast.Maximum = 200000;
            trackBarContrast.Minimum = -200000;
            trackBarContrast.Name = "trackBarContrast";
            trackBarContrast.Size = new Size(299, 28);
            trackBarContrast.SmallChange = 1000;
            trackBarContrast.TabIndex = 29;
            trackBarContrast.TickFrequency = 100000;
            toolTip1.SetToolTip(trackBarContrast, resources.GetString("trackBarContrast.ToolTip"));
            trackBarContrast.ValueChanged += trackBarContrast_ValueChanged;
            // 
            // numericUpDownHue
            // 
            numericUpDownHue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownHue.DecimalPlaces = 3;
            numericUpDownHue.Font = new Font("Segoe UI", 9F);
            numericUpDownHue.Location = new Point(450, 190);
            numericUpDownHue.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDownHue.Minimum = new decimal(new int[] { 360, 0, 0, -2147483648 });
            numericUpDownHue.Name = "numericUpDownHue";
            numericUpDownHue.Size = new Size(98, 23);
            numericUpDownHue.TabIndex = 34;
            toolTip1.SetToolTip(numericUpDownHue, "Shifts hues of the selected colors by the amount specified (in degrees).");
            numericUpDownHue.ValueChanged += numericUpDownHue_ValueChanged;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(4, 189);
            label3.Name = "label3";
            label3.Size = new Size(135, 20);
            label3.TabIndex = 33;
            label3.Text = "Shift Hue (deg)";
            label3.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label3, "Shifts hues of the selected colors by the amount specified (in degrees).");
            // 
            // trackBarHue
            // 
            trackBarHue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarHue.AutoSize = false;
            trackBarHue.LargeChange = 1000;
            trackBarHue.Location = new Point(145, 190);
            trackBarHue.Maximum = 360000;
            trackBarHue.Minimum = -360000;
            trackBarHue.Name = "trackBarHue";
            trackBarHue.Size = new Size(299, 28);
            trackBarHue.SmallChange = 1000;
            trackBarHue.TabIndex = 32;
            trackBarHue.TickFrequency = 7200000;
            toolTip1.SetToolTip(trackBarHue, "Shifts hues of the selected colors by the amount specified (in degrees).");
            trackBarHue.ValueChanged += trackBarHue_ValueChanged;
            // 
            // numericUpDownSaturation
            // 
            numericUpDownSaturation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownSaturation.DecimalPlaces = 3;
            numericUpDownSaturation.Font = new Font("Segoe UI", 9F);
            numericUpDownSaturation.Location = new Point(452, 22);
            numericUpDownSaturation.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownSaturation.Name = "numericUpDownSaturation";
            numericUpDownSaturation.Size = new Size(98, 23);
            numericUpDownSaturation.TabIndex = 37;
            toolTip1.SetToolTip(numericUpDownSaturation, "Scales existing HSL saturation values of the selected colors. For grayscale colors, the saturation is 0, so scaling it will not saturate it. For grayscale colors, try \"Shift Saturation\".");
            numericUpDownSaturation.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownSaturation.ValueChanged += numericUpDownSaturation_ValueChanged;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(6, 21);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(135, 20);
            label4.TabIndex = 36;
            label4.Text = "Scale Saturation (%)";
            label4.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label4, "Scales existing HSL saturation values of the selected colors. For grayscale colors, the saturation is 0, so scaling it will not saturate it. For grayscale colors, try \"Shift Saturation\".");
            // 
            // trackBarSaturation
            // 
            trackBarSaturation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarSaturation.AutoSize = false;
            trackBarSaturation.LargeChange = 10000;
            trackBarSaturation.Location = new Point(147, 22);
            trackBarSaturation.Maximum = 200000;
            trackBarSaturation.Name = "trackBarSaturation";
            trackBarSaturation.Size = new Size(299, 28);
            trackBarSaturation.SmallChange = 1000;
            trackBarSaturation.TabIndex = 35;
            trackBarSaturation.TickFrequency = 25000;
            toolTip1.SetToolTip(trackBarSaturation, "Scales existing HSL saturation values of the selected colors. For grayscale colors, the saturation is 0, so scaling it will not saturate it. For grayscale colors, try \"Shift Saturation\".");
            trackBarSaturation.Value = 100000;
            trackBarSaturation.ValueChanged += trackBarSaturation_ValueChanged;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonApply.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonApply.Location = new Point(401, 541);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(166, 23);
            buttonApply.TabIndex = 38;
            buttonApply.Text = "Accept Changes";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(326, 541);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(69, 23);
            buttonCancel.TabIndex = 39;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // timerUpdateColor
            // 
            timerUpdateColor.Enabled = true;
            timerUpdateColor.Interval = 16;
            timerUpdateColor.Tick += timerUpdateColor_Tick;
            // 
            // numericUpDownMoveTowardHue_Hue
            // 
            numericUpDownMoveTowardHue_Hue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownMoveTowardHue_Hue.DecimalPlaces = 3;
            numericUpDownMoveTowardHue_Hue.Font = new Font("Segoe UI", 9F);
            numericUpDownMoveTowardHue_Hue.Location = new Point(435, 40);
            numericUpDownMoveTowardHue_Hue.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDownMoveTowardHue_Hue.Name = "numericUpDownMoveTowardHue_Hue";
            numericUpDownMoveTowardHue_Hue.Size = new Size(104, 23);
            numericUpDownMoveTowardHue_Hue.TabIndex = 42;
            toolTip1.SetToolTip(numericUpDownMoveTowardHue_Hue, resources.GetString("numericUpDownMoveTowardHue_Hue.ToolTip"));
            numericUpDownMoveTowardHue_Hue.ValueChanged += numericUpDownMoveTowardHue_Hue_ValueChanged;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(24, 37);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 41;
            label5.Text = "Hue (deg)";
            label5.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label5, resources.GetString("label5.ToolTip"));
            // 
            // trackBarMoveTowardHue_Hue
            // 
            trackBarMoveTowardHue_Hue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarMoveTowardHue_Hue.AutoSize = false;
            trackBarMoveTowardHue_Hue.LargeChange = 10000;
            trackBarMoveTowardHue_Hue.Location = new Point(106, 37);
            trackBarMoveTowardHue_Hue.Maximum = 360000;
            trackBarMoveTowardHue_Hue.Name = "trackBarMoveTowardHue_Hue";
            trackBarMoveTowardHue_Hue.Size = new Size(323, 28);
            trackBarMoveTowardHue_Hue.SmallChange = 1000;
            trackBarMoveTowardHue_Hue.TabIndex = 40;
            trackBarMoveTowardHue_Hue.TickFrequency = 90000;
            toolTip1.SetToolTip(trackBarMoveTowardHue_Hue, resources.GetString("trackBarMoveTowardHue_Hue.ToolTip"));
            trackBarMoveTowardHue_Hue.Scroll += trackBarMoveTowardHue_Hue_Scroll;
            trackBarMoveTowardHue_Hue.ValueChanged += trackBarMoveTowardHue_Hue_ValueChanged;
            // 
            // numericUpDownMoveTowardHue_Strength
            // 
            numericUpDownMoveTowardHue_Strength.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownMoveTowardHue_Strength.DecimalPlaces = 3;
            numericUpDownMoveTowardHue_Strength.Font = new Font("Segoe UI", 9F);
            numericUpDownMoveTowardHue_Strength.Location = new Point(435, 69);
            numericUpDownMoveTowardHue_Strength.Name = "numericUpDownMoveTowardHue_Strength";
            numericUpDownMoveTowardHue_Strength.Size = new Size(104, 23);
            numericUpDownMoveTowardHue_Strength.TabIndex = 45;
            toolTip1.SetToolTip(numericUpDownMoveTowardHue_Strength, resources.GetString("numericUpDownMoveTowardHue_Strength.ToolTip"));
            numericUpDownMoveTowardHue_Strength.ValueChanged += numericUpDownMoveTowardHue_Strength_ValueChanged;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(24, 65);
            label6.Name = "label6";
            label6.Size = new Size(80, 20);
            label6.TabIndex = 44;
            label6.Text = "Strength (%)";
            label6.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label6, resources.GetString("label6.ToolTip"));
            // 
            // trackBarMoveTowardHue_Strength
            // 
            trackBarMoveTowardHue_Strength.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarMoveTowardHue_Strength.AutoSize = false;
            trackBarMoveTowardHue_Strength.LargeChange = 10000;
            trackBarMoveTowardHue_Strength.Location = new Point(106, 66);
            trackBarMoveTowardHue_Strength.Maximum = 100000;
            trackBarMoveTowardHue_Strength.Name = "trackBarMoveTowardHue_Strength";
            trackBarMoveTowardHue_Strength.Size = new Size(323, 28);
            trackBarMoveTowardHue_Strength.SmallChange = 1000;
            trackBarMoveTowardHue_Strength.TabIndex = 43;
            trackBarMoveTowardHue_Strength.TickFrequency = 25000;
            toolTip1.SetToolTip(trackBarMoveTowardHue_Strength, resources.GetString("trackBarMoveTowardHue_Strength.ToolTip"));
            trackBarMoveTowardHue_Strength.ValueChanged += trackBarMoveTowardHue_Strength_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numericUpDownMoveTowardHue_Strength);
            groupBox1.Controls.Add(trackBarMoveTowardHue_Hue);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numericUpDownMoveTowardHue_Hue);
            groupBox1.Controls.Add(trackBarMoveTowardHue_Strength);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(4, 219);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(544, 102);
            groupBox1.TabIndex = 46;
            groupBox1.TabStop = false;
            groupBox1.Text = "Apply Hue Tint";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F);
            label10.Location = new Point(14, 19);
            label10.Name = "label10";
            label10.Size = new Size(311, 15);
            label10.TabIndex = 46;
            label10.Text = "Shifts the hues of selected colors toward one specific hue.";
            // 
            // numericUpDownAddSaturation
            // 
            numericUpDownAddSaturation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownAddSaturation.DecimalPlaces = 3;
            numericUpDownAddSaturation.Font = new Font("Segoe UI", 9F);
            numericUpDownAddSaturation.Location = new Point(452, 51);
            numericUpDownAddSaturation.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownAddSaturation.Minimum = new decimal(new int[] { 1000000, 0, 0, -2147483648 });
            numericUpDownAddSaturation.Name = "numericUpDownAddSaturation";
            numericUpDownAddSaturation.Size = new Size(98, 23);
            numericUpDownAddSaturation.TabIndex = 49;
            toolTip1.SetToolTip(numericUpDownAddSaturation, resources.GetString("numericUpDownAddSaturation.ToolTip"));
            numericUpDownAddSaturation.ValueChanged += numericUpDownAddSaturation_ValueChanged;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(6, 50);
            label7.Name = "label7";
            label7.Size = new Size(135, 20);
            label7.TabIndex = 48;
            label7.Text = "Shift Saturation (%)";
            label7.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label7, resources.GetString("label7.ToolTip"));
            // 
            // trackBarAddSaturation
            // 
            trackBarAddSaturation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarAddSaturation.AutoSize = false;
            trackBarAddSaturation.LargeChange = 10000;
            trackBarAddSaturation.Location = new Point(147, 51);
            trackBarAddSaturation.Maximum = 200000;
            trackBarAddSaturation.Minimum = -200000;
            trackBarAddSaturation.Name = "trackBarAddSaturation";
            trackBarAddSaturation.Size = new Size(299, 28);
            trackBarAddSaturation.SmallChange = 1000;
            trackBarAddSaturation.TabIndex = 47;
            trackBarAddSaturation.TickFrequency = 25000;
            toolTip1.SetToolTip(trackBarAddSaturation, resources.GetString("trackBarAddSaturation.ToolTip"));
            trackBarAddSaturation.ValueChanged += trackBarAddSaturation_ValueChanged;
            // 
            // numericUpDownScaleLightness
            // 
            numericUpDownScaleLightness.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownScaleLightness.DecimalPlaces = 3;
            numericUpDownScaleLightness.Font = new Font("Segoe UI", 9F);
            numericUpDownScaleLightness.Location = new Point(452, 106);
            numericUpDownScaleLightness.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownScaleLightness.Name = "numericUpDownScaleLightness";
            numericUpDownScaleLightness.Size = new Size(98, 23);
            numericUpDownScaleLightness.TabIndex = 52;
            toolTip1.SetToolTip(numericUpDownScaleLightness, "Scales existing HSL lightness values of the selected colors. For black, the lightness is 0, so scaling it will not lighten it. For black, try \"Shift Lightness\".");
            numericUpDownScaleLightness.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownScaleLightness.ValueChanged += numericUpDownScaleLightness_ValueChanged;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(6, 105);
            label8.Name = "label8";
            label8.Size = new Size(135, 20);
            label8.TabIndex = 51;
            label8.Text = "Scale Lightness (%)";
            label8.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label8, "Scales existing HSL lightness values of the selected colors. For black, the lightness is 0, so scaling it will not lighten it. For black, try \"Shift Lightness\".");
            // 
            // trackBarScaleLightness
            // 
            trackBarScaleLightness.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarScaleLightness.AutoSize = false;
            trackBarScaleLightness.LargeChange = 10000;
            trackBarScaleLightness.Location = new Point(147, 106);
            trackBarScaleLightness.Maximum = 200000;
            trackBarScaleLightness.Name = "trackBarScaleLightness";
            trackBarScaleLightness.Size = new Size(299, 28);
            trackBarScaleLightness.SmallChange = 1000;
            trackBarScaleLightness.TabIndex = 50;
            trackBarScaleLightness.TickFrequency = 25000;
            toolTip1.SetToolTip(trackBarScaleLightness, "Scales existing HSL lightness values of the selected colors. For black, the lightness is 0, so scaling it will not lighten it. For black, try \"Shift Lightness\".");
            trackBarScaleLightness.Value = 100000;
            trackBarScaleLightness.ValueChanged += trackBarScaleLightness_ValueChanged;
            // 
            // numericUpDownAddLightness
            // 
            numericUpDownAddLightness.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownAddLightness.DecimalPlaces = 3;
            numericUpDownAddLightness.Font = new Font("Segoe UI", 9F);
            numericUpDownAddLightness.Location = new Point(452, 135);
            numericUpDownAddLightness.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownAddLightness.Minimum = new decimal(new int[] { 1000000, 0, 0, -2147483648 });
            numericUpDownAddLightness.Name = "numericUpDownAddLightness";
            numericUpDownAddLightness.Size = new Size(98, 23);
            numericUpDownAddLightness.TabIndex = 55;
            toolTip1.SetToolTip(numericUpDownAddLightness, "Adds/subtracts HSL lightness to/from the selected colors. Will work even on black which will usually bring out the default hue (red), which can be adjusted with some of the hue related options here.");
            numericUpDownAddLightness.ValueChanged += numericUpDownAddLightness_ValueChanged;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 9F);
            label9.Location = new Point(6, 133);
            label9.Name = "label9";
            label9.Size = new Size(135, 20);
            label9.TabIndex = 54;
            label9.Text = "Shift Lightness (%)";
            label9.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label9, "Adds/subtracts HSL lightness to/from the selected colors. Will work even on black which will usually bring out the default hue (red), which can be adjusted with some of the hue related options here.");
            // 
            // trackBarAddLightness
            // 
            trackBarAddLightness.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBarAddLightness.AutoSize = false;
            trackBarAddLightness.LargeChange = 10000;
            trackBarAddLightness.Location = new Point(147, 135);
            trackBarAddLightness.Maximum = 200000;
            trackBarAddLightness.Minimum = -200000;
            trackBarAddLightness.Name = "trackBarAddLightness";
            trackBarAddLightness.Size = new Size(299, 28);
            trackBarAddLightness.SmallChange = 1000;
            trackBarAddLightness.TabIndex = 53;
            trackBarAddLightness.TickFrequency = 25000;
            toolTip1.SetToolTip(trackBarAddLightness, "Adds/subtracts HSL lightness to/from the selected colors. Will work even on black which will usually bring out the default hue (red), which can be adjusted with some of the hue related options here.");
            trackBarAddLightness.ValueChanged += trackBarAddLightness_ValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(numericUpDownBrightness);
            groupBox2.Controls.Add(trackBarBrightness);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(numericUpDownContrast);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(trackBarContrast);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(2, 335);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(556, 84);
            groupBox2.TabIndex = 56;
            groupBox2.TabStop = false;
            groupBox2.Text = "Step 2 - Modify RGB";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(checkBoxClampSaturationMax);
            groupBox3.Controls.Add(checkBoxClampLightnessMax);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(checkBoxClampLightnessMin);
            groupBox3.Controls.Add(checkBoxClampSaturationMin);
            groupBox3.Controls.Add(groupBox1);
            groupBox3.Controls.Add(numericUpDownAddLightness);
            groupBox3.Controls.Add(numericUpDownHue);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(trackBarHue);
            groupBox3.Controls.Add(trackBarAddLightness);
            groupBox3.Controls.Add(numericUpDownScaleLightness);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(trackBarScaleLightness);
            groupBox3.Controls.Add(numericUpDownAddSaturation);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(trackBarSaturation);
            groupBox3.Controls.Add(trackBarAddSaturation);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(numericUpDownSaturation);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(2, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(556, 327);
            groupBox3.TabIndex = 57;
            groupBox3.TabStop = false;
            groupBox3.Text = "Step 1 - Modify HSL";
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(4, 80);
            label12.Name = "label12";
            label12.Size = new Size(135, 20);
            label12.TabIndex = 61;
            label12.Text = "Clamp Saturation";
            label12.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label12, "Clamps the HSL saturation values of selected colors. With 'Min' checked, the value cannot go below 0%, with 'Max' checked, the value cannot go over 100%.");
            // 
            // checkBoxClampSaturationMax
            // 
            checkBoxClampSaturationMax.AutoSize = true;
            checkBoxClampSaturationMax.Font = new Font("Segoe UI", 9F);
            checkBoxClampSaturationMax.Location = new Point(207, 83);
            checkBoxClampSaturationMax.Name = "checkBoxClampSaturationMax";
            checkBoxClampSaturationMax.Size = new Size(49, 19);
            checkBoxClampSaturationMax.TabIndex = 60;
            checkBoxClampSaturationMax.Text = "Max";
            toolTip1.SetToolTip(checkBoxClampSaturationMax, "Clamps the HSL saturation values of selected colors. With 'Min' checked, the value cannot go below 0%, with 'Max' checked, the value cannot go over 100%.");
            checkBoxClampSaturationMax.UseVisualStyleBackColor = true;
            checkBoxClampSaturationMax.CheckedChanged += checkBoxClampSaturationMax_CheckedChanged;
            // 
            // checkBoxClampLightnessMax
            // 
            checkBoxClampLightnessMax.AutoSize = true;
            checkBoxClampLightnessMax.Font = new Font("Segoe UI", 9F);
            checkBoxClampLightnessMax.Location = new Point(207, 165);
            checkBoxClampLightnessMax.Name = "checkBoxClampLightnessMax";
            checkBoxClampLightnessMax.Size = new Size(49, 19);
            checkBoxClampLightnessMax.TabIndex = 59;
            checkBoxClampLightnessMax.Text = "Max";
            toolTip1.SetToolTip(checkBoxClampLightnessMax, "Clamps the HSL lightness values of selected colors. With 'Min' checked, the value cannot go below 0%, with 'Max' checked, the value cannot go over 100%.");
            checkBoxClampLightnessMax.UseVisualStyleBackColor = true;
            checkBoxClampLightnessMax.CheckedChanged += checkBoxClampLightnessMax_CheckedChanged;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 9F);
            label11.Location = new Point(6, 162);
            label11.Name = "label11";
            label11.Size = new Size(135, 20);
            label11.TabIndex = 58;
            label11.Text = "Clamp Lightness";
            label11.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(label11, "Clamps the HSL lightness values of selected colors. With 'Min' checked, the value cannot go below 0%, with 'Max' checked, the value cannot go over 100%.");
            // 
            // checkBoxClampLightnessMin
            // 
            checkBoxClampLightnessMin.AutoSize = true;
            checkBoxClampLightnessMin.Font = new Font("Segoe UI", 9F);
            checkBoxClampLightnessMin.Location = new Point(154, 165);
            checkBoxClampLightnessMin.Name = "checkBoxClampLightnessMin";
            checkBoxClampLightnessMin.Size = new Size(47, 19);
            checkBoxClampLightnessMin.TabIndex = 57;
            checkBoxClampLightnessMin.Text = "Min";
            toolTip1.SetToolTip(checkBoxClampLightnessMin, "Clamps the HSL lightness values of selected colors. With 'Min' checked, the value cannot go below 0%, with 'Max' checked, the value cannot go over 100%.");
            checkBoxClampLightnessMin.UseVisualStyleBackColor = true;
            checkBoxClampLightnessMin.CheckedChanged += checkBoxClampLightness_CheckedChanged;
            // 
            // checkBoxClampSaturationMin
            // 
            checkBoxClampSaturationMin.AutoSize = true;
            checkBoxClampSaturationMin.Font = new Font("Segoe UI", 9F);
            checkBoxClampSaturationMin.Location = new Point(154, 83);
            checkBoxClampSaturationMin.Name = "checkBoxClampSaturationMin";
            checkBoxClampSaturationMin.Size = new Size(47, 19);
            checkBoxClampSaturationMin.TabIndex = 56;
            checkBoxClampSaturationMin.Text = "Min";
            toolTip1.SetToolTip(checkBoxClampSaturationMin, "Clamps the HSL saturation values of selected colors. With 'Min' checked, the value cannot go below 0%, with 'Max' checked, the value cannot go over 100%.");
            checkBoxClampSaturationMin.UseVisualStyleBackColor = true;
            checkBoxClampSaturationMin.CheckedChanged += checkBoxClampSaturation_CheckedChanged;
            // 
            // panelForScroll
            // 
            panelForScroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelForScroll.AutoScroll = true;
            panelForScroll.Controls.Add(groupBox3);
            panelForScroll.Controls.Add(groupBox2);
            panelForScroll.Location = new Point(12, 58);
            panelForScroll.Name = "panelForScroll";
            panelForScroll.Size = new Size(560, 424);
            panelForScroll.TabIndex = 58;
            // 
            // buttonResetValues
            // 
            buttonResetValues.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonResetValues.Location = new Point(12, 541);
            buttonResetValues.Name = "buttonResetValues";
            buttonResetValues.Size = new Size(75, 23);
            buttonResetValues.TabIndex = 59;
            buttonResetValues.Text = "Reset All";
            buttonResetValues.UseVisualStyleBackColor = true;
            buttonResetValues.Click += buttonResetValues_Click;
            // 
            // FormModify
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 573);
            Controls.Add(buttonResetValues);
            Controls.Add(panelForScroll);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(groupBoxColor_MOD);
            Controls.Add(groupBoxColor_ORIG);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MinimumSize = new Size(440, 330);
            Name = "FormModify";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modify 'FROM' Color";
            Activated += FormModify_Activated;
            FormClosing += FormModify_FormClosing;
            Load += FormModify_Load;
            VisibleChanged += FormModify_VisibleChanged;
            groupBoxColor_MOD.ResumeLayout(false);
            groupBoxColor_MOD.PerformLayout();
            groupBoxColor_ORIG.ResumeLayout(false);
            groupBoxColor_ORIG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBrightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBrightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarContrast).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHue).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarHue).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMoveTowardHue_Hue).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMoveTowardHue_Hue).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMoveTowardHue_Strength).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMoveTowardHue_Strength).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAddSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAddSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownScaleLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarScaleLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAddLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarAddLightness).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panelForScroll.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxColor_MOD;
        private TextBox textBoxInputColor_MOD;
        private Label label47;
        private GroupBox groupBoxColor_ORIG;
        private TextBox textBoxInputColor_ORIG;
        private Label labelColorInput1;
        private TrackBar trackBarBrightness;
        private Label label1;
        private NumericUpDown numericUpDownBrightness;
        private NumericUpDown numericUpDownContrast;
        private Label label2;
        private TrackBar trackBarContrast;
        private NumericUpDown numericUpDownHue;
        private Label label3;
        private TrackBar trackBarHue;
        private NumericUpDown numericUpDownSaturation;
        private Label label4;
        private TrackBar trackBarSaturation;
        private Button buttonApply;
        private Button buttonCancel;
        private System.Windows.Forms.Timer timerUpdateColor;
        private Panel panelColor_ORIG;
        private Panel panelColor_MOD;
        private NumericUpDown numericUpDownMoveTowardHue_Hue;
        private Label label5;
        private TrackBar trackBarMoveTowardHue_Hue;
        private NumericUpDown numericUpDownMoveTowardHue_Strength;
        private Label label6;
        private TrackBar trackBarMoveTowardHue_Strength;
        private GroupBox groupBox1;
        private NumericUpDown numericUpDownAddSaturation;
        private Label label7;
        private TrackBar trackBarAddSaturation;
        private NumericUpDown numericUpDownScaleLightness;
        private Label label8;
        private TrackBar trackBarScaleLightness;
        private NumericUpDown numericUpDownAddLightness;
        private Label label9;
        private TrackBar trackBarAddLightness;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Panel panelForScroll;
        private Label label10;
        private ToolTip toolTip1;
        private Button buttonResetValues;
        private CheckBox checkBoxClampSaturationMin;
        private CheckBox checkBoxClampLightnessMin;
        private Label label11;
        private Label label12;
        private CheckBox checkBoxClampSaturationMax;
        private CheckBox checkBoxClampLightnessMax;
    }
}