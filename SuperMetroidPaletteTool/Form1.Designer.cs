namespace SuperMetroidPaletteTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label2 = new Label();
            textBoxInputColor_FROM = new TextBox();
            numericUpDownSteps = new NumericUpDown();
            groupBoxFromColor = new GroupBox();
            panelFromColor = new Panel();
            comboBoxInterpolationType = new ComboBox();
            label1 = new Label();
            groupBoxOutput = new GroupBox();
            panelOutput = new Panel();
            labelOutputPanelDummyScroll = new Label();
            textBoxOutputAsm = new TextBox();
            checkBoxAssembleInput = new CheckBox();
            groupBoxToColor = new GroupBox();
            panelToColor = new Panel();
            textBoxInputColor_TO = new TextBox();
            buttonCopyFROMtoTO = new Button();
            buttonCopyTOtoFROM = new Button();
            label3 = new Label();
            buttonModifyFROM = new Button();
            buttonModifyTO = new Button();
            timerUpdateColor = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            trackBarCurvePower = new TrackBar();
            numericUpDownCurvePower = new NumericUpDown();
            checkBoxShowColorNums = new CheckBox();
            numericUpDownColorSquareSize = new NumericUpDown();
            label5 = new Label();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDownSteps).BeginInit();
            groupBoxFromColor.SuspendLayout();
            groupBoxOutput.SuspendLayout();
            panelOutput.SuspendLayout();
            groupBoxToColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarCurvePower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurvePower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColorSquareSize).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 161);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 3;
            label2.Text = "# Of Steps:";
            toolTip1.SetToolTip(label2, "Number of steps in the gradient.\r\nThis is number of rows in the output.\r\nUsing more rows in a palette gradient transition will make it look better but obviously take up more space in the ROM.");
            // 
            // textBoxInputColor_FROM
            // 
            textBoxInputColor_FROM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInputColor_FROM.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxInputColor_FROM.Location = new Point(267, 12);
            textBoxInputColor_FROM.Margin = new Padding(4);
            textBoxInputColor_FROM.Multiline = true;
            textBoxInputColor_FROM.Name = "textBoxInputColor_FROM";
            textBoxInputColor_FROM.ScrollBars = ScrollBars.Horizontal;
            textBoxInputColor_FROM.Size = new Size(894, 39);
            textBoxInputColor_FROM.TabIndex = 0;
            textBoxInputColor_FROM.Text = "7FFF, 7FFF, 7FFF, 7FFF, 1000, 56BA, 41B2, 1447, 0403, 4E15, 3570, 24CB, 1868, 6F7F, 51F8, 410E, 031F, 01DA, 00F5, 0C63";
            toolTip1.SetToolTip(textBoxInputColor_FROM, resources.GetString("textBoxInputColor_FROM.ToolTip"));
            textBoxInputColor_FROM.WordWrap = false;
            textBoxInputColor_FROM.TextChanged += textBoxInputColor_FROM_TextChanged;
            textBoxInputColor_FROM.KeyDown += textBoxInputColor_FROM_KeyDown;
            textBoxInputColor_FROM.KeyPress += textBoxInputColor_FROM_KeyPress;
            textBoxInputColor_FROM.Validating += textBoxInputColor_FROM_Validating;
            // 
            // numericUpDownSteps
            // 
            numericUpDownSteps.Location = new Point(78, 159);
            numericUpDownSteps.Maximum = new decimal(new int[] { 16384, 0, 0, 0 });
            numericUpDownSteps.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownSteps.Name = "numericUpDownSteps";
            numericUpDownSteps.Size = new Size(57, 23);
            numericUpDownSteps.TabIndex = 5;
            toolTip1.SetToolTip(numericUpDownSteps, "Number of steps in the gradient.\r\nThis is number of rows in the output.\r\nUsing more rows in a palette gradient transition will make it look better but obviously take up more space in the ROM.");
            numericUpDownSteps.Value = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDownSteps.ValueChanged += numericUpDownSteps_ValueChanged;
            // 
            // groupBoxFromColor
            // 
            groupBoxFromColor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxFromColor.Controls.Add(panelFromColor);
            groupBoxFromColor.Controls.Add(textBoxInputColor_FROM);
            groupBoxFromColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxFromColor.Location = new Point(8, 12);
            groupBoxFromColor.Name = "groupBoxFromColor";
            groupBoxFromColor.Size = new Size(1166, 56);
            groupBoxFromColor.TabIndex = 10;
            groupBoxFromColor.TabStop = false;
            groupBoxFromColor.Text = "From Palette";
            groupBoxFromColor.Paint += groupBoxFromColor_Paint;
            // 
            // panelFromColor
            // 
            panelFromColor.Cursor = Cursors.Hand;
            panelFromColor.Location = new Point(5, 15);
            panelFromColor.Margin = new Padding(0);
            panelFromColor.Name = "panelFromColor";
            panelFromColor.Size = new Size(256, 16);
            panelFromColor.TabIndex = 1;
            toolTip1.SetToolTip(panelFromColor, resources.GetString("panelFromColor.ToolTip"));
            panelFromColor.Paint += panelFromColor_Paint;
            panelFromColor.DoubleClick += panelFromColor_DoubleClick;
            panelFromColor.MouseClick += panelFromColor_MouseClick;
            panelFromColor.MouseDoubleClick += panelFromColor_MouseDoubleClick;
            panelFromColor.MouseDown += panelFromColor_MouseDown;
            panelFromColor.MouseMove += panelFromColor_MouseMove;
            panelFromColor.MouseUp += panelFromColor_MouseUp;
            // 
            // comboBoxInterpolationType
            // 
            comboBoxInterpolationType.FormattingEnabled = true;
            comboBoxInterpolationType.Items.AddRange(new object[] { "R, G, B", "H, S, L", "Entire Value" });
            comboBoxInterpolationType.Location = new Point(260, 159);
            comboBoxInterpolationType.Name = "comboBoxInterpolationType";
            comboBoxInterpolationType.Size = new Size(88, 23);
            comboBoxInterpolationType.TabIndex = 11;
            comboBoxInterpolationType.Text = "R, G, B";
            toolTip1.SetToolTip(comboBoxInterpolationType, resources.GetString("comboBoxInterpolationType.ToolTip"));
            comboBoxInterpolationType.SelectedValueChanged += comboBoxInterpolationType_SelectedValueChanged;
            comboBoxInterpolationType.Validating += comboBoxInterpolationType_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 161);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 12;
            label1.Text = "Interpolation Type:";
            toolTip1.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            // 
            // groupBoxOutput
            // 
            groupBoxOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxOutput.Controls.Add(panelOutput);
            groupBoxOutput.Controls.Add(textBoxOutputAsm);
            groupBoxOutput.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxOutput.Location = new Point(12, 182);
            groupBoxOutput.Name = "groupBoxOutput";
            groupBoxOutput.Size = new Size(1239, 295);
            groupBoxOutput.TabIndex = 23;
            groupBoxOutput.TabStop = false;
            groupBoxOutput.Text = "Output Palette List";
            // 
            // panelOutput
            // 
            panelOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelOutput.AutoScroll = true;
            panelOutput.Controls.Add(labelOutputPanelDummyScroll);
            panelOutput.Cursor = Cursors.Hand;
            panelOutput.Location = new Point(6, 15);
            panelOutput.Name = "panelOutput";
            panelOutput.Size = new Size(275, 274);
            panelOutput.TabIndex = 24;
            toolTip1.SetToolTip(panelOutput, resources.GetString("panelOutput.ToolTip"));
            panelOutput.Paint += panelOutput_Paint;
            panelOutput.MouseClick += panelOutput_MouseClick;
            panelOutput.MouseDoubleClick += panelOutput_MouseDoubleClick;
            panelOutput.MouseDown += panelOutput_MouseDown;
            panelOutput.MouseMove += panelOutput_MouseMove;
            panelOutput.MouseUp += panelOutput_MouseUp;
            // 
            // labelOutputPanelDummyScroll
            // 
            labelOutputPanelDummyScroll.Location = new Point(260, 0);
            labelOutputPanelDummyScroll.Name = "labelOutputPanelDummyScroll";
            labelOutputPanelDummyScroll.Size = new Size(1, 16);
            labelOutputPanelDummyScroll.TabIndex = 25;
            // 
            // textBoxOutputAsm
            // 
            textBoxOutputAsm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxOutputAsm.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxOutputAsm.Location = new Point(283, 15);
            textBoxOutputAsm.Margin = new Padding(4, 0, 4, 0);
            textBoxOutputAsm.Multiline = true;
            textBoxOutputAsm.Name = "textBoxOutputAsm";
            textBoxOutputAsm.ReadOnly = true;
            textBoxOutputAsm.ScrollBars = ScrollBars.Vertical;
            textBoxOutputAsm.Size = new Size(949, 273);
            textBoxOutputAsm.TabIndex = 5;
            textBoxOutputAsm.Text = "1000, 56BA, 41B2, 1447, 0403, 4E15, 3570, 24CB, 1868, 6F7F, 51F8, 410E, 031F, 01DA, 00F5, 0C63, ";
            toolTip1.SetToolTip(textBoxOutputAsm, resources.GetString("textBoxOutputAsm.ToolTip"));
            textBoxOutputAsm.WordWrap = false;
            // 
            // checkBoxAssembleInput
            // 
            checkBoxAssembleInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxAssembleInput.Enabled = false;
            checkBoxAssembleInput.FlatStyle = FlatStyle.Flat;
            checkBoxAssembleInput.Location = new Point(818, 67);
            checkBoxAssembleInput.Margin = new Padding(0);
            checkBoxAssembleInput.Name = "checkBoxAssembleInput";
            checkBoxAssembleInput.Size = new Size(261, 20);
            checkBoxAssembleInput.TabIndex = 2;
            checkBoxAssembleInput.Text = "[unused] Assemble Input Texts (uses asar)";
            checkBoxAssembleInput.TextAlign = ContentAlignment.TopLeft;
            checkBoxAssembleInput.UseVisualStyleBackColor = true;
            checkBoxAssembleInput.Visible = false;
            checkBoxAssembleInput.CheckedChanged += checkBoxAssembleInput_CheckedChanged;
            // 
            // groupBoxToColor
            // 
            groupBoxToColor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxToColor.Controls.Add(panelToColor);
            groupBoxToColor.Controls.Add(textBoxInputColor_TO);
            groupBoxToColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxToColor.Location = new Point(8, 82);
            groupBoxToColor.Name = "groupBoxToColor";
            groupBoxToColor.Size = new Size(1166, 56);
            groupBoxToColor.TabIndex = 23;
            groupBoxToColor.TabStop = false;
            groupBoxToColor.Text = "To Palette";
            groupBoxToColor.Paint += groupBoxToColor_Paint;
            // 
            // panelToColor
            // 
            panelToColor.Cursor = Cursors.Hand;
            panelToColor.Location = new Point(5, 15);
            panelToColor.Margin = new Padding(0);
            panelToColor.Name = "panelToColor";
            panelToColor.Size = new Size(256, 16);
            panelToColor.TabIndex = 2;
            toolTip1.SetToolTip(panelToColor, resources.GetString("panelToColor.ToolTip"));
            panelToColor.Paint += panelToColor_Paint;
            panelToColor.MouseClick += panelToColor_MouseClick;
            panelToColor.MouseDoubleClick += panelToColor_MouseDoubleClick;
            panelToColor.MouseDown += panelToColor_MouseDown;
            panelToColor.MouseMove += panelToColor_MouseMove;
            panelToColor.MouseUp += panelToColor_MouseUp;
            // 
            // textBoxInputColor_TO
            // 
            textBoxInputColor_TO.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInputColor_TO.BorderStyle = BorderStyle.FixedSingle;
            textBoxInputColor_TO.Font = new Font("Consolas", 8.25F);
            textBoxInputColor_TO.Location = new Point(267, 12);
            textBoxInputColor_TO.Margin = new Padding(4);
            textBoxInputColor_TO.Multiline = true;
            textBoxInputColor_TO.Name = "textBoxInputColor_TO";
            textBoxInputColor_TO.ScrollBars = ScrollBars.Horizontal;
            textBoxInputColor_TO.Size = new Size(894, 39);
            textBoxInputColor_TO.TabIndex = 1;
            textBoxInputColor_TO.Text = "0000, 0000, 0000, 0000, 0000, 4BBE, 06B9, 00A8, 0000, 173A, 0276, 01F2, 014D, 73E0, 4F20, 2A20, 7FE0, 5AA0, 5920, 0043";
            toolTip1.SetToolTip(textBoxInputColor_TO, resources.GetString("textBoxInputColor_TO.ToolTip"));
            textBoxInputColor_TO.WordWrap = false;
            textBoxInputColor_TO.TextChanged += textBoxInputColor_TO_TextChanged;
            textBoxInputColor_TO.KeyDown += textBoxInputColor_TO_KeyDown;
            textBoxInputColor_TO.KeyPress += textBoxInputColor_TO_KeyPress;
            textBoxInputColor_TO.Validating += textBoxInputColor_TO_Validating;
            // 
            // buttonCopyFROMtoTO
            // 
            buttonCopyFROMtoTO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCopyFROMtoTO.FlatStyle = FlatStyle.Flat;
            buttonCopyFROMtoTO.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCopyFROMtoTO.Location = new Point(1121, 69);
            buttonCopyFROMtoTO.Margin = new Padding(0);
            buttonCopyFROMtoTO.Name = "buttonCopyFROMtoTO";
            buttonCopyFROMtoTO.Size = new Size(18, 18);
            buttonCopyFROMtoTO.TabIndex = 3;
            buttonCopyFROMtoTO.Text = "↓";
            toolTip1.SetToolTip(buttonCopyFROMtoTO, "Copies the colors of one palette to the other, in the direction specified on the arrow icons.");
            buttonCopyFROMtoTO.UseCompatibleTextRendering = true;
            buttonCopyFROMtoTO.UseVisualStyleBackColor = true;
            buttonCopyFROMtoTO.Click += buttonCopyFROMtoTO_Click;
            // 
            // buttonCopyTOtoFROM
            // 
            buttonCopyTOtoFROM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCopyTOtoFROM.FlatStyle = FlatStyle.Flat;
            buttonCopyTOtoFROM.Location = new Point(1142, 69);
            buttonCopyTOtoFROM.Margin = new Padding(0);
            buttonCopyTOtoFROM.Name = "buttonCopyTOtoFROM";
            buttonCopyTOtoFROM.Size = new Size(18, 18);
            buttonCopyTOtoFROM.TabIndex = 4;
            buttonCopyTOtoFROM.Text = "↑";
            toolTip1.SetToolTip(buttonCopyTOtoFROM, "Copies the colors of one palette to the other, in the direction specified on the arrow icons.");
            buttonCopyTOtoFROM.UseCompatibleTextRendering = true;
            buttonCopyTOtoFROM.UseVisualStyleBackColor = true;
            buttonCopyTOtoFROM.Click += buttonCopyTOtoFROM_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(1082, 69);
            label3.Name = "label3";
            label3.Size = new Size(38, 18);
            label3.TabIndex = 24;
            label3.Text = "Copy:";
            toolTip1.SetToolTip(label3, "Copies the colors of one palette to the other, in the direction specified on the arrow icons.");
            // 
            // buttonModifyFROM
            // 
            buttonModifyFROM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonModifyFROM.Location = new Point(1180, 22);
            buttonModifyFROM.Name = "buttonModifyFROM";
            buttonModifyFROM.Size = new Size(71, 23);
            buttonModifyFROM.TabIndex = 25;
            buttonModifyFROM.Text = "Modify...";
            buttonModifyFROM.UseVisualStyleBackColor = true;
            buttonModifyFROM.Click += buttonModifyFROM_Click;
            // 
            // buttonModifyTO
            // 
            buttonModifyTO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonModifyTO.Location = new Point(1180, 76);
            buttonModifyTO.Name = "buttonModifyTO";
            buttonModifyTO.Size = new Size(71, 23);
            buttonModifyTO.TabIndex = 26;
            buttonModifyTO.Text = "Modify...";
            buttonModifyTO.UseVisualStyleBackColor = true;
            buttonModifyTO.Click += buttonModifyTO_Click;
            // 
            // timerUpdateColor
            // 
            timerUpdateColor.Enabled = true;
            timerUpdateColor.Interval = 16;
            timerUpdateColor.Tick += timerUpdateColor_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(367, 160);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 27;
            label4.Text = "Curve Easing:";
            toolTip1.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // trackBarCurvePower
            // 
            trackBarCurvePower.AutoSize = false;
            trackBarCurvePower.LargeChange = 100;
            trackBarCurvePower.Location = new Point(447, 157);
            trackBarCurvePower.Maximum = 4000;
            trackBarCurvePower.Minimum = -4000;
            trackBarCurvePower.Name = "trackBarCurvePower";
            trackBarCurvePower.Size = new Size(95, 27);
            trackBarCurvePower.SmallChange = 10;
            trackBarCurvePower.TabIndex = 28;
            trackBarCurvePower.TickFrequency = 500;
            toolTip1.SetToolTip(trackBarCurvePower, resources.GetString("trackBarCurvePower.ToolTip"));
            trackBarCurvePower.Scroll += trackBarCurvePower_Scroll;
            // 
            // numericUpDownCurvePower
            // 
            numericUpDownCurvePower.DecimalPlaces = 3;
            numericUpDownCurvePower.Location = new Point(544, 157);
            numericUpDownCurvePower.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
            numericUpDownCurvePower.Name = "numericUpDownCurvePower";
            numericUpDownCurvePower.Size = new Size(62, 23);
            numericUpDownCurvePower.TabIndex = 29;
            toolTip1.SetToolTip(numericUpDownCurvePower, resources.GetString("numericUpDownCurvePower.ToolTip"));
            numericUpDownCurvePower.ValueChanged += numericUpDownCurvePower_ValueChanged;
            // 
            // checkBoxShowColorNums
            // 
            checkBoxShowColorNums.AutoSize = true;
            checkBoxShowColorNums.Location = new Point(626, 140);
            checkBoxShowColorNums.Name = "checkBoxShowColorNums";
            checkBoxShowColorNums.Size = new Size(122, 19);
            checkBoxShowColorNums.TabIndex = 30;
            checkBoxShowColorNums.Text = "Show Color Nums";
            toolTip1.SetToolTip(checkBoxShowColorNums, "Shows the hexadecimal integer value of each color as an overlay over that color.\r\n\r\nThe color value 1234 will appear formatted like this on the color square:\r\n\r\n12\r\n34");
            checkBoxShowColorNums.UseVisualStyleBackColor = true;
            checkBoxShowColorNums.CheckedChanged += checkBoxShowColorNums_CheckedChanged;
            // 
            // numericUpDownColorSquareSize
            // 
            numericUpDownColorSquareSize.Location = new Point(733, 167);
            numericUpDownColorSquareSize.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDownColorSquareSize.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDownColorSquareSize.Name = "numericUpDownColorSquareSize";
            numericUpDownColorSquareSize.Size = new Size(71, 23);
            numericUpDownColorSquareSize.TabIndex = 31;
            numericUpDownColorSquareSize.Value = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDownColorSquareSize.ValueChanged += numericUpDownColorSquareSize_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(626, 169);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 32;
            label5.Text = "Color Square Size:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(1263, 489);
            Controls.Add(label5);
            Controls.Add(numericUpDownColorSquareSize);
            Controls.Add(checkBoxShowColorNums);
            Controls.Add(numericUpDownCurvePower);
            Controls.Add(trackBarCurvePower);
            Controls.Add(label4);
            Controls.Add(checkBoxAssembleInput);
            Controls.Add(buttonModifyTO);
            Controls.Add(buttonModifyFROM);
            Controls.Add(label3);
            Controls.Add(buttonCopyTOtoFROM);
            Controls.Add(buttonCopyFROMtoTO);
            Controls.Add(groupBoxToColor);
            Controls.Add(groupBoxOutput);
            Controls.Add(label1);
            Controls.Add(comboBoxInterpolationType);
            Controls.Add(groupBoxFromColor);
            Controls.Add(numericUpDownSteps);
            Controls.Add(label2);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(5000, 2000);
            MinimumSize = new Size(832, 440);
            Name = "Form1";
            Text = "Super Metroid Advanced Color Kit v1.00";
            Activated += Form1_Activated;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Click += Form1_Click;
            ((System.ComponentModel.ISupportInitialize)numericUpDownSteps).EndInit();
            groupBoxFromColor.ResumeLayout(false);
            groupBoxFromColor.PerformLayout();
            groupBoxOutput.ResumeLayout(false);
            groupBoxOutput.PerformLayout();
            panelOutput.ResumeLayout(false);
            groupBoxToColor.ResumeLayout(false);
            groupBoxToColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarCurvePower).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurvePower).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColorSquareSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBoxColors;
        private Label label2;
        private TextBox textBoxInputColor_FROM;
        private NumericUpDown numericUpDownSteps;
        private GroupBox groupBoxFromColor;
        private ComboBox comboBoxInterpolationType;
        private Label label1;
        private GroupBox groupBoxOutput;
        private TextBox textBoxOutputAsm;
        private Panel panelOutput;
        private CheckBox checkBoxAssembleInput;
        private GroupBox groupBoxToColor;
        private TextBox textBoxInputColor_TO;
        private Button buttonCopyFROMtoTO;
        private Button buttonCopyTOtoFROM;
        private Label label3;
        private Button buttonModifyFROM;
        private Button buttonModifyTO;
        private System.Windows.Forms.Timer timerUpdateColor;
        private Label labelOutputPanelDummyScroll;
        private Label label4;
        private TrackBar trackBarCurvePower;
        private NumericUpDown numericUpDownCurvePower;
        private Panel panelToColor;
        private Panel panelFromColor;
        private CheckBox checkBoxShowColorNums;
        private NumericUpDown numericUpDownColorSquareSize;
        private Label label5;
        private ToolTip toolTip1;
    }
}
