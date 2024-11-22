namespace SuperMetroidPaletteTool
{
    partial class FormEditSingleColor
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
            pictureBoxColorField = new PixelPictureBox();
            label1 = new Label();
            label2 = new Label();
            trackBarRed = new TrackBar();
            label3 = new Label();
            trackBarGreen = new TrackBar();
            label4 = new Label();
            trackBarBlue = new TrackBar();
            trackBarLightness = new TrackBar();
            label5 = new Label();
            trackBarSaturation = new TrackBar();
            label6 = new Label();
            trackBarHue = new TrackBar();
            label7 = new Label();
            timerMouseHeld = new System.Windows.Forms.Timer(components);
            panelColorSwatch = new Panel();
            buttonApply = new Button();
            buttonCancel = new Button();
            numericUpDownRed = new NumericUpDown();
            numericUpDownGreen = new NumericUpDown();
            numericUpDownBlue = new NumericUpDown();
            numericUpDownSaturation = new NumericUpDown();
            numericUpDownHue = new NumericUpDown();
            numericUpDownLightness = new NumericUpDown();
            checkBoxUseHexForChannels = new CheckBox();
            textBoxColorHex = new TextBox();
            label8 = new Label();
            textBoxColorHex_PC = new TextBox();
            panelPCColorGeneratedFrom = new Panel();
            labelPCColorGeneratedFrom = new Label();
            buttonRevertColor = new Button();
            labelHeader = new Label();
            panelHeaderColorORIG = new Panel();
            label10 = new Label();
            panelHeaderColorMOD = new Panel();
            panelPictureBox = new Panel();
            buttonDbgBenchmark = new Button();
            labelDbgBenchmarkResult = new Label();
            comboBoxGraphMode = new ComboBox();
            label9 = new Label();
            pixelPictureBoxGraphZ = new PixelPictureBox();
            panelGraphZ = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxColorField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBlue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarLightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarHue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBlue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLightness).BeginInit();
            panelPictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pixelPictureBoxGraphZ).BeginInit();
            panelGraphZ.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxColorField
            // 
            pictureBoxColorField.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxColorField.Location = new Point(0, 0);
            pictureBoxColorField.Margin = new Padding(0);
            pictureBoxColorField.Name = "pictureBoxColorField";
            pictureBoxColorField.Size = new Size(256, 256);
            pictureBoxColorField.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxColorField.TabIndex = 4;
            pictureBoxColorField.TabStop = false;
            pictureBoxColorField.Paint += pictureBoxColorField_Paint;
            pictureBoxColorField.MouseDown += pictureBoxColorField_MouseDown;
            pictureBoxColorField.MouseMove += pictureBoxColorField_MouseMove;
            pictureBoxColorField.MouseUp += pictureBoxColorField_MouseUp;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(66, 316);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 6;
            label1.Text = "SNES Color Hex:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(305, 78);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 7;
            label2.Text = "Red";
            // 
            // trackBarRed
            // 
            trackBarRed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            trackBarRed.AutoSize = false;
            trackBarRed.Location = new Point(368, 76);
            trackBarRed.Maximum = 31;
            trackBarRed.Name = "trackBarRed";
            trackBarRed.Size = new Size(101, 24);
            trackBarRed.TabIndex = 8;
            trackBarRed.TickFrequency = 4;
            trackBarRed.ValueChanged += trackBarRed_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(305, 107);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 9;
            label3.Text = "Green";
            // 
            // trackBarGreen
            // 
            trackBarGreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            trackBarGreen.AutoSize = false;
            trackBarGreen.Location = new Point(368, 105);
            trackBarGreen.Maximum = 31;
            trackBarGreen.Name = "trackBarGreen";
            trackBarGreen.Size = new Size(101, 24);
            trackBarGreen.TabIndex = 10;
            trackBarGreen.TickFrequency = 4;
            trackBarGreen.ValueChanged += trackBarGreen_ValueChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(305, 136);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 11;
            label4.Text = "Blue";
            // 
            // trackBarBlue
            // 
            trackBarBlue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            trackBarBlue.AutoSize = false;
            trackBarBlue.Location = new Point(368, 134);
            trackBarBlue.Maximum = 31;
            trackBarBlue.Name = "trackBarBlue";
            trackBarBlue.Size = new Size(101, 24);
            trackBarBlue.TabIndex = 12;
            trackBarBlue.TickFrequency = 4;
            trackBarBlue.ValueChanged += trackBarBlue_ValueChanged;
            // 
            // trackBarLightness
            // 
            trackBarLightness.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            trackBarLightness.AutoSize = false;
            trackBarLightness.Location = new Point(368, 221);
            trackBarLightness.Maximum = 128;
            trackBarLightness.Name = "trackBarLightness";
            trackBarLightness.Size = new Size(100, 24);
            trackBarLightness.TabIndex = 18;
            trackBarLightness.TickFrequency = 8;
            trackBarLightness.ValueChanged += trackBarLightness_ValueChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(304, 223);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 17;
            label5.Text = "Lightness";
            // 
            // trackBarSaturation
            // 
            trackBarSaturation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            trackBarSaturation.AutoSize = false;
            trackBarSaturation.Location = new Point(368, 192);
            trackBarSaturation.Maximum = 31;
            trackBarSaturation.Name = "trackBarSaturation";
            trackBarSaturation.Size = new Size(100, 24);
            trackBarSaturation.TabIndex = 16;
            trackBarSaturation.TickFrequency = 4;
            trackBarSaturation.ValueChanged += trackBarSaturation_ValueChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(304, 194);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 15;
            label6.Text = "Saturation";
            // 
            // trackBarHue
            // 
            trackBarHue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            trackBarHue.AutoSize = false;
            trackBarHue.Location = new Point(368, 163);
            trackBarHue.Maximum = 128;
            trackBarHue.Name = "trackBarHue";
            trackBarHue.Size = new Size(101, 24);
            trackBarHue.TabIndex = 14;
            trackBarHue.TickFrequency = 8;
            trackBarHue.ValueChanged += trackBarHue_ValueChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(305, 165);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 13;
            label7.Text = "Hue";
            // 
            // timerMouseHeld
            // 
            timerMouseHeld.Interval = 16;
            timerMouseHeld.Tick += timerMouseHeld_Tick;
            // 
            // panelColorSwatch
            // 
            panelColorSwatch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelColorSwatch.BorderStyle = BorderStyle.FixedSingle;
            panelColorSwatch.Location = new Point(12, 314);
            panelColorSwatch.Name = "panelColorSwatch";
            panelColorSwatch.Size = new Size(48, 48);
            panelColorSwatch.TabIndex = 19;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonApply.Location = new Point(459, 358);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(64, 23);
            buttonApply.TabIndex = 20;
            buttonApply.Text = "Accept";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(303, 358);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(150, 23);
            buttonCancel.TabIndex = 21;
            buttonCancel.Text = "Cancel (Discard Changes)";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // numericUpDownRed
            // 
            numericUpDownRed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownRed.Hexadecimal = true;
            numericUpDownRed.Location = new Point(475, 76);
            numericUpDownRed.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDownRed.Name = "numericUpDownRed";
            numericUpDownRed.Size = new Size(48, 23);
            numericUpDownRed.TabIndex = 22;
            numericUpDownRed.ValueChanged += numericUpDownRed_ValueChanged;
            // 
            // numericUpDownGreen
            // 
            numericUpDownGreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownGreen.Hexadecimal = true;
            numericUpDownGreen.Location = new Point(475, 105);
            numericUpDownGreen.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDownGreen.Name = "numericUpDownGreen";
            numericUpDownGreen.Size = new Size(48, 23);
            numericUpDownGreen.TabIndex = 23;
            numericUpDownGreen.ValueChanged += numericUpDownGreen_ValueChanged;
            // 
            // numericUpDownBlue
            // 
            numericUpDownBlue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownBlue.Hexadecimal = true;
            numericUpDownBlue.Location = new Point(475, 134);
            numericUpDownBlue.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDownBlue.Name = "numericUpDownBlue";
            numericUpDownBlue.Size = new Size(48, 23);
            numericUpDownBlue.TabIndex = 24;
            numericUpDownBlue.ValueChanged += numericUpDownBlue_ValueChanged;
            // 
            // numericUpDownSaturation
            // 
            numericUpDownSaturation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownSaturation.Hexadecimal = true;
            numericUpDownSaturation.Location = new Point(474, 192);
            numericUpDownSaturation.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDownSaturation.Name = "numericUpDownSaturation";
            numericUpDownSaturation.Size = new Size(48, 23);
            numericUpDownSaturation.TabIndex = 25;
            numericUpDownSaturation.ValueChanged += numericUpDownSaturation_ValueChanged;
            // 
            // numericUpDownHue
            // 
            numericUpDownHue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownHue.Hexadecimal = true;
            numericUpDownHue.Location = new Point(475, 163);
            numericUpDownHue.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            numericUpDownHue.Name = "numericUpDownHue";
            numericUpDownHue.Size = new Size(48, 23);
            numericUpDownHue.TabIndex = 26;
            numericUpDownHue.ValueChanged += numericUpDownHue_ValueChanged;
            // 
            // numericUpDownLightness
            // 
            numericUpDownLightness.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownLightness.Hexadecimal = true;
            numericUpDownLightness.Location = new Point(474, 221);
            numericUpDownLightness.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            numericUpDownLightness.Name = "numericUpDownLightness";
            numericUpDownLightness.Size = new Size(48, 23);
            numericUpDownLightness.TabIndex = 27;
            numericUpDownLightness.ValueChanged += numericUpDownLightness_ValueChanged;
            // 
            // checkBoxUseHexForChannels
            // 
            checkBoxUseHexForChannels.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxUseHexForChannels.AutoSize = true;
            checkBoxUseHexForChannels.Checked = true;
            checkBoxUseHexForChannels.CheckState = CheckState.Checked;
            checkBoxUseHexForChannels.Location = new Point(476, 250);
            checkBoxUseHexForChannels.Name = "checkBoxUseHexForChannels";
            checkBoxUseHexForChannels.Size = new Size(47, 19);
            checkBoxUseHexForChannels.TabIndex = 28;
            checkBoxUseHexForChannels.Text = "Hex";
            checkBoxUseHexForChannels.UseVisualStyleBackColor = true;
            checkBoxUseHexForChannels.CheckedChanged += checkBoxUseHexForChannels_CheckedChanged;
            // 
            // textBoxColorHex
            // 
            textBoxColorHex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxColorHex.Font = new Font("Consolas", 9F);
            textBoxColorHex.Location = new Point(163, 311);
            textBoxColorHex.Name = "textBoxColorHex";
            textBoxColorHex.Size = new Size(68, 22);
            textBoxColorHex.TabIndex = 29;
            textBoxColorHex.Text = "0000";
            textBoxColorHex.KeyDown += textBoxColorHex_KeyDown;
            textBoxColorHex.Validating += textBoxColorHex_Validating;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(78, 343);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 30;
            label8.Text = "PC Color Hex:";
            // 
            // textBoxColorHex_PC
            // 
            textBoxColorHex_PC.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxColorHex_PC.Font = new Font("Consolas", 9F);
            textBoxColorHex_PC.Location = new Point(163, 339);
            textBoxColorHex_PC.Name = "textBoxColorHex_PC";
            textBoxColorHex_PC.Size = new Size(68, 22);
            textBoxColorHex_PC.TabIndex = 31;
            textBoxColorHex_PC.Text = "#000000";
            textBoxColorHex_PC.TextChanged += textBoxColorHex_PC_TextChanged;
            textBoxColorHex_PC.KeyDown += textBoxColorHex_PC_KeyDown;
            textBoxColorHex_PC.Validating += textBoxColorHex_PC_Validating;
            // 
            // panelPCColorGeneratedFrom
            // 
            panelPCColorGeneratedFrom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelPCColorGeneratedFrom.BorderStyle = BorderStyle.FixedSingle;
            panelPCColorGeneratedFrom.Location = new Point(221, 363);
            panelPCColorGeneratedFrom.Name = "panelPCColorGeneratedFrom";
            panelPCColorGeneratedFrom.Size = new Size(16, 16);
            panelPCColorGeneratedFrom.TabIndex = 20;
            // 
            // labelPCColorGeneratedFrom
            // 
            labelPCColorGeneratedFrom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelPCColorGeneratedFrom.AutoSize = true;
            labelPCColorGeneratedFrom.Font = new Font("Consolas", 8F);
            labelPCColorGeneratedFrom.Location = new Point(78, 364);
            labelPCColorGeneratedFrom.Name = "labelPCColorGeneratedFrom";
            labelPCColorGeneratedFrom.Size = new Size(143, 17);
            labelPCColorGeneratedFrom.TabIndex = 32;
            labelPCColorGeneratedFrom.Text = "Generated From: #123456";
            labelPCColorGeneratedFrom.UseCompatibleTextRendering = true;
            labelPCColorGeneratedFrom.Visible = false;
            // 
            // buttonRevertColor
            // 
            buttonRevertColor.Font = new Font("Segoe UI", 8.5F);
            buttonRevertColor.Location = new Point(82, 25);
            buttonRevertColor.Margin = new Padding(0);
            buttonRevertColor.Name = "buttonRevertColor";
            buttonRevertColor.Size = new Size(101, 20);
            buttonRevertColor.TabIndex = 33;
            buttonRevertColor.Text = "Undo Changes";
            buttonRevertColor.UseCompatibleTextRendering = true;
            buttonRevertColor.UseVisualStyleBackColor = true;
            buttonRevertColor.Click += buttonRevertColor_Click;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Consolas", 9F);
            labelHeader.Location = new Point(12, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(252, 14);
            labelHeader.TabIndex = 34;
            labelHeader.Text = "Editing 'From Palette' - Color 1/16";
            // 
            // panelHeaderColorORIG
            // 
            panelHeaderColorORIG.BorderStyle = BorderStyle.FixedSingle;
            panelHeaderColorORIG.Location = new Point(28, 27);
            panelHeaderColorORIG.Name = "panelHeaderColorORIG";
            panelHeaderColorORIG.Size = new Size(16, 16);
            panelHeaderColorORIG.TabIndex = 35;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(43, 27);
            label10.Name = "label10";
            label10.Size = new Size(17, 15);
            label10.TabIndex = 36;
            label10.Text = "→";
            // 
            // panelHeaderColorMOD
            // 
            panelHeaderColorMOD.BorderStyle = BorderStyle.FixedSingle;
            panelHeaderColorMOD.Location = new Point(59, 27);
            panelHeaderColorMOD.Name = "panelHeaderColorMOD";
            panelHeaderColorMOD.Size = new Size(16, 16);
            panelHeaderColorMOD.TabIndex = 36;
            // 
            // panelPictureBox
            // 
            panelPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPictureBox.BorderStyle = BorderStyle.Fixed3D;
            panelPictureBox.Controls.Add(pictureBoxColorField);
            panelPictureBox.Location = new Point(12, 49);
            panelPictureBox.Name = "panelPictureBox";
            panelPictureBox.Size = new Size(260, 260);
            panelPictureBox.TabIndex = 37;
            panelPictureBox.Paint += panelPictureBox_Paint;
            // 
            // buttonDbgBenchmark
            // 
            buttonDbgBenchmark.Location = new Point(270, 0);
            buttonDbgBenchmark.Name = "buttonDbgBenchmark";
            buttonDbgBenchmark.Size = new Size(119, 23);
            buttonDbgBenchmark.TabIndex = 38;
            buttonDbgBenchmark.Text = "[Debug]Benchmark";
            buttonDbgBenchmark.UseVisualStyleBackColor = true;
            buttonDbgBenchmark.Click += buttonDbgBenchmark_Click;
            // 
            // labelDbgBenchmarkResult
            // 
            labelDbgBenchmarkResult.AutoSize = true;
            labelDbgBenchmarkResult.Location = new Point(395, 4);
            labelDbgBenchmarkResult.Name = "labelDbgBenchmarkResult";
            labelDbgBenchmarkResult.Size = new Size(101, 15);
            labelDbgBenchmarkResult.TabIndex = 39;
            labelDbgBenchmarkResult.Text = "[DBG]XXXX colors";
            // 
            // comboBoxGraphMode
            // 
            comboBoxGraphMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGraphMode.FormattingEnabled = true;
            comboBoxGraphMode.Location = new Point(368, 47);
            comboBoxGraphMode.Name = "comboBoxGraphMode";
            comboBoxGraphMode.Size = new Size(155, 23);
            comboBoxGraphMode.TabIndex = 40;
            comboBoxGraphMode.SelectedIndexChanged += comboBoxGraphMode_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(305, 51);
            label9.Name = "label9";
            label9.Size = new Size(41, 15);
            label9.TabIndex = 41;
            label9.Text = "Mode:";
            // 
            // pixelPictureBoxGraphZ
            // 
            pixelPictureBoxGraphZ.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pixelPictureBoxGraphZ.BackColor = SystemColors.ControlDark;
            pixelPictureBoxGraphZ.Location = new Point(0, 0);
            pixelPictureBoxGraphZ.Name = "pixelPictureBoxGraphZ";
            pixelPictureBoxGraphZ.Size = new Size(20, 256);
            pixelPictureBoxGraphZ.SizeMode = PictureBoxSizeMode.StretchImage;
            pixelPictureBoxGraphZ.TabIndex = 42;
            pixelPictureBoxGraphZ.TabStop = false;
            pixelPictureBoxGraphZ.Paint += pixelPictureBoxGraphZ_Paint;
            pixelPictureBoxGraphZ.MouseDown += pixelPictureBoxGraphZ_MouseDown;
            pixelPictureBoxGraphZ.MouseMove += pixelPictureBoxGraphZ_MouseMove;
            // 
            // panelGraphZ
            // 
            panelGraphZ.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelGraphZ.BorderStyle = BorderStyle.Fixed3D;
            panelGraphZ.Controls.Add(pixelPictureBoxGraphZ);
            panelGraphZ.Location = new Point(273, 49);
            panelGraphZ.Name = "panelGraphZ";
            panelGraphZ.Size = new Size(24, 260);
            panelGraphZ.TabIndex = 43;
            // 
            // FormEditSingleColor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 392);
            Controls.Add(panelGraphZ);
            Controls.Add(label9);
            Controls.Add(comboBoxGraphMode);
            Controls.Add(labelDbgBenchmarkResult);
            Controls.Add(buttonDbgBenchmark);
            Controls.Add(panelPictureBox);
            Controls.Add(panelHeaderColorMOD);
            Controls.Add(panelHeaderColorORIG);
            Controls.Add(label10);
            Controls.Add(labelHeader);
            Controls.Add(buttonRevertColor);
            Controls.Add(labelPCColorGeneratedFrom);
            Controls.Add(panelPCColorGeneratedFrom);
            Controls.Add(textBoxColorHex_PC);
            Controls.Add(label8);
            Controls.Add(textBoxColorHex);
            Controls.Add(checkBoxUseHexForChannels);
            Controls.Add(numericUpDownLightness);
            Controls.Add(numericUpDownHue);
            Controls.Add(numericUpDownSaturation);
            Controls.Add(numericUpDownBlue);
            Controls.Add(numericUpDownGreen);
            Controls.Add(numericUpDownRed);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(panelColorSwatch);
            Controls.Add(trackBarLightness);
            Controls.Add(label5);
            Controls.Add(trackBarSaturation);
            Controls.Add(label6);
            Controls.Add(trackBarHue);
            Controls.Add(label7);
            Controls.Add(trackBarBlue);
            Controls.Add(label4);
            Controls.Add(trackBarGreen);
            Controls.Add(label3);
            Controls.Add(trackBarRed);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MinimumSize = new Size(551, 431);
            Name = "FormEditSingleColor";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Color";
            Activated += FormEditSingleColor_Activated;
            FormClosing += FormEditSingleColor_FormClosing;
            FormClosed += FormEditSingleColor_FormClosed;
            Load += FormEditSingleColor_Load;
            VisibleChanged += FormEditSingleColor_VisibleChanged;
            Click += FormEditSingleColor_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBoxColorField).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBlue).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarLightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarHue).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBlue).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHue).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLightness).EndInit();
            panelPictureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pixelPictureBoxGraphZ).EndInit();
            panelGraphZ.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PixelPictureBox pictureBoxColorField;
        private Label label1;
        private Label label2;
        private TrackBar trackBarRed;
        private Label label3;
        private TrackBar trackBarGreen;
        private Label label4;
        private TrackBar trackBarBlue;
        private TrackBar trackBarLightness;
        private Label label5;
        private TrackBar trackBarSaturation;
        private Label label6;
        private TrackBar trackBarHue;
        private Label label7;
        private System.Windows.Forms.Timer timerMouseHeld;
        private Panel panelColorSwatch;
        private Button buttonApply;
        private Button buttonCancel;
        private NumericUpDown numericUpDownRed;
        private NumericUpDown numericUpDownGreen;
        private NumericUpDown numericUpDownBlue;
        private NumericUpDown numericUpDownSaturation;
        private NumericUpDown numericUpDownHue;
        private NumericUpDown numericUpDownLightness;
        private CheckBox checkBoxUseHexForChannels;
        private TextBox textBoxColorHex;
        private Label label8;
        private TextBox textBoxColorHex_PC;
        private Panel panelPCColorGeneratedFrom;
        private Label labelPCColorGeneratedFrom;
        private Button buttonRevertColor;
        private Label labelHeader;
        private Panel panelHeaderColorORIG;
        private Label label10;
        private Panel panelHeaderColorMOD;
        private Panel panelPictureBox;
        private Button buttonDbgBenchmark;
        private Label labelDbgBenchmarkResult;
        private ComboBox comboBoxGraphMode;
        private Label label9;
        private PixelPictureBox pixelPictureBoxGraphZ;
        private Panel panelGraphZ;
    }
}