using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace SuperMetroidPaletteTool
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private const int WM_SETREDRAW = 0xB;

        public static void Suspend(Control target)
        {
            SendMessage(target.Handle, WM_SETREDRAW, 0, 0);
        }

        public static void Resume(Control target)
        {
            SendMessage(target.Handle, WM_SETREDRAW, 1, 0);
            target.Refresh();
        }

        private ColorLocation? ColorLocOfFocusedEditor = null;


        private Dictionary<ColorLocation, Form> ColorEditForms = new Dictionary<ColorLocation, Form>();

        public void UnregisterColorEditForm(Form f)
        {
            var matches = ColorEditForms.Where(x => x.Value == f).Select(x => x.Key).ToList();
            foreach (var m in matches)
            {
                ColorEditForms.Remove(m);
            }
        }

        public static string directory = null;
        //public static Form1 Form1Inst;
        public Form1()
        {
            InitializeComponent();

            var ass = typeof(Form1).Assembly;
            directory = new FileInfo(ass.Location).DirectoryName;

            var ver = ass.GetName().Version;

            Text = $"Super Metroid Advanced Color Kit v{ver.Major}.{ver.Minor}.{ver.Build}{(ver.Revision > 0 ? $"-{ver.Revision}" : "")}";

            int numColorPixels = (16 * 16);

            offset_panelOutput_Right = panelOutput.Right - numColorPixels;
            offset_textBoxOutputAsm_Left = textBoxOutputAsm.Left - numColorPixels;

            offset_textBoxInputColor_FROM_Left = textBoxInputColor_FROM.Left - numColorPixels;
            offset_textBoxInputColor_TO_Left = textBoxInputColor_TO.Left - numColorPixels;

            //offset_labelOutputPanelDummyScroll_X = labelOutputPanelDummyScroll.Left - numColorPixels;

            typeof(Panel).InvokeMember("DoubleBuffered",
               BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, panelFromColor, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
               BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, panelToColor, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
               BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, panelOutput, new object[] { true });

            this.SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
        }

        int offset_textBoxInputColor_FROM_Left;
        int offset_textBoxInputColor_TO_Left;

        int offset_panelOutput_Right;
        int offset_textBoxOutputAsm_Left;

        //int offset_labelOutputPanelDummyScroll_X;

        public static Point COLOR_SQUARE_SIZE = new Point(16, 16);
        public static int ROW_LENGTH = 16;

        public static bool SHOWING_COLOR_HEX = false;

        void ChangePaletteSizeAndLength(int newLength, Point colorSquareSize)
        {
            COLOR_SQUARE_SIZE = colorSquareSize;
            ROW_LENGTH = newLength;
            int numColorPixels = (COLOR_SQUARE_SIZE.X * newLength);

            panelFromColor.Width = numColorPixels;
            panelToColor.Width = numColorPixels;
            panelFromColor.Height = colorSquareSize.Y;
            panelToColor.Height = colorSquareSize.Y;

            int new_panelOutput_Right = numColorPixels + offset_panelOutput_Right;
            panelOutput.Size = new Size(new_panelOutput_Right - panelOutput.Left, panelOutput.Height);

            int new_textBoxOutputAsm_Left = numColorPixels + offset_textBoxOutputAsm_Left;
            textBoxOutputAsm.Size = new Size(textBoxOutputAsm.Right - new_textBoxOutputAsm_Left, textBoxOutputAsm.Height);
            textBoxOutputAsm.Location = new Point(new_textBoxOutputAsm_Left, textBoxOutputAsm.Top);

            int new_textBoxInputColor_FROM_Left = numColorPixels + offset_textBoxInputColor_FROM_Left;
            textBoxInputColor_FROM.Size = new Size(textBoxInputColor_FROM.Right - new_textBoxInputColor_FROM_Left, textBoxInputColor_FROM.Height);
            textBoxInputColor_FROM.Location = new Point(new_textBoxInputColor_FROM_Left, textBoxInputColor_FROM.Top);

            int new_textBoxInputColor_TO_Left = numColorPixels + offset_textBoxInputColor_TO_Left;
            textBoxInputColor_TO.Size = new Size(textBoxInputColor_TO.Right - new_textBoxInputColor_TO_Left, textBoxInputColor_TO.Height);
            textBoxInputColor_TO.Location = new Point(new_textBoxInputColor_TO_Left, textBoxInputColor_TO.Top);

            labelOutputPanelDummyScroll.Location = new Point(numColorPixels, labelOutputPanelDummyScroll.Top);

            Array.Resize(ref InputColors_FROM, newLength);
            Array.Resize(ref InputColors_TO, newLength);
            //Array.Resize(ref InputColorMask_FROM, newLength);
            //Array.Resize(ref InputColorMask_TO, newLength);
            Array.Resize(ref OutputColors, 0);

            FormModify_FROM?.ChangePaletteRowLength(newLength);
            FormModify_TO?.ChangePaletteRowLength(newLength);

            panelFromColor.Refresh();
            panelToColor.Refresh();
            panelOutput.Refresh();

            recalcOutputRequested = true;
        }

        // On these, false = enabled because thats default for bool
        //bool[] InputColorMask_FROM = new bool[16];
        //bool[] InputColorMask_TO = new bool[16];

        ushort[] InputColors_FROM = new ushort[16];
        ushort[] InputColors_TO = new ushort[16];
        ushort[] OutputColors = new ushort[0];



        public FormModify FormModify_TO = null;
        public FormModify FormModify_FROM = null;

        public static string GenerateAsmForColors_Multiline(ushort[] colors)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < colors.Length; i += ROW_LENGTH)
            {
                int thisLineLength = Math.Min(ROW_LENGTH, colors.Length - i);
                var meme = new ushort[thisLineLength];
                for (int j = 0; j < thisLineLength; j++)
                {
                    meme[j] = colors[i + j];
                }
                sb.AppendLine("dw " + string.Join(", ", meme.Select(c => $"${(c.ToString("X4"))}")));
            }
            return sb.ToString();
        }

        public static string GenerateAsmForColors(IEnumerable<ushort> colors)
        {
            return string.Join(", ", colors.Select(c => $"{(c.ToString("X4"))}"));
        }

        public static string GenerateAsmForColors_PC(IEnumerable<ushort> snesColors)
        {
            return string.Join(", ", snesColors.Select(c =>
            {
                var p = ColorMath.SNEStoPC(c);
                return $"#{(p.R.ToString("X2"))}{(p.G.ToString("X2"))}{(p.B.ToString("X2"))}";
            }));
        }

        private void numericUpDownColors_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ShowError(string errMsg, string title = null)
        {
            MessageBox.Show(errMsg, title ?? "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //private bool processExited = false;





        // Starts on second color (first color is given in the box on top of window)
        private ushort[] ProcessWholeGradient()
        {
            ColorMath.GradientTypes type = ColorMath.GradientTypes.EntireValue;
            if (comboBoxInterpolationType.Text == "R, G, B")
                type = ColorMath.GradientTypes.RGB;
            else if (comboBoxInterpolationType.Text == "H, S, L")
                type = ColorMath.GradientTypes.HSV;

            int count = (int)Math.Round(numericUpDownSteps.Value);

            ushort[] result = new ushort[count * ROW_LENGTH];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < ROW_LENGTH; j++)
                {
                    result[(i * ROW_LENGTH) + j] = ColorMath.GetGradientColor(InputColors_FROM[j], InputColors_TO[j], type, i, count, (float)numericUpDownCurvePower.Value);
                }
            }

            return result;
        }



        private object _lock_colors_FROM = new object();
        private object _lock_colors_TO = new object();
        private object _lock_colors_Output = new object();

        public static void GenerateInputColorSquares(Form parentForm, Control gb, ushort[] inputColors, int xOffset, int yOffset)
        {



            //foreach (var c in gb.Controls)
            //{
            //    if (c == textboxBackup)
            //        continue;
            //    (c as System.ComponentModel.Component)?.Dispose();
            //}
            parentForm.Invoke(() =>
            {



                if (gb.Controls.Count != (inputColors.Length + 1))
                {
                    var textboxBackup = gb.Controls.OfType<TextBox>().First();
                    gb.SuspendLayout();
                    var squares = GenerateColorSquares(parentForm, inputColors, xOffset, yOffset).ToArray();
                    foreach (var c in gb.Controls)
                    {
                        if (c == textboxBackup)
                            continue;
                        (c as System.ComponentModel.Component)?.Dispose();
                    }
                    gb.Controls.Clear();
                    gb.Controls.AddRange(squares);
                    gb.Controls.Add(textboxBackup);
                    gb.ResumeLayout();
                    gb.PerformLayout();
                }
                else
                {
                    for (int i = 0; i < inputColors.Length; i++)
                    {
                        gb.Controls[i].BackColor = ColorMath.SNEStoPC(inputColors[i]);
                    }
                    //var textboxBackup = gb.Controls.OfType<TextBox>().FirstOrDefault();
                    //var textboxIndex = gb.Controls.IndexOf(textboxBackup);
                    //if (textboxIndex != inputColors.Length)
                    //{
                    //    gb.Controls.Remove(textboxBackup);
                    //    gb.Controls.Add(textboxBackup);
                    //}
                }


            });

        }

        private static List<Label> GenerateColorSquares(Form parentForm, IEnumerable<ushort> colorsInput, int xOffset, int yOffset)
        {
            List<Label> result = new List<Label>();
            int x = 0;
            int y = 0;
            foreach (var c in colorsInput)
            {
                //parentForm.Invoke(() =>
                var label = new Label();
                label.Text = "";
                label.Margin = Padding.Empty;
                label.BackColor = ColorMath.SNEStoPC(c);
                label.BorderStyle = BorderStyle.None;
                label.AutoSize = false;
                label.Size = new Size(COLOR_SQUARE_SIZE.X, COLOR_SQUARE_SIZE.Y);
                label.Location = new Point(x + xOffset, y + yOffset);

                result.Add(label);

                x += COLOR_SQUARE_SIZE.X;
                if (x >= (COLOR_SQUARE_SIZE.X * ROW_LENGTH))
                {
                    x = 0;
                    y += COLOR_SQUARE_SIZE.Y;
                }
            }
            return result;
        }

        public static ushort[] AssembleInputString(string s, bool adjustRowLength, out int adjustedToRowLength)
        {
            adjustedToRowLength = 1;

            ushort[] result = new ushort[ROW_LENGTH];
            var processExited = false;

            //if (!File.Exists(textBoxInputColor_FROM.Text))
            //{
            //    //if (!isAutomatic)
            //    //    ShowError("Assembler EXE specified does not exist.");
            //    return new ushort[16];
            //}


            string asmFileName = $"{directory}\\TEMP\\Input.asm";
            string sfcFileName = $"{directory}\\TEMP\\Input.sfc";

            if (File.Exists(asmFileName))
            {
                File.Delete(asmFileName);
            }

            if (File.Exists(sfcFileName))
            {
                File.Delete(sfcFileName);
            }

            var workingDir = $"{directory}\\TEMP";

            if (!Directory.Exists(workingDir))
                Directory.CreateDirectory(workingDir);

            using (var asmFileStream = new FileStream(asmFileName, FileMode.Create, FileAccess.Write))
            {


                using (var asmFileWriter = new StreamWriter(asmFileStream))
                {
                    string input = s;

                    asmFileWriter.Write(input);
                    asmFileWriter.Flush();




                    var procStartInfo = new ProcessStartInfo();



                    procStartInfo.FileName = $"{directory}\\asar.exe";
                    procStartInfo.Arguments = $"--fix-checksum=off \"{asmFileName}\"";
                    procStartInfo.CreateNoWindow = true;
                    procStartInfo.UseShellExecute = false;
                    procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    procStartInfo.WorkingDirectory = workingDir;

                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.RedirectStandardError = true;

                    processExited = false;

                    var proc = new Process();
                    proc.EnableRaisingEvents = true;
                    proc.StartInfo = procStartInfo;
                    //proc.ErrorDataReceived += Proc_ErrorDataReceived;
                    //proc.OutputDataReceived += Proc_OutputDataReceived;
                    proc.Exited += (s, e) =>
                    {
                        processExited = true;
                    };
                    proc.Start();
                    proc.BeginOutputReadLine();
                    proc.BeginErrorReadLine();

                    var stopwatch = Stopwatch.StartNew();

                    bool failed = false;

                    //proc.WaitForExit();

                    while (!(processExited || proc.HasExited))
                    {
                        Thread.Sleep(16);
                        if (stopwatch.Elapsed.TotalMilliseconds > 1000)
                        {
                            failed = true;
                            break;
                        }
                    }

                    if (!failed && File.Exists(sfcFileName))
                    {
                        using (var sfcFileStream = new FileStream(sfcFileName, FileMode.Open, FileAccess.ReadWrite))
                        {


                            using (var sfcFileReader = new BinaryReader(sfcFileStream))
                            {
                                //long outputLength = sfcFileReader.BaseStream.Length;
                                //richTextBoxOutputReport.Text += $"File Length: 0x{(outputLength.ToString("X4"))}\n";
                                for (int i = 0; i < ROW_LENGTH || adjustRowLength; i++)
                                {
                                    if (sfcFileReader.BaseStream.Position <= (sfcFileReader.BaseStream.Length - 2))
                                    {
                                        if (result.Length <= i)
                                        {
                                            // Go up in chunks of 16
                                            Array.Resize(ref result, i + 16);
                                        }
                                        if (i >= adjustedToRowLength)
                                        {
                                            adjustedToRowLength = i + 1;
                                        }
                                        result[i] = sfcFileReader.ReadUInt16();

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                            }

                        }
                    }
                }




            }

            if (adjustRowLength)
            {
                // Trim off excess chunks
                Array.Resize(ref result, adjustedToRowLength);
            }

            return result;
        }

        public static ushort[] ManualParseInputString_PC(string s, bool adjustRowLength, out int adjustedToRowLength, out Color[] result_PC)
        {
            adjustedToRowLength = 1;
            ushort[] result = new ushort[ROW_LENGTH];
            result_PC = new Color[ROW_LENGTH];

            var tokens = s.Trim().Split(' ', ',', ':')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();
            int numberIndex = 0;

            foreach (var token in tokens)
            {
                var t = token;
                if (t.ToLower().StartsWith("0x"))
                {
                    t = t.Substring(2);
                }
                if (t.ToLower().StartsWith("$"))
                {
                    t = t.Substring(1);
                }
                if (t.ToUpper() == "DW")
                    continue;

                var chrs = t.ToCharArray();
                var sb = new StringBuilder();
                foreach (var c in chrs)
                {
                    if (Util_IsHexNumber(c))
                        sb.Append(c);
                    if (c == 'h' || c == 'H')
                        break;
                    if (sb.Length >= 6)
                        break;
                }
                var finalNumberString = sb.ToString();
                if (!string.IsNullOrWhiteSpace(finalNumberString))
                {
                    if (adjustRowLength && numberIndex >= result.Length)
                    {
                        // Go up in chunks of 16
                        Array.Resize(ref result, numberIndex + 16);
                        Array.Resize(ref result_PC, numberIndex + 16);
                    }

                    if (numberIndex >= adjustedToRowLength)
                    {
                        adjustedToRowLength = numberIndex + 1;
                    }

                    int number = int.Parse(finalNumberString, System.Globalization.NumberStyles.HexNumber);
                    byte r = (byte)((number >> 16) & 0xFF);
                    byte g = (byte)((number >> 8) & 0xFF);
                    byte b = (byte)((number) & 0xFF);
                    var colorPC = Color.FromArgb(r, g, b);

                    result[numberIndex] = ColorMath.PCtoSNES(colorPC);
                    result_PC[numberIndex] = colorPC;
                    numberIndex++;
                    if (numberIndex >= ROW_LENGTH && !adjustRowLength)
                        break;
                }
            }

            if (adjustRowLength)
            {
                // Trim off excess chunks
                Array.Resize(ref result, adjustedToRowLength);
                Array.Resize(ref result_PC, adjustedToRowLength);
            }

            return result;
        }

        public static ushort[] ManualParseInputString(string s, bool adjustRowLength, out int adjustedToRowLength)
        {
            adjustedToRowLength = 1;
            ushort[] result = new ushort[ROW_LENGTH];

            var tokens = s.Trim().Split(' ', ',', ':')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();
            int numberIndex = 0;

            foreach (var token in tokens)
            {
                var t = token;
                if (t.ToLower().StartsWith("0x"))
                {
                    t = t.Substring(2);
                }
                if (t.ToLower().StartsWith("$"))
                {
                    t = t.Substring(1);
                }
                if (t.ToUpper() == "DW")
                    continue;

                var chrs = t.ToCharArray();
                var sb = new StringBuilder();
                foreach (var c in chrs)
                {
                    if (Util_IsHexNumber(c))
                        sb.Append(c);
                    if (c == 'h' || c == 'H')
                        break;
                    if (sb.Length >= 4)
                        break;
                }
                var finalNumberString = sb.ToString();
                if (!string.IsNullOrWhiteSpace(finalNumberString))
                {
                    if (adjustRowLength && numberIndex >= result.Length)
                    {
                        // Go up in chunks of 16
                        Array.Resize(ref result, numberIndex + 16);
                    }

                    if (numberIndex >= adjustedToRowLength)
                    {
                        adjustedToRowLength = numberIndex + 1;
                    }

                    ushort number = ushort.Parse(finalNumberString, System.Globalization.NumberStyles.HexNumber);
                    result[numberIndex] = number;
                    numberIndex++;
                    if (numberIndex >= ROW_LENGTH && !adjustRowLength)
                        break;
                }
            }

            if (adjustRowLength)
            {
                // Trim off excess chunks
                Array.Resize(ref result, adjustedToRowLength);
            }

            return result;
        }

        private void AssembleInputText_FROM()
        {
            if (false && checkBoxAssembleInput.Checked)
            {
                InputColors_FROM = AssembleInputString(textBoxInputColor_FROM.Text, adjustRowLength: true, out int adjustedRowLength);
                ChangePaletteSizeAndLength(adjustedRowLength, COLOR_SQUARE_SIZE);
            }
            else
            {
                InputColors_FROM = ManualParseInputString(textBoxInputColor_FROM.Text, adjustRowLength: true, out int adjustedRowLength);
                string txt = GenerateAsmForColors(InputColors_FROM);
                textBoxInputColor_FROM.Text = txt;
                textBoxInputColor_FROM.SelectionStart = 0;
                textBoxInputColor_FROM.SelectionLength = 0;
                textBoxInputColor_FROM.SelectionStart = txt.Length;
                textBoxInputColor_FROM.SelectionLength = 0;
                textBoxInputColor_FROM.Refresh();
                ChangePaletteSizeAndLength(adjustedRowLength, COLOR_SQUARE_SIZE);
            }

            panelFromColor.Refresh();

            RequestRecalcOutput();

            //GenerateInputColorSquares(this, groupBoxFromColor, InputColors_FROM, xOffset: 3, yOffset: 15);
        }

        private void AssembleInputText_TO()
        {
            if (false && checkBoxAssembleInput.Checked)
            {
                InputColors_TO = AssembleInputString(textBoxInputColor_TO.Text, adjustRowLength: false, out _);
            }
            else
            {
                InputColors_TO = ManualParseInputString(textBoxInputColor_TO.Text, adjustRowLength: false, out _);
                string txt = GenerateAsmForColors(InputColors_TO);
                textBoxInputColor_TO.Text = txt;
                textBoxInputColor_TO.SelectionStart = 0;
                textBoxInputColor_TO.SelectionLength = 0;
                textBoxInputColor_TO.SelectionStart = txt.Length;
                textBoxInputColor_TO.SelectionLength = 0;
                textBoxInputColor_TO.Refresh();
            }

            panelToColor.Refresh();

            RequestRecalcOutput();

            //GenerateInputColorSquares(this, groupBoxToColor, InputColors_TO, xOffset: 3, yOffset: 15);
        }

        public static bool Util_IsHexNumber(char c)
        {
            return c == '0' || (c >= '1' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxAssembleInput_CheckedChanged(object sender, EventArgs e)
        {
            textBoxInputColor_FROM.Text = "";
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            numericUpDownSteps.Focus();
            Focus();
        }

        private void textBoxInputColor_FROM_TextChanged(object sender, EventArgs e)
        {
            if (textBoxInputColor_FROM.Text.Contains('\n') || textBoxInputColor_FROM.Text.Contains('\t'))
            {
                var txt = textBoxInputColor_FROM.Text.Replace("\n", "").Replace("\t", "");
                textBoxInputColor_FROM.Text = txt;
                textBoxInputColor_FROM.SelectionStart = 0;
                textBoxInputColor_FROM.SelectionLength = 0;
                textBoxInputColor_FROM.SelectionStart = txt.Length;
                textBoxInputColor_FROM.SelectionLength = 0;
                textBoxInputColor_FROM.Refresh();
            }

        }

        private void textBoxInputColor_FROM_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lock (_lock_colors_FROM)
            {
                AssembleInputText_FROM();
            }
        }

        private void textBoxInputColor_TO_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lock (_lock_colors_TO)
            {
                AssembleInputText_TO();
            }
        }

        private void buttonCopyFROMtoTO_Click(object sender, EventArgs e)
        {
            lock (_lock_colors_FROM)
            {
                var text = GenerateAsmForColors(InputColors_FROM);
                textBoxInputColor_TO.Text = text;
                textBoxInputColor_TO.Select(text.Length, 0);
                AssembleInputText_TO();
            }
        }

        private void buttonCopyTOtoFROM_Click(object sender, EventArgs e)
        {
            lock (_lock_colors_TO)
            {
                var text = GenerateAsmForColors(InputColors_TO);
                textBoxInputColor_FROM.Text = text;
                textBoxInputColor_FROM.Select(text.Length, 0);
                AssembleInputText_FROM();
            }


        }

        private void buttonModifyFROM_Click(object sender, EventArgs e)
        {
            if (FormModify_FROM == null || FormModify_FROM.IsDisposed)
            {
                FormModify_FROM = new FormModify();
                FormModify_FROM.InitColors(FormModify.ModifyFormTypes.ModifyingInput_FROM,
                    "Modify 'FROM' Color", InputColors_FROM, new bool[InputColors_FROM.Length], this);
                FormModify_FROM.Show(this);
            }
        }

        private void buttonModifyTO_Click(object sender, EventArgs e)
        {
            if (FormModify_TO == null || FormModify_TO.IsDisposed)
            {
                FormModify_TO = new FormModify();
                FormModify_TO.InitColors(FormModify.ModifyFormTypes.ModifyingInput_TO,
                    "Modify 'TO' Color", InputColors_TO, new bool[InputColors_TO.Length], this);
                FormModify_TO.Show(this);
            }
        }

        bool recalcOutputRequested = false;
        bool recalcOutputBusy = false;

        public void RequestRecalcOutput(ushort[] setNewColors_FROM = null, ushort[] setNewColors_TO = null)
        {

            //SynchronousColorsUpdate();
            //AsynchronousColorUpdate();

            if (setNewColors_FROM != null || setNewColors_TO != null)
            {
                var captureNewColors_FROM = setNewColors_FROM?.ToArray();
                var captureNewColors_TO = setNewColors_TO?.ToArray();
                Invoke(() =>
                {
                    if (captureNewColors_FROM != null)
                    {
                        InputColors_FROM = captureNewColors_FROM;
                        textBoxInputColor_FROM.Text = GenerateAsmForColors(InputColors_FROM);
                        panelFromColor.Refresh();
                    }
                    if (captureNewColors_TO != null)
                    {
                        InputColors_TO = captureNewColors_TO;
                        textBoxInputColor_TO.Text = GenerateAsmForColors(InputColors_TO);
                        panelToColor.Refresh();
                    }
                });
            }

            recalcOutputRequested = true;
        }

        private void timerUpdateColor_Tick(object sender, EventArgs e)
        {
            if (recalcOutputRequested && !recalcOutputBusy)
            {
                recalcOutputRequested = false;
                RecalculateOutput();
            }
        }

        static Font colorHexOverlayFont = null;

        public static void DrawColorsOnGraphics(Graphics g, ushort[] colors, bool[] mask,
            int xOffset, int yOffset, int highlightColorIndex, int highlightColorRowIndex)
        {
            if (colorHexOverlayFont == null)
            {
                colorHexOverlayFont = new Font("Consolas", 8);
            }
            colorHexOverlayFont?.Dispose();
            colorHexOverlayFont = new Font("Consolas", 7, FontStyle.Bold);
            int x = 0;
            int y = 0;

            //var brush = new SolidBrush(Color.White);
            //var pen = new Pen(brush);

            Rectangle? highlightRect = null;
            Color? highlightColor = null;

            for (int i = 0; i < colors.Length; i++)
            {
                var c = colors[i];

                //brush.Color = SnesColorToWinformsColor(c);
                //brush.Color = SnesColorToWinformsColor(c);
                using (var br = new SolidBrush(ColorMath.SNEStoPC(c)))
                {
                    g.FillRectangle(br, x + xOffset, y + yOffset, COLOR_SQUARE_SIZE.X, COLOR_SQUARE_SIZE.Y);
                }

                int tx = x + xOffset;
                int ty = y + yOffset - 2;

                var vec = ColorMath.SNEStoVEC3(c);
                var hsl = ColorMath.RGBtoHSL(vec);

                if (SHOWING_COLOR_HEX)
                {

                    var boxColor = ColorMath.GetApparentBrightness(vec) >= 0.5f ? Color.Black : Color.White;

                    //var txtColor = hsl.Z >= 0.5f ? Color.Black : Color.White

                    float lightessDistFromCenter = MathF.Abs(hsl.Z - 0.5f);

                    if (lightessDistFromCenter < 0.3f)
                        lightessDistFromCenter = 0.3f;

                    if (lightessDistFromCenter > 0.4f)
                        lightessDistFromCenter = 0.4f;

                    if (ColorMath.GetApparentBrightness(vec) >= 0.5f)
                        hsl.Z = 0.5f - lightessDistFromCenter;
                    else
                        hsl.Z = 0.5f + lightessDistFromCenter;

                    hsl.Y *= 1.5f;

                    vec = ColorMath.HSLtoRGB(hsl);
                    var txtColor = ColorMath.VEC3toPC(vec);



                    using (var br2 = new SolidBrush(txtColor))
                    {
                        var hex = c.ToString("X4");
                        g.DrawString(hex.Substring(0, 2), colorHexOverlayFont, br2, tx, ty);
                        g.DrawString(hex.Substring(2, 2), colorHexOverlayFont, br2, tx, ty + (COLOR_SQUARE_SIZE.Y / 2) - 1);
                    }

                    using (var br3 = new Pen(txtColor))
                    {
                        g.DrawRectangle(br3, x + xOffset, y + yOffset, COLOR_SQUARE_SIZE.X - 1, COLOR_SQUARE_SIZE.Y - 1);
                    }
                }

                if (highlightColorIndex == i)
                {
                    highlightRect = new Rectangle(x + xOffset, y + yOffset, COLOR_SQUARE_SIZE.X - 1, COLOR_SQUARE_SIZE.Y - 1);
                    highlightColor = ColorMath.GetApparentBrightness(vec) >= 0.5f ? Color.Black : Color.White;
                }


                x += COLOR_SQUARE_SIZE.X;
                if (x >= (COLOR_SQUARE_SIZE.X * ROW_LENGTH))
                {
                    x = 0;
                    y += COLOR_SQUARE_SIZE.Y;
                }

            }

            x = 0;
            y = 0;

            if (mask != null)
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    if (mask[i])
                    {
                        using (var p2 = new Pen(Color.Red, 2))
                        {
                            g.DrawLine(p2, new Point(x + xOffset, y + yOffset), new Point(x + xOffset + COLOR_SQUARE_SIZE.X, y + yOffset + COLOR_SQUARE_SIZE.Y));
                            g.DrawLine(p2, new Point(x + xOffset, y + yOffset + COLOR_SQUARE_SIZE.Y), new Point(x + xOffset + COLOR_SQUARE_SIZE.X, y + yOffset));
                        }

                        using (var p = new Pen(Color.Red, 1))
                        {
                            g.DrawRectangle(p, x + xOffset, y + yOffset, COLOR_SQUARE_SIZE.X, COLOR_SQUARE_SIZE.Y);
                        }


                    }



                    x += COLOR_SQUARE_SIZE.X;
                    if (x >= (COLOR_SQUARE_SIZE.X * ROW_LENGTH))
                    {
                        x = 0;
                        y += COLOR_SQUARE_SIZE.Y;
                    }

                }
            }

            if (highlightRect.HasValue && highlightColor.HasValue)
            {
                using (var br3 = new Pen(highlightColor.Value, 3))
                {
                    g.DrawRectangle(br3, highlightRect.Value);
                }
            }

            int rowCount = colors.Length / ROW_LENGTH;
            if (highlightColorRowIndex >= 0 && highlightColorRowIndex < rowCount)
            {
                using (var br3 = new Pen(Color.Black, 3))
                {
                    g.DrawRectangle(br3, xOffset,
                        (highlightColorRowIndex * COLOR_SQUARE_SIZE.Y) + yOffset,
                        COLOR_SQUARE_SIZE.X * ROW_LENGTH, COLOR_SQUARE_SIZE.Y);
                }
            }
        }

        private void groupBoxFromColor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBoxToColor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelOutput_Paint(object sender, PaintEventArgs e)
        {
            lock (_lock_colors_Output)
            {
                int highlightColorIndex = -1;
                int highlightRowIndex = -1;
                if (ColorLocOfFocusedEditor.HasValue && ColorLocOfFocusedEditor.Value.LocationType == ColorLocation.ColorLocationTypes.Output)
                {
                    if (ColorLocOfFocusedEditor.Value.Index >= 0)
                        highlightColorIndex = ColorLocOfFocusedEditor.Value.Index;
                    else
                        highlightRowIndex = (-1) - ColorLocOfFocusedEditor.Value.Index;
                }
                DrawColorsOnGraphics(e.Graphics, OutputColors, null,
                    -panelOutput.HorizontalScroll.Value, -panelOutput.VerticalScroll.Value,
                    highlightColorIndex, highlightRowIndex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lock (_lock_colors_FROM)
            {
                AssembleInputText_FROM();
            }

            lock (_lock_colors_TO)
            {
                AssembleInputText_TO();
            }
        }

        private void vScrollBarOutput_Scroll(object sender, ScrollEventArgs e)
        {
            panelOutput.Refresh();
        }

        private void panelOutputScroll_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Delta != 0)
            //{
            //    Console.WriteLine($"{e.Delta}");
            //}
        }

        private void panelOutputScroll_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Delta != 0)
            //{
            //    Console.WriteLine($"{e.Delta}");
            //}
        }

        private void panelOutputScroll_Scroll(object sender, ScrollEventArgs e)
        {
            //Console.WriteLine("test");
        }

        private void RecalculateOutput()
        {
            int count = (int)Math.Round(numericUpDownSteps.Value);

            var colors = ProcessWholeGradient();




            //textBoxOutputAsm.Size = new Size(textBoxOutputAsm.Size.Width, 16 * count);

            string text = GenerateAsmForColors_Multiline(colors);

            Invoke(() =>
            {
                Suspend(textBoxOutputAsm);
                textBoxOutputAsm.Text = text;
                Resume(textBoxOutputAsm);
            });
            //GenerateInputColorSquares(this, panelOutput, colors, xOffset: 0, yOffset: 0);
            lock (_lock_colors_Output)
            {
                OutputColors = colors;
                //panelOutput.Height = 16 * count;
                labelOutputPanelDummyScroll.Height = COLOR_SQUARE_SIZE.Y * count;
                //int scrollMax = (panelOutput.Height - panelOutputScroll.Height);
                //if (scrollMax < 0)
                //    scrollMax = 0;
                //vScrollBarOutput.Maximum = scrollMax;
            }

            panelOutput.Refresh();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private void trackBarCurvePower_Scroll(object sender, EventArgs e)
        {
            var newVal = (trackBarCurvePower.Value / (decimal)1000.0);
            if (newVal < numericUpDownCurvePower.Minimum)
                newVal = numericUpDownCurvePower.Minimum;
            if (newVal > numericUpDownCurvePower.Maximum)
                newVal = numericUpDownCurvePower.Maximum;
            numericUpDownCurvePower.Value = newVal;

            DoubleBuffered = true;

            //typeof(Panel).InvokeMember("DoubleBuffered",
            //   BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            //   null, panelOutput, new object[] { true });

            //typeof(TextBox).InvokeMember("DoubleBuffered",
            //   BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            //   null, textBoxOutputAsm, new object[] { true });

            //textBoxOutputAsm.Update();
            //textBoxOutputAsm.Refresh();

            // Do not need RecalculateOutput because numericUpDownCurvePower_ValueChanged will be called here.
        }

        private void numericUpDownCurvePower_ValueChanged(object sender, EventArgs e)
        {
            var newVal = (int)Math.Round(numericUpDownCurvePower.Value * (decimal)1000.0);
            if (newVal < trackBarCurvePower.Minimum)
                newVal = trackBarCurvePower.Minimum;
            if (newVal > trackBarCurvePower.Maximum)
                newVal = trackBarCurvePower.Maximum;
            trackBarCurvePower.Value = newVal;
            RequestRecalcOutput();
        }

        private void comboBoxInterpolationType_SelectedValueChanged(object sender, EventArgs e)
        {
            RequestRecalcOutput();
        }

        private void numericUpDownSteps_ValueChanged(object sender, EventArgs e)
        {
            RequestRecalcOutput();
        }

        private void textBoxInputColor_TO_HScroll(object sender, EventArgs e)
        {
            //textBoxInputColor_TO.Update();
        }

        private void panelFromColor_Paint(object sender, PaintEventArgs e)
        {
            lock (_lock_colors_FROM)
            {
                int highlightColorIndex = -1;
                int highlightRowIndex = -1;
                if (ColorLocOfFocusedEditor.HasValue && ColorLocOfFocusedEditor.Value.LocationType == ColorLocation.ColorLocationTypes.InputFROM)
                {
                    if (ColorLocOfFocusedEditor.Value.Index >= 0)
                        highlightColorIndex = ColorLocOfFocusedEditor.Value.Index;
                    else
                        highlightRowIndex = (-1) - ColorLocOfFocusedEditor.Value.Index;
                }

                DrawColorsOnGraphics(e.Graphics, InputColors_FROM, null, 0, 0,
                    highlightColorIndex, highlightRowIndex);
            }
        }

        private void panelToColor_Paint(object sender, PaintEventArgs e)
        {
            lock (_lock_colors_TO)
            {
                int highlightColorIndex = -1;
                int highlightRowIndex = -1;
                if (ColorLocOfFocusedEditor.HasValue && ColorLocOfFocusedEditor.Value.LocationType == ColorLocation.ColorLocationTypes.InputTO)
                {
                    if (ColorLocOfFocusedEditor.Value.Index >= 0)
                        highlightColorIndex = ColorLocOfFocusedEditor.Value.Index;
                    else
                        highlightRowIndex = (-1) - ColorLocOfFocusedEditor.Value.Index;
                }

                DrawColorsOnGraphics(e.Graphics, InputColors_TO, null, 0, 0,
                    highlightColorIndex, highlightRowIndex);
            }
        }

        public void SetColorByLocation(ColorLocation colorLoc, ushort color)
        {
            int index = colorLoc.Index;
            if (index < 0)
                return;
            if (colorLoc.LocationType is ColorLocation.ColorLocationTypes.InputFROM)
            {
                lock (_lock_colors_FROM)
                {
                    if (index < InputColors_FROM.Length)
                    {
                        InputColors_FROM[index] = color;
                        panelFromColor.Refresh();
                        textBoxInputColor_FROM.Text = GenerateAsmForColors(InputColors_FROM);
                        textBoxInputColor_FROM.Refresh();
                        RecalculateOutput();
                    }
                }
            }
            else if (colorLoc.LocationType is ColorLocation.ColorLocationTypes.InputTO)
            {
                lock (_lock_colors_TO)
                {
                    if (index < InputColors_TO.Length)
                    {
                        InputColors_TO[index] = color;
                        panelToColor.Refresh();
                        textBoxInputColor_TO.Text = GenerateAsmForColors(InputColors_TO);
                        textBoxInputColor_TO.Refresh();
                        RecalculateOutput();
                    }
                }
            }
            else if (colorLoc.LocationType is ColorLocation.ColorLocationTypes.Output)
            {
                lock (_lock_colors_Output)
                {
                    if (index < OutputColors.Length)
                    {
                        OutputColors[index] = color;
                        panelOutput.Refresh();
                        textBoxOutputAsm.Text = GenerateAsmForColors_Multiline(OutputColors);
                        textBoxOutputAsm.Refresh();
                    }
                }
            }
        }



        private void comboBoxInterpolationType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var validItems = comboBoxInterpolationType.Items.OfType<string>().ToList();
            if (!validItems.Contains(comboBoxInterpolationType.Text))
            {
                e.Cancel = true;
                comboBoxInterpolationType.SelectedIndex = 0;
            }
        }

        private void checkBoxShowColorNums_CheckedChanged(object sender, EventArgs e)
        {
            SHOWING_COLOR_HEX = checkBoxShowColorNums.Checked;
            panelFromColor.Refresh();
            panelToColor.Refresh();
            panelOutput.Refresh();
        }

        private void numericUpDownColorSquareSize_ValueChanged(object sender, EventArgs e)
        {
            int v = (int)Math.Round(numericUpDownColorSquareSize.Value);
            //if (v % 2 != 0)
            //{
            //    numericUpDown1.Value = v + 1;
            //}
            ChangePaletteSizeAndLength(ROW_LENGTH, new Point(v, v));
        }

        private void textBoxInputColor_FROM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                lock (_lock_colors_FROM)
                {
                    AssembleInputText_FROM();
                }
            }

            if (e.KeyCode is Keys.Return or Keys.Tab)
                e.Handled = true;
        }

        private void textBoxInputColor_TO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                lock (_lock_colors_TO)
                {
                    AssembleInputText_TO();
                }
            }

            if (e.KeyCode is Keys.Return or Keys.Tab)
                e.Handled = true;
        }


        public void SetColorLocOfFocusedEditor(ColorLocation? colorLoc)
        {
            ColorLocOfFocusedEditor = colorLoc;
            panelFromColor.Refresh();
            panelToColor.Refresh();
            panelOutput.Refresh();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            SetColorLocOfFocusedEditor(null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Properties.Settings.Default.NeverAskToConfirmQuit)
            {
                e.Cancel = true;
                var form = new FormAskToClose();
                if (form.ShowDialog(this) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
            }
            Properties.Settings.Default.Save();
        }

        private void panelFromColor_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panelFromColor_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panelFromColor_MouseMove(object sender, MouseEventArgs e)
        {

        }




        private void panelToColor_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panelToColor_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panelToColor_MouseMove(object sender, MouseEventArgs e)
        {

        }




        private void panelOutput_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panelOutput_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panelOutput_MouseMove(object sender, MouseEventArgs e)
        {

        }

        public Point GetColorMenuSpawnLocation(ColorLocation.ColorLocationTypes locType)
        {
            if (locType is ColorLocation.ColorLocationTypes.InputFROM)
            {
                return new Point(Left + groupBoxFromColor.Left, Top + groupBoxFromColor.Bottom + 16);
            }
            else if (locType is ColorLocation.ColorLocationTypes.InputTO)
            {
                return new Point(Left + groupBoxToColor.Left, Top + groupBoxToColor.Bottom + 16);
            }
            else if (locType is ColorLocation.ColorLocationTypes.Output)
            {
                return new Point(Left + groupBoxOutput.Left + textBoxOutputAsm.Left + 16, Top + groupBoxOutput.Top + textBoxOutputAsm.Top + 16);
            }
            else
            {
                throw new NotImplementedException();
            }

        }

        private void textBoxInputColor_FROM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\t')
                e.Handled = true;
        }

        private void textBoxInputColor_TO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\t')
                e.Handled = true;
        }

        private void textBoxInputColor_TO_TextChanged(object sender, EventArgs e)
        {
            if (textBoxInputColor_TO.Text.Contains('\n') || textBoxInputColor_TO.Text.Contains('\t'))
            {
                var txt = textBoxInputColor_TO.Text.Replace("\n", "").Replace("\t", "");
                textBoxInputColor_TO.Text = txt;
                textBoxInputColor_TO.SelectionStart = 0;
                textBoxInputColor_TO.SelectionLength = 0;
                textBoxInputColor_TO.SelectionStart = txt.Length;
                textBoxInputColor_TO.SelectionLength = 0;
                textBoxInputColor_TO.Refresh();
            }
        }

        private void panelFromColor_DoubleClick(object sender, EventArgs e)
        {

        }

        private void panelFromColor_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            int ix = e.X / Form1.COLOR_SQUARE_SIZE.X;
            int iy = e.Y / Form1.COLOR_SQUARE_SIZE.Y;
            if (ix >= 0 && iy >= 0 && ix < Form1.ROW_LENGTH)
            {
                int i = (iy * Form1.ROW_LENGTH) + ix;

                if (i >= 0 && i < InputColors_FROM.Length)
                {
                    var colorLoc = new ColorLocation()
                    {
                        LocationType = ColorLocation.ColorLocationTypes.InputFROM,
                        Index = i,
                    };

                    if (ColorEditForms.ContainsKey(colorLoc))
                    {
                        ColorEditForms[colorLoc].Close();
                        //ColorEditForms[colorLoc].Location = GetColorMenuSpawnLocation(colorLoc.LocationType);
                        //ColorEditForms[colorLoc].Activate();
                    }
                    else
                    {
                        var formsToClose = ColorEditForms.ToList();
                        foreach (var kvp in formsToClose)
                        {
                            kvp.Value.Close();
                        }

                        var form = new FormEditSingleColor();
                        ColorEditForms[colorLoc] = form;
                        form.InitSetColor(this, colorLoc, InputColors_FROM[i], $"'From Palette' - Color {(i + 1)}/{ROW_LENGTH}");
                        form.Show(this);
                    }

                }
            }

        }

        private void panelToColor_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            int ix = e.X / Form1.COLOR_SQUARE_SIZE.X;
            int iy = e.Y / Form1.COLOR_SQUARE_SIZE.Y;
            if (ix >= 0 && iy >= 0 && ix < Form1.ROW_LENGTH)
            {
                int i = (iy * Form1.ROW_LENGTH) + ix;

                if (i >= 0 && i < InputColors_TO.Length)
                {
                    var colorLoc = new ColorLocation()
                    {
                        LocationType = ColorLocation.ColorLocationTypes.InputTO,
                        Index = i,
                    };



                    if (ColorEditForms.ContainsKey(colorLoc))
                    {
                        ColorEditForms[colorLoc].Close();
                        //ColorEditForms[colorLoc].Location = GetColorMenuSpawnLocation(colorLoc.LocationType);
                        //ColorEditForms[colorLoc].Activate();
                    }
                    else
                    {
                        var formsToClose = ColorEditForms.ToList();
                        foreach (var kvp in formsToClose)
                        {
                            kvp.Value.Close();
                        }

                        var form = new FormEditSingleColor();
                        ColorEditForms[colorLoc] = form;
                        form.InitSetColor(this, colorLoc, InputColors_TO[i], $"'To Palette' - Color {(i + 1)}/{ROW_LENGTH}");
                        form.Show(this);
                    }
                }
            }
        }
        private void panelOutput_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            int ix = e.X / Form1.COLOR_SQUARE_SIZE.X;
            int iy = e.Y / Form1.COLOR_SQUARE_SIZE.Y;
            if (ix >= 0 && iy >= 0 && ix < Form1.ROW_LENGTH)
            {
                int i = (iy * Form1.ROW_LENGTH) + ix;

                if (i >= 0 && i < OutputColors.Length)
                {
                    var colorLoc = new ColorLocation()
                    {
                        LocationType = ColorLocation.ColorLocationTypes.Output,
                        Index = i,
                    };

                    if (ColorEditForms.ContainsKey(colorLoc))
                    {
                        ColorEditForms[colorLoc].Close();
                        //ColorEditForms[colorLoc].Location = GetColorMenuSpawnLocation(colorLoc.LocationType);
                        //ColorEditForms[colorLoc].Activate();
                    }
                    else
                    {
                        var formsToClose = ColorEditForms.ToList();
                        foreach (var kvp in formsToClose)
                        {
                            kvp.Value.Close();
                        }

                        var form = new FormEditSingleColor();
                        ColorEditForms[colorLoc] = form;
                        int paletteCount = (int)Math.Round(numericUpDownSteps.Value);
                        form.InitSetColor(this, colorLoc, OutputColors[i], $"'Output Palette List' - Palette {(iy)}/{paletteCount} - Color {(ix + 1)}/{ROW_LENGTH}");
                        form.Show(this);
                    }




                }
            }
        }

        private void panelFromColor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelFromColor_MouseClick(sender, e);
        }

        private void panelToColor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelToColor_MouseClick(sender, e);
        }

        private void panelOutput_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panelOutput_MouseClick(sender, e);
        }
    }
}
