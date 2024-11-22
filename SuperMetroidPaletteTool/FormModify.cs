using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMetroidPaletteTool
{
    public partial class FormModify : Form
    {
        private bool userClickedAccept = false;

        public Form1 mainForm;

        int offset_textBoxInputColor_FROM_Left;
        int offset_textBoxInputColor_TO_Left;

        private Dictionary<NumericUpDown, decimal> defaultValues;

        public FormModify()
        {
            InitializeComponent();

            // Amount
            int numColorPixels = (16 * 16);

            panelColor_ORIG.Width = numColorPixels;
            panelColor_MOD.Width = numColorPixels;

            offset_textBoxInputColor_FROM_Left = textBoxInputColor_ORIG.Left - numColorPixels;
            offset_textBoxInputColor_TO_Left = textBoxInputColor_MOD.Left - numColorPixels;

            typeof(GroupBox).InvokeMember("DoubleBuffered",
              BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
              null, panelColor_ORIG, new object[] { true });

            typeof(GroupBox).InvokeMember("DoubleBuffered",
               BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, panelColor_MOD, new object[] { true });

            void RecursiveScanControls(Control c)
            {
                foreach (var n in c.Controls)
                {
                    if (n is NumericUpDown asNum)
                        defaultValues[asNum] = asNum.Value;
                    else
                    {
                        var control = n as Control;
                        if (control != null)
                            RecursiveScanControls(control);
                    }
                }
            }

            defaultValues = new Dictionary<NumericUpDown, decimal>();
            RecursiveScanControls(this);
        }



        public enum ModifyFormTypes
        {
            ModifyingInput_FROM,
            ModifyingInput_TO,
        }

        private void FormModify_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        public ushort[] ModColors_ORIG = new ushort[16];
        public ushort[] ModColors_MOD = new ushort[16];

        public bool[] ModColorMask_ORIG = new bool[16];
        //public bool[] ModColorMask_MOD = new bool[16];

        bool requestInitColors = true;

        public ModifyFormTypes ModifyFormType;

        public void InitColors(ModifyFormTypes modifyFormType, string titleBar, ushort[] colors, bool[] mask, Form1 form1Inst)
        {
            ModifyFormType = modifyFormType;
            mainForm = form1Inst;
            Text = titleBar;
            ModColors_ORIG = colors.ToArray();
            ModColors_MOD = colors.ToArray();
            ModColorMask_ORIG = mask.ToArray();
            //ModColorMask_MOD = mask.ToArray();
            //Array.Resize(ref ModColorMask_MOD, ModColors_MOD.Length);


            //textBoxInputColor_FROM.Text = Form1.GenerateAsmForColors(InputColors_FROM);
            //textBoxInputColor_TO.Text = Form1.GenerateAsmForColors(InputColors_TO);

            int numColorPixels = Form1.COLOR_SQUARE_SIZE.X * Form1.ROW_LENGTH;

            panelColor_ORIG.Width = numColorPixels;
            panelColor_MOD.Width = numColorPixels;

            panelColor_ORIG.Refresh();
            panelColor_MOD.Refresh();

            int new_textBoxInputColor_FROM_Left = numColorPixels + offset_textBoxInputColor_FROM_Left;
            textBoxInputColor_ORIG.Size = new Size(textBoxInputColor_ORIG.Right - new_textBoxInputColor_FROM_Left, textBoxInputColor_ORIG.Height);
            textBoxInputColor_ORIG.Location = new Point(new_textBoxInputColor_FROM_Left, textBoxInputColor_ORIG.Top);

            int new_textBoxInputColor_TO_Left = numColorPixels + offset_textBoxInputColor_TO_Left;
            textBoxInputColor_MOD.Size = new Size(textBoxInputColor_MOD.Right - new_textBoxInputColor_TO_Left, textBoxInputColor_MOD.Height);
            textBoxInputColor_MOD.Location = new Point(new_textBoxInputColor_TO_Left, textBoxInputColor_MOD.Top);

            var text = Form1.GenerateAsmForColors(ModColors_ORIG);
            textBoxInputColor_ORIG.Text = text;
            textBoxInputColor_ORIG.Select(text.Length, 0);

            var text2 = Form1.GenerateAsmForColors(ModColors_MOD);
            textBoxInputColor_MOD.Text = text;
            textBoxInputColor_MOD.Select(text.Length, 0);
        }

        private void AssembleInputText_ORIG()
        {
            ModColors_ORIG = Form1.ManualParseInputString(textBoxInputColor_ORIG.Text, adjustRowLength: false, out _);
            panelColor_ORIG.Refresh();
            //Form1.GenerateInputColorSquares(this, groupBoxColor_ORIG, ModColors_ORIG, xOffset: 3, yOffset: 15);
        }

        private void AssembleInputText_MOD()
        {
            ModColors_MOD = Form1.ManualParseInputString(textBoxInputColor_MOD.Text, adjustRowLength: false, out _);
            panelColor_MOD.Refresh();

            //Form1.GenerateInputColorSquares(this, groupBoxColor_MOD, ModColors_MOD, xOffset: 3, yOffset: 15);
        }

        bool colorUpdateRequested = false;
        bool colorUpdateBusy = false;

        private void RequestColorUpdate()
        {
            colorUpdateRequested = true;
            //SynchronousColorsUpdate();
            //AsynchronousColorUpdate();
        }

        private void trackBarBrightness_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(trackBarBrightness, numericUpDownBrightness);

        }

        private void numericUpDownBrightness_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumericUpDown(numericUpDownBrightness, trackBarBrightness);

        }

        private void trackBarContrast_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(trackBarContrast, numericUpDownContrast);
        }

        private void numericUpDownContrast_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumericUpDown(numericUpDownContrast, trackBarContrast);
        }

        private void trackBarHue_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(trackBarHue, numericUpDownHue);
        }

        private void numericUpDownHue_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumericUpDown(numericUpDownHue, trackBarHue);
        }

        private void trackBarSaturation_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(trackBarSaturation, numericUpDownSaturation);
        }

        private void numericUpDownSaturation_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumericUpDown(numericUpDownSaturation, trackBarSaturation);
        }

        private Vector3 TransformIndividualColor(Vector3 c)
        {
            float brightness = (float)(numericUpDownBrightness.Value / (decimal)100.0);
            float contrast = 1 + (float)(numericUpDownContrast.Value / (decimal)100.0);
            float hue = (float)(numericUpDownHue.Value / (decimal)360.0);
            float saturation = (float)(numericUpDownSaturation.Value / (decimal)100.0);
            float addSaturation = (float)(numericUpDownAddSaturation.Value / (decimal)100.0);
            float scaleLightness = (float)(numericUpDownScaleLightness.Value / (decimal)100.0);
            float addLightness = (float)(numericUpDownAddLightness.Value / (decimal)100.0);

            float moveTowardHue_Hue = (float)(numericUpDownMoveTowardHue_Hue.Value / (decimal)360.0);
            moveTowardHue_Hue = ColorMath.Clamp(moveTowardHue_Hue, 0, 1);

            float moveTowardHue_Strength = (float)(numericUpDownMoveTowardHue_Strength.Value / (decimal)100.0);
            moveTowardHue_Strength = ColorMath.Clamp(moveTowardHue_Strength, 0, 1);

            Vector3 hsl = ColorMath.RGBtoHSL(c);

            hsl.X += hue;
            if (hsl.X > 1)
                hsl.X -= 1;
            if (hsl.X < 0)
                hsl.X += 1;


            hsl.Y += addSaturation;
            hsl.Y *= saturation;

            if (checkBoxClampSaturationMax.Checked && hsl.Y > 1)
                hsl.Y = 1;
            if (checkBoxClampSaturationMin.Checked && hsl.Y < 0)
                hsl.Y = 0;

            hsl.Z += addLightness;
            hsl.Z *= scaleLightness;

            if (checkBoxClampLightnessMax.Checked && hsl.Z > 1)
                hsl.Z = 1;
            if (checkBoxClampLightnessMin.Checked && hsl.Z < 0)
                hsl.Z = 0;

            c = ColorMath.HSLtoRGB(hsl);

            c += Vector3.One * brightness;
            c *= contrast;

            c = new Vector3(Math.Max(Math.Min(c.X, 1.0f), 0.0f), Math.Max(Math.Min(c.Y, 1.0f), 0.0f), Math.Max(Math.Min(c.Z, 1.0f), 0.0f));


            if (moveTowardHue_Strength != 0)
            {
                Vector3 moveTowardColor_HSL = ColorMath.RGBtoHSL(c);
                moveTowardColor_HSL.X = moveTowardHue_Hue;
                var moveTowardColor_RGB = ColorMath.HSLtoRGB(moveTowardColor_HSL);

                c = ColorMath.Lerp(c, moveTowardColor_RGB, moveTowardHue_Strength);
            }


            return c;
        }

        private ushort[] TransformColors(ushort[] colors, bool[] mask)
        {
            Vector3[] vec = colors.Select(c => ColorMath.SNEStoVEC3(c)).ToArray();

            for (int i = 0; i < vec.Length; i++)
            {
                if (mask[i])
                    continue;
                vec[i] = TransformIndividualColor(vec[i]);
            }

            return vec.Select(c => ColorMath.VEC3toSNES(c)).ToArray();
        }

        private bool temporarilyDisableColorUpdate = false;

        void SynchronousColorsUpdate()
        {
            if (temporarilyDisableColorUpdate)
                return;
            ModColors_MOD = TransformColors(ModColors_ORIG, ModColorMask_ORIG);
            textBoxInputColor_MOD.Text = Form1.GenerateAsmForColors(ModColors_MOD);
            //Form1.GenerateInputColorSquares(this, groupBoxColor_MOD, ModColors_MOD, xOffset: 3, yOffset: 15);
            panelColor_MOD.Refresh();
        }

        private void AsynchronousColorUpdate()
        {
            if (!colorUpdateBusy)
            {
                colorUpdateBusy = true;
                Task.Run(() =>
                {
                    Invoke(() =>
                    {
                        ModColors_MOD = TransformColors(ModColors_ORIG, ModColorMask_ORIG);
                        //textBoxInputColor_TO.Text = Form1.GenerateAsmForColors(InputColors_TO);

                        var text = Form1.GenerateAsmForColors(ModColors_MOD);
                        textBoxInputColor_MOD.Text = text;
                        textBoxInputColor_MOD.Select(text.Length, 0);
                    });

                    //Form1.GenerateInputColorSquares(this, groupBoxColor_MOD, ModColors_MOD, xOffset: 3, yOffset: 15);

                    colorUpdateBusy = false;
                });
            }
        }

        private void timerUpdateColor_Tick(object sender, EventArgs e)
        {
            colorUpdateBusy = true;
            if (requestInitColors)
            {
                //Form1.GenerateInputColorSquares(this, groupBoxColor_ORIG, ModColors_ORIG, xOffset: 3, yOffset: 15);
                //Form1.GenerateInputColorSquares(this, groupBoxColor_MOD, ModColors_MOD, xOffset: 3, yOffset: 15);
                requestInitColors = false;
            }
            if (colorUpdateRequested)
            {
                colorUpdateRequested = false;
                //AsynchronousColorUpdate();
                SynchronousColorsUpdate();

                if (ModifyFormType == ModifyFormTypes.ModifyingInput_FROM)
                {
                    mainForm.RequestRecalcOutput(setNewColors_FROM: ModColors_MOD);
                }
                else if (ModifyFormType == ModifyFormTypes.ModifyingInput_TO)
                {
                    mainForm.RequestRecalcOutput(setNewColors_TO: ModColors_MOD);
                }
            }
            colorUpdateBusy = false;
        }

        public void ChangePaletteRowLength(int newRowLength)
        {

        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            userClickedAccept = true;
            timerUpdateColor.Enabled = false;
            while (colorUpdateBusy)
                Thread.Sleep(10);
            if (ModifyFormType == ModifyFormTypes.ModifyingInput_FROM)
            {
                mainForm.RequestRecalcOutput(setNewColors_FROM: ModColors_MOD);
            }
            else if (ModifyFormType == ModifyFormTypes.ModifyingInput_TO)
            {
                mainForm.RequestRecalcOutput(setNewColors_TO: ModColors_MOD);
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            userClickedAccept = false;
            timerUpdateColor.Enabled = false;
            while (colorUpdateBusy)
                Thread.Sleep(10);
            if (ModifyFormType == ModifyFormTypes.ModifyingInput_FROM)
            {
                mainForm.RequestRecalcOutput(setNewColors_FROM: ModColors_ORIG);
            }
            else if (ModifyFormType == ModifyFormTypes.ModifyingInput_TO)
            {
                mainForm.RequestRecalcOutput(setNewColors_TO: ModColors_ORIG);
            }
            Close();
        }

        private void groupBoxColorORIG_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBoxColor_MOD_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormModify_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!userClickedAccept)
            {
                timerUpdateColor.Enabled = false;
                while (colorUpdateBusy)
                    Thread.Sleep(10);
                if (ModifyFormType == ModifyFormTypes.ModifyingInput_FROM)
                {
                    mainForm.RequestRecalcOutput(setNewColors_FROM: ModColors_ORIG);
                }
                else if (ModifyFormType == ModifyFormTypes.ModifyingInput_TO)
                {
                    mainForm.RequestRecalcOutput(setNewColors_TO: ModColors_ORIG);
                }
            }

            if (!e.Cancel)
            {
                defaultValues.Clear();
            }
        }

        private void panelColor_ORIG_Paint(object sender, PaintEventArgs e)
        {
            Form1.DrawColorsOnGraphics(e.Graphics, ModColors_ORIG, ModColorMask_ORIG, 0, 0, -1, -1);
        }

        private void panelColor_MOD_Paint(object sender, PaintEventArgs e)
        {
            Form1.DrawColorsOnGraphics(e.Graphics, ModColors_MOD, null, 0, 0, -1, -1);
        }

        private void panelColor_ORIG_MouseClick(object sender, MouseEventArgs e)
        {
            //int ix = e.X / Form1.COLOR_SQUARE_SIZE.X;
            //int iy = e.Y / Form1.COLOR_SQUARE_SIZE.Y;
            //if (ix >= 0 && iy >= 0 && ix < Form1.ROW_LENGTH)
            //{
            //    int i = (iy * Form1.ROW_LENGTH) + ix;

            //    if (i >= 0 && i < ModColorMask_ORIG.Length)
            //    {
            //        ModColorMask_ORIG[i] = !ModColorMask_ORIG[i];
            //        panelColor_ORIG.Refresh();
            //        colorUpdateRequested = true;
            //    }
            //}
        }

        private void FormModify_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void FormModify_Activated(object sender, EventArgs e)
        {

            if (ModifyFormType is ModifyFormTypes.ModifyingInput_FROM)
            {
                mainForm.SetColorLocOfFocusedEditor(new ColorLocation()
                {
                    LocationType = ColorLocation.ColorLocationTypes.InputFROM,
                    Index = -1
                });
            }
            else if (ModifyFormType is ModifyFormTypes.ModifyingInput_TO)
            {
                mainForm.SetColorLocOfFocusedEditor(new ColorLocation()
                {
                    LocationType = ColorLocation.ColorLocationTypes.InputTO,
                    Index = -1
                });
            }
        }

        private bool? panelColor_ORIG__ClickSetValue = null;

        private void panelColor_ORIG_MouseDown(object sender, MouseEventArgs e)
        {
            int ix = e.X / Form1.COLOR_SQUARE_SIZE.X;
            int iy = e.Y / Form1.COLOR_SQUARE_SIZE.Y;
            if (ix >= 0 && iy >= 0 && ix < Form1.ROW_LENGTH)
            {
                int i = (iy * Form1.ROW_LENGTH) + ix;

                if (i >= 0 && i < ModColorMask_ORIG.Length)
                {
                    panelColor_ORIG__ClickSetValue = !ModColorMask_ORIG[i];
                    ModColorMask_ORIG[i] = panelColor_ORIG__ClickSetValue.Value;
                    panelColor_ORIG.Refresh();
                    colorUpdateRequested = true;
                }
            }
        }

        private void panelColor_ORIG_MouseUp(object sender, MouseEventArgs e)
        {
            panelColor_ORIG__ClickSetValue = null;
        }

        private void panelColor_ORIG_MouseMove(object sender, MouseEventArgs e)
        {
            if (panelColor_ORIG__ClickSetValue.HasValue)
            {
                int ix = e.X / Form1.COLOR_SQUARE_SIZE.X;
                int iy = e.Y / Form1.COLOR_SQUARE_SIZE.Y;
                if (ix >= 0 && iy >= 0 && ix < Form1.ROW_LENGTH)
                {
                    int i = (iy * Form1.ROW_LENGTH) + ix;

                    if (i >= 0 && i < ModColorMask_ORIG.Length)
                    {
                        ModColorMask_ORIG[i] = panelColor_ORIG__ClickSetValue.Value;
                        panelColor_ORIG.Refresh();
                        colorUpdateRequested = true;
                    }
                }
            }
        }

        private void trackBarMoveTowardHue_Hue_Scroll(object sender, EventArgs e)
        {
            //Delete me
        }

        private void trackBarMoveTowardHue_Hue_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(trackBarMoveTowardHue_Hue, numericUpDownMoveTowardHue_Hue);
        }

        private void trackBarMoveTowardHue_Strength_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(trackBarMoveTowardHue_Strength, numericUpDownMoveTowardHue_Strength);
        }

        private void numericUpDownMoveTowardHue_Hue_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumericUpDown(numericUpDownMoveTowardHue_Hue, trackBarMoveTowardHue_Hue);
        }

        private void numericUpDownMoveTowardHue_Strength_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumericUpDown(numericUpDownMoveTowardHue_Strength, trackBarMoveTowardHue_Strength);
        }

        private void trackBarAddSaturation_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(trackBarAddSaturation, numericUpDownAddSaturation);

        }

        private void numericUpDownAddSaturation_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumericUpDown(numericUpDownAddSaturation, trackBarAddSaturation);
        }

        private bool disableCopyFromTrackBarToNumericUpDown = false;
        private bool disableCopyFromNumericUpDownToTrackBar = false;
        private void UpdateTrackBar(TrackBar trackBar, NumericUpDown numericUpDown)
        {
            if (!disableCopyFromTrackBarToNumericUpDown)
            {
                Invoke(() =>
                {
                    var prevDisable = disableCopyFromNumericUpDownToTrackBar;
                    disableCopyFromNumericUpDownToTrackBar = true;
                    {
                        decimal valueForNumericUpDown = ((decimal)trackBar.Value / (decimal)1000.0);
                        if (valueForNumericUpDown < numericUpDown.Minimum)
                            valueForNumericUpDown = numericUpDown.Minimum;
                        if (valueForNumericUpDown > numericUpDown.Maximum)
                            valueForNumericUpDown = numericUpDown.Maximum;
                        numericUpDown.Value = valueForNumericUpDown;
                    }
                    disableCopyFromNumericUpDownToTrackBar = false;

                    RequestColorUpdate();
                });

            }
        }

        private void UpdateNumericUpDown(NumericUpDown numericUpDown, TrackBar trackBar)
        {
            if (!disableCopyFromNumericUpDownToTrackBar)
            {
                Invoke(() =>
                {
                    var prevDisable = disableCopyFromTrackBarToNumericUpDown;
                    disableCopyFromTrackBarToNumericUpDown = true;
                    {
                        int valueForTrackbar = (int)Math.Round(numericUpDown.Value * 1000);
                        if (valueForTrackbar < trackBar.Minimum)
                            valueForTrackbar = trackBar.Minimum;
                        if (valueForTrackbar > trackBar.Maximum)
                            valueForTrackbar = trackBar.Maximum;
                        trackBar.Value = valueForTrackbar;
                    }
                    disableCopyFromTrackBarToNumericUpDown = prevDisable;

                    RequestColorUpdate();
                });
            }

        }

        private void trackBarScaleLightness_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(trackBarScaleLightness, numericUpDownScaleLightness);
        }

        private void numericUpDownScaleLightness_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumericUpDown(numericUpDownScaleLightness, trackBarScaleLightness);
        }

        private void trackBarAddLightness_ValueChanged(object sender, EventArgs e)
        {
            UpdateTrackBar(trackBarAddLightness, numericUpDownAddLightness);
        }

        private void numericUpDownAddLightness_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumericUpDown(numericUpDownAddLightness, trackBarAddLightness);
        }

        private void buttonResetValues_Click(object sender, EventArgs e)
        {
            var prev = temporarilyDisableColorUpdate;
            temporarilyDisableColorUpdate = true;
            {
                foreach (var kvp in defaultValues)
                {
                    kvp.Key.Value = kvp.Value;
                }

                checkBoxClampLightnessMin.Checked = false;
                checkBoxClampLightnessMax.Checked = false;
                checkBoxClampSaturationMin.Checked = false;
                checkBoxClampSaturationMax.Checked = false;
            }
            temporarilyDisableColorUpdate = prev;
            RequestColorUpdate();
        }

        private void checkBoxClampSaturation_CheckedChanged(object sender, EventArgs e)
        {
            RequestColorUpdate();
        }

        private void checkBoxClampLightness_CheckedChanged(object sender, EventArgs e)
        {
            RequestColorUpdate();
        }

        private void checkBoxClampSaturationMax_CheckedChanged(object sender, EventArgs e)
        {
            RequestColorUpdate();
        }

        private void checkBoxClampLightnessMax_CheckedChanged(object sender, EventArgs e)
        {
            RequestColorUpdate();
        }
    }
}
