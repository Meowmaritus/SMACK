using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMetroidPaletteTool
{
    public partial class FormEditSingleColor : Form
    {


        //const int WIDTH = 180 * 8;
        //const int HEIGHT = 32 * 8;

        bool initialized = false;

        public Form1 MainFormInst;
        public ColorLocation ColorLoc;

        [Flags]
        public enum GraphComponents
        {
            None = 0,
            R = 1,
            G = 1 << 1,
            B = 1 << 2,
            H = 1 << 3,
            S = 1 << 4,
            L = 1 << 5
        }

        public enum GraphModes
        {
            HLS = 0,
            HSL = 1,
        }

        public GraphModes GraphMode = GraphModes.HLS;

        public GraphComponents Component_GraphX = GraphComponents.H;
        public GraphComponents Component_GraphY = GraphComponents.L;
        public GraphComponents Component_GraphZ = GraphComponents.S;

        //private Bitmap TestBitmap;

        //private unsafe void Meme()
        //{
        //    int width = ColorMath.NUM_HUES;
        //    int height = ColorMath.NUM_VALUES;

        //    if (width < 4)
        //        width = 4;

        //    if (height < 4)
        //        height = 4;

        //    if (width % 4 != 0)
        //        width += (4 - (width % 4));

        //    if (height % 4 != 0)
        //        height += (4 - (height % 4));



        //    pictureBoxColorField.Image?.Dispose();

        //    TestBitmapPixels = new BitmapPixelStruct[height, width];
        //    nint test = System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(TestBitmapPixels, 0);

        //    pictureBoxColorField.Image = new Bitmap(width, height, 3 * width, System.Drawing.Imaging.PixelFormat.Format24bppRgb, test);
        //    //TestBitmapPixels[8, 8] = new BitmapPixelStruct() { R = 0, G = 0, B = 255 };

        //    WriteBitmapForCurrentSaturation();
        //}

        private List<ushort> benchmarkResults = new List<ushort>();
        private int lastSliderNextToGraphValueBitmapWasWrittenFor = -1;

        private bool benchmark = false;
        private unsafe void WriteBitmapForCurrentSliderNextToGraphValue(bool force = true)
        {
            int z = 0;

            if (Component_GraphZ == GraphComponents.R)
            {
                z = trackBarRed.Value;
            }
            else if (Component_GraphZ == GraphComponents.G)
            {
                z = trackBarGreen.Value;
            }
            else if (Component_GraphZ == GraphComponents.B)
            {
                z = trackBarBlue.Value;
            }
            else if (Component_GraphZ == GraphComponents.H)
            {
                z = trackBarHue.Value;
            }
            else if (Component_GraphZ == GraphComponents.S)
            {
                z = trackBarSaturation.Value;
            }
            else if (Component_GraphZ == GraphComponents.L)
            {
                z = trackBarLightness.Value;
            }

            if (!force && lastSliderNextToGraphValueBitmapWasWrittenFor == z)
                return;


            var lx = ColorMath.NUM_HUES;
            var ly = ColorMath.NUM_LIGHTNESSES;
            var lz = ColorMath.NUM_SATURATIONS;

            if (GraphMode == GraphModes.HLS)
            {
                lx = ColorMath.NUM_HUES;
                ly = ColorMath.NUM_LIGHTNESSES;
                lz = ColorMath.NUM_SATURATIONS;
            }
            else if (GraphMode == GraphModes.HSL)
            {
                lx = ColorMath.NUM_HUES;
                ly = ColorMath.NUM_SATURATIONS;
                lz = ColorMath.NUM_LIGHTNESSES;
            }
            else
            {
                throw new NotImplementedException();
            }

            float rz = (float)z / (float)lz;

            for (int x = 0; x <= lx; x++)
            {
                for (int y = 0; y <= ly; y++)
                {
                    float rx = (float)x / (float)lx;
                    float ry = 1 - ((float)y / (float)ly);


                    var hsl = Vector3.Zero;

                    // rx = graph X
                    // ry = graph Y
                    // rz = bar next to graph

                    if (GraphMode == GraphModes.HLS)
                    {
                        hsl = new Vector3(rx, rz, ry);
                    }
                    else if (GraphMode == GraphModes.HSL)
                    {
                        hsl = new Vector3(rx, ry, rz);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    var rgb = ColorMath.HSLtoRGB(hsl);


                    //test
                    var snes = ColorMath.VEC3toSNES(rgb);

                    if (benchmark && !benchmarkResults.Contains(snes))
                        benchmarkResults.Add(snes);

                    rgb = ColorMath.SNEStoVEC3(snes);


                    var color = ColorMath.VEC3toPC(rgb);


                    pictureBoxColorField.TestBitmapPixels[y, x] =
                        new PixelPictureBox.BitmapPixelStruct()
                        { R = color.R, G = color.G, B = color.B };
                }
            }
            lastSliderNextToGraphValueBitmapWasWrittenFor = z;
            pictureBoxColorField.Refresh();
        }

        private int graphAreaMarginX;
        private int graphAreaMarginY;

        List<GraphModes> graphModeDropdown_Values = new List<GraphModes>();

        public FormEditSingleColor()
        {
            InitializeComponent();


            //pictureBoxColorField.InitializePixels();
            //WriteBitmapForCurrentSliderNextToGraphValue(force: true);
            //pictureBoxColorField.Refresh();
            ChangeGraphMode(GraphModes.HLS);

            numericUpDownHue.Maximum = ColorMath.NUM_HUES;
            trackBarHue.Maximum = ColorMath.NUM_HUES;


            numericUpDownSaturation.Maximum = ColorMath.NUM_SATURATIONS;
            trackBarSaturation.Maximum = ColorMath.NUM_SATURATIONS;

            //trackBarGraphZ.Maximum = ColorMath.NUM_SATURATIONS;


            trackBarLightness.Maximum = ColorMath.NUM_LIGHTNESSES;
            numericUpDownLightness.Maximum = ColorMath.NUM_LIGHTNESSES;

            initialized = true;
            //pictureBoxColorField.Image = TestBitmap;



            buttonDbgBenchmark.Enabled = false;
            buttonDbgBenchmark.Visible = false;

            labelDbgBenchmarkResult.Enabled = false;
            labelDbgBenchmarkResult.Visible = false;

            graphAreaMarginX = Width - pictureBoxColorField.Width;
            graphAreaMarginY = Height - pictureBoxColorField.Height;

            comboBoxGraphMode.Items.Clear();
            graphModeDropdown_Values.Clear();

            graphModeDropdown_Values.Add(GraphModes.HLS);
            comboBoxGraphMode.Items.Add("[H x L] [S]");
            graphModeDropdown_Values.Add(GraphModes.HSL);
            comboBoxGraphMode.Items.Add("[H x S] [L]");

            comboBoxGraphMode.SelectedIndex = Properties.Settings.Default.LastGraphMode;


        }

        //public void UpdateGraphSizeForWindowSize()
        //{
        //    int snapX = 0;
        //    int snapY = 0;
        //    if (Component_GraphX is GraphComponents.R or GraphComponents.G or GraphComponents.B)
        //        snapX = 0b11111;
        //    else if (Component_GraphX is GraphComponents.H)
        //        snapX = ColorMath.NUM_HUES;
        //    else if (Component_GraphX == GraphComponents.S)
        //        snapX = ColorMath.NUM_SATURATIONS;
        //    else if (Component_GraphX == GraphComponents.L)
        //        snapX = ColorMath.NUM_LIGHTNESSES;

        //    if (Component_GraphY is GraphComponents.R or GraphComponents.G or GraphComponents.B)
        //        snapY = 0b11111;
        //    else if (Component_GraphY is GraphComponents.H)
        //        snapY = ColorMath.NUM_HUES;
        //    else if (Component_GraphY == GraphComponents.S)
        //        snapY = ColorMath.NUM_SATURATIONS;
        //    else if (Component_GraphY == GraphComponents.L)
        //        snapY = ColorMath.NUM_LIGHTNESSES;

        //    snapX++;
        //    snapY++;

        //    int spaceForGraphX = Width - graphAreaMarginX;
        //    int spaceForGraphY = Height - graphAreaMarginY;

        //    pictureBoxColorField.Size = new Size((spaceForGraphX / snapX) * snapX, (spaceForGraphY / snapY) * snapY);
        //    panelPictureBox.Size = new Size(pictureBoxColorField.Size.Width + 4, pictureBoxColorField.Size.Height + 4);
        //}

        private void FormEditSingleColor_Load(object sender, EventArgs e)
        {
            Location = MainFormInst.GetColorMenuSpawnLocation(ColorLoc.LocationType);
        }


        private void ChangeGraphMode(GraphModes mode)
        {
            GraphMode = mode;
            if (GraphMode == GraphModes.HLS)
            {
                Component_GraphX = GraphComponents.H;
                Component_GraphY = GraphComponents.L;
                Component_GraphZ = GraphComponents.S;
            }
            else if (GraphMode == GraphModes.HSL)
            {
                Component_GraphX = GraphComponents.H;
                Component_GraphY = GraphComponents.S;
                Component_GraphZ = GraphComponents.L;
            }
            else
            {
                throw new NotImplementedException();
            }



            int maxX = ColorMath.NUM_HUES;
            int maxY = ColorMath.NUM_LIGHTNESSES;

            if (Component_GraphX is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxX = 0b11111;
            else if (Component_GraphX is GraphComponents.H)
                maxX = ColorMath.NUM_HUES;
            else if (Component_GraphX == GraphComponents.S)
                maxX = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphX == GraphComponents.L)
                maxX = ColorMath.NUM_LIGHTNESSES;

            if (Component_GraphY is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxY = 0b11111;
            else if (Component_GraphY is GraphComponents.H)
                maxY = ColorMath.NUM_HUES;
            else if (Component_GraphY == GraphComponents.S)
                maxY = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphY == GraphComponents.L)
                maxY = ColorMath.NUM_LIGHTNESSES;

            pictureBoxColorField.InitializePixels(maxX + 1, maxY + 1);
            WriteBitmapForCurrentSliderNextToGraphValue(force: true);
            pictureBoxColorField.Refresh();

            InitBitmapForGraphZBar();
            WriteBitmapForGraphZBar();

        }

        private void WriteBitmapForGraphZBar()
        {
            int maxZ = ColorMath.NUM_HUES;

            if (Component_GraphZ is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxZ = 0b11111;
            else if (Component_GraphZ is GraphComponents.H)
                maxZ = ColorMath.NUM_HUES;
            else if (Component_GraphZ == GraphComponents.S)
                maxZ = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphZ == GraphComponents.L)
                maxZ = ColorMath.NUM_LIGHTNESSES;

            for (int i = 0; i <= maxZ; i++)
            {
                if (Component_GraphZ is GraphComponents.H or GraphComponents.S or GraphComponents.L)
                {
                    int h = trackBarHue.Value;
                    int s = trackBarSaturation.Value;
                    int l = trackBarLightness.Value;

                    if (Component_GraphZ is GraphComponents.H)
                        h = i;
                    else if (Component_GraphZ is GraphComponents.S)
                        s = i;
                    else if (Component_GraphZ is GraphComponents.L)
                        l = i;

                    var colorPC = ColorMath.SNEStoPC(ColorMath.HSLtoSNES_Int(h, s, l));
                    pixelPictureBoxGraphZ.TestBitmapPixels[maxZ - i, 0] = new PixelPictureBox.BitmapPixelStruct()
                    {
                        R = colorPC.R,
                        G = colorPC.G,
                        B = colorPC.B
                    };
                }
                else if (Component_GraphZ is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                {
                    int r = trackBarRed.Value;
                    int g = trackBarGreen.Value;
                    int b = trackBarBlue.Value;

                    if (Component_GraphZ is GraphComponents.R)
                        r = i;
                    else if (Component_GraphZ is GraphComponents.G)
                        g = i;
                    else if (Component_GraphZ is GraphComponents.B)
                        b = i;

                    var colorPC = ColorMath.SNEStoPC(ColorMath.RepackSNES(r, g, b));
                    pixelPictureBoxGraphZ.TestBitmapPixels[maxZ - i, 0] = new PixelPictureBox.BitmapPixelStruct()
                    {
                        R = colorPC.R,
                        G = colorPC.G,
                        B = colorPC.B
                    };
                }
                else
                {
                    throw new NotImplementedException();
                }

            }

            pixelPictureBoxGraphZ.Refresh();
        }

        private void InitBitmapForGraphZBar()
        {
            int maxZ = ColorMath.NUM_HUES;

            if (Component_GraphZ is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxZ = 0b11111;
            else if (Component_GraphZ is GraphComponents.H)
                maxZ = ColorMath.NUM_HUES;
            else if (Component_GraphZ == GraphComponents.S)
                maxZ = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphZ == GraphComponents.L)
                maxZ = ColorMath.NUM_LIGHTNESSES;

            pixelPictureBoxGraphZ.InitializePixels(1, maxZ + 1);
        }



        private void trackBarSaturationGraph_Scroll(object sender, EventArgs e)
        {

        }

        private ushort COLOR = 0;
        private ushort InitColor = 0;

        private bool userClickedCancel = false;

        private bool updateColorValuesIgnore_TrackBar = false;

        private bool isClosingDontTouchColorResult = false;

        private bool updateColorValuesIgnore_Numeric = false;

        public void InitSetColor(Form1 mainFormInst, ColorLocation colorLoc, ushort initColor, string colorIndexDescString)
        {
            MainFormInst = mainFormInst;
            ColorLoc = colorLoc;

            labelHeader.Text = $"Editing {colorIndexDescString}";
            panelHeaderColorORIG.BackColor = ColorMath.SNEStoPC(initColor);

            if (isClosingDontTouchColorResult)
                return;
            InitColor = initColor;
            UpdateAllColorSliders(initColor);


        }

        private void UpdateAllColorSliders(ushort newValue,
            bool updateRed = true,
            bool updateGreen = true,
            bool updateBlue = true,
            bool updateHue = true,
            bool updateSaturation = true,
            bool updateLightness = true,
            bool updateColorHexAndSwatch = true,
            bool updateColorHexAndSwatch_PC = true)
        {
            if (isClosingDontTouchColorResult)
                return;

            if (COLOR != newValue)
            {
                COLOR = newValue;
                panelHeaderColorMOD.BackColor = ColorMath.SNEStoPC(COLOR);
                panelHeaderColorMOD.Refresh();
                if (COLOR != snesColorLastGeneratedFromPCColor)
                {
                    snesColorLastGeneratedFromPCColor = null;
                    labelPCColorGeneratedFrom.Text = "";
                    labelPCColorGeneratedFrom.Visible = false;

                    panelPCColorGeneratedFrom.BackColor = MainFormInst.BackColor;
                    panelPCColorGeneratedFrom.Visible = false;
                }

                ColorMath.UnpackSNES(COLOR, out int r, out int g, out int b);
                ColorMath.SNEStoHSL_Int(COLOR, out int h, out int s, out int l);

                var prev_TrackBar = updateColorValuesIgnore_TrackBar;
                updateColorValuesIgnore_TrackBar = true;
                {
                    if (updateRed)
                    {
                        trackBarRed.Value = r;
                    }
                    if (updateGreen)
                    {
                        trackBarGreen.Value = g;
                    }
                    if (updateBlue)
                    {
                        trackBarBlue.Value = b;
                    }

                    if (updateHue)
                    {
                        trackBarHue.Value = h;
                    }
                    if (updateSaturation)
                    {
                        trackBarSaturation.Value = s;
                    }

                    if (updateLightness)
                    {
                        trackBarLightness.Value = l;
                    }

                    if (updateColorHexAndSwatch)
                    {
                        textBoxColorHex.Text = Form1.GenerateAsmForColors(new[] { COLOR });
                        textBoxColorHex.SelectionStart = textBoxColorHex.Text.Length;
                        textBoxColorHex.SelectionLength = 0;
                        textBoxColorHex.Refresh();

                        panelColorSwatch.BackColor = ColorMath.SNEStoPC(COLOR);
                        panelColorSwatch.Refresh();
                    }

                    if (updateColorHexAndSwatch_PC)
                    {
                        textBoxColorHex_PC.Text = Form1.GenerateAsmForColors_PC(new[] { COLOR });
                        textBoxColorHex_PC.SelectionStart = textBoxColorHex_PC.Text.Length;
                        textBoxColorHex_PC.SelectionLength = 0;
                        textBoxColorHex_PC.Refresh();
                    }






                }
                updateColorValuesIgnore_TrackBar = prev_TrackBar;

                var prev_Numeric = updateColorValuesIgnore_Numeric;
                updateColorValuesIgnore_Numeric = true;
                {
                    if (updateHue)
                    {
                        numericUpDownHue.Value = h;
                        numericUpDownHue.Refresh();
                    }

                    if (updateSaturation)
                    {
                        numericUpDownSaturation.Value = s;
                        numericUpDownSaturation.Refresh();
                    }

                    if (updateLightness)
                    {
                        numericUpDownLightness.Value = l;
                        numericUpDownLightness.Refresh();
                    }

                    if (updateRed)
                    {
                        numericUpDownRed.Value = r;
                        numericUpDownRed.Refresh();
                    }

                    if (updateGreen)
                    {
                        numericUpDownGreen.Value = g;
                        numericUpDownGreen.Refresh();
                    }

                    if (updateBlue)
                    {
                        numericUpDownBlue.Value = b;
                        numericUpDownBlue.Refresh();
                    }
                }
                updateColorValuesIgnore_Numeric = prev_Numeric;

                WriteBitmapForGraphZBar();
            }
            WriteBitmapForCurrentSliderNextToGraphValue();
            MainFormInst.SetColorByLocation(ColorLoc, COLOR);
        }

        private void timerMouseHeld_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBoxColorField_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //timerMouseHeld.Start();
                ColorPickToMouseLocation(e.Location);
            }
        }

        private void pictureBoxColorField_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    timerMouseHeld.Enabled = false;
            //}
        }

        //bool lastVisible;
        private void FormEditSingleColor_VisibleChanged(object sender, EventArgs e)
        {
            //if (Visible != lastVisible)
            //    Meme();

            //lastVisible = Visible;
        }

        private void panelPictureBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxColorField_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            //float h = (float)trackBarHue.Value / (float)(ColorMath.NUM_HUES);
            //float l = 1 - ((float)trackBarLightness.Value / (float)(ColorMath.NUM_VALUES));

            //int x = (int)Math.Floor(Math.Floor(h * (float)(ColorMath.NUM_HUES)) * ((float)(pictureBoxColorField.Width) / (float)(ColorMath.NUM_HUES + 1)));
            //int y = (int)Math.Floor(Math.Floor(l * (float)(ColorMath.NUM_VALUES)) * ((float)(pictureBoxColorField.Height) / (float)(ColorMath.NUM_VALUES + 1)));

            int maxX = ColorMath.NUM_HUES;
            int maxY = ColorMath.NUM_LIGHTNESSES;

            if (Component_GraphX is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxX = 0b11111;
            else if (Component_GraphX is GraphComponents.H)
                maxX = ColorMath.NUM_HUES;
            else if (Component_GraphX == GraphComponents.S)
                maxX = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphX == GraphComponents.L)
                maxX = ColorMath.NUM_LIGHTNESSES;

            if (Component_GraphY is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxY = 0b11111;
            else if (Component_GraphY is GraphComponents.H)
                maxY = ColorMath.NUM_HUES;
            else if (Component_GraphY == GraphComponents.S)
                maxY = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphY == GraphComponents.L)
                maxY = ColorMath.NUM_LIGHTNESSES;

            int x = trackBarHue.Value;
            int y = trackBarLightness.Value;

            if (Component_GraphX is GraphComponents.R)
                x = trackBarRed.Value;
            else if (Component_GraphX is GraphComponents.G)
                x = trackBarGreen.Value;
            else if (Component_GraphX is GraphComponents.B)
                x = trackBarBlue.Value;
            else if (Component_GraphX is GraphComponents.H)
                x = trackBarHue.Value;
            else if (Component_GraphX == GraphComponents.S)
                x = trackBarSaturation.Value;
            else if (Component_GraphX == GraphComponents.L)
                x = trackBarLightness.Value;

            if (Component_GraphY is GraphComponents.R)
                y = trackBarRed.Value;
            else if (Component_GraphY is GraphComponents.G)
                y = trackBarGreen.Value;
            else if (Component_GraphY is GraphComponents.B)
                y = trackBarBlue.Value;
            else if (Component_GraphY is GraphComponents.H)
                y = trackBarHue.Value;
            else if (Component_GraphY == GraphComponents.S)
                y = trackBarSaturation.Value;
            else if (Component_GraphY == GraphComponents.L)
                y = trackBarLightness.Value;

            x = (int)Math.Round(x * ((float)pictureBoxColorField.Width / (float)maxX));
            y = (int)Math.Round((maxY - y) * ((float)pictureBoxColorField.Height / (float)maxY));

            using (var b = new SolidBrush((ColorMath.GetApparentBrightness(COLOR) < 0.5f) ? Color.White : Color.Black))
            {
                e.Graphics.FillRectangle(b, x - 1, y - 9, 3, 5);
                e.Graphics.FillRectangle(b, x - 1, y + 5, 3, 5);
                e.Graphics.FillRectangle(b, x - 9, y - 1, 5, 3);
                e.Graphics.FillRectangle(b, x + 5, y - 1, 5, 3);

                //e.Graphics.FillRectangle(b, (x - 1) - 2, (y - 9) - 2, (3) + 4, (5) + 4);
                //e.Graphics.FillRectangle(b, (x - 1) - 2, (y + 5) - 2, (3) + 4, (5) + 4);
                //e.Graphics.FillRectangle(b, (x - 9) - 2, (y - 1) - 2, (5) + 4, (3) + 4);
                //e.Graphics.FillRectangle(b, (x + 5) - 2, (y - 1) - 2, (5) + 4, (3) + 4);



            }
        }

        private void ColorPickToMouseLocation(Point location)
        {
            int maxX = ColorMath.NUM_HUES;
            int maxY = ColorMath.NUM_LIGHTNESSES;

            if (Component_GraphX is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxX = 0b11111;
            else if (Component_GraphX is GraphComponents.H)
                maxX = ColorMath.NUM_HUES;
            else if (Component_GraphX == GraphComponents.S)
                maxX = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphX == GraphComponents.L)
                maxX = ColorMath.NUM_LIGHTNESSES;

            if (Component_GraphY is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxY = 0b11111;
            else if (Component_GraphY is GraphComponents.H)
                maxY = ColorMath.NUM_HUES;
            else if (Component_GraphY == GraphComponents.S)
                maxY = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphY == GraphComponents.L)
                maxY = ColorMath.NUM_LIGHTNESSES;

            var x = (int)Math.Round(((float)location.X / (float)(pictureBoxColorField.Width)) * maxX);
            var y = (int)Math.Round(((float)location.Y / (float)(pictureBoxColorField.Height)) * maxY);

            //// I don't even know whats going on anymore with this shit
            //x += 1;
            //y -= 1;
            if (x < 0)
                x = 0;
            if (x > maxX)
                x = maxX;
            if (y < 0)
                y = 0;
            if (y > maxY)
                y = maxY;

            y = maxY - y;

            //var xRatio = ColorMath.Clamp((float)x / (float)pictureBoxColorField.Width, 0, 1);
            //var yRatio = 1 - ColorMath.Clamp((float)y / (float)pictureBoxColorField.Height, 0, 1);


            if (Component_GraphX is GraphComponents.R)
                trackBarRed.Value = x;
            else if (Component_GraphX is GraphComponents.G)
                trackBarGreen.Value = x;
            else if (Component_GraphX is GraphComponents.B)
                trackBarBlue.Value = x;
            else if (Component_GraphX is GraphComponents.H)
                trackBarHue.Value = x;
            else if (Component_GraphX == GraphComponents.S)
                trackBarSaturation.Value = x;
            else if (Component_GraphX == GraphComponents.L)
                trackBarLightness.Value = x;

            if (Component_GraphY is GraphComponents.R)
                trackBarRed.Value = y;
            else if (Component_GraphY is GraphComponents.G)
                trackBarGreen.Value = y;
            else if (Component_GraphY is GraphComponents.B)
                trackBarBlue.Value = y;
            else if (Component_GraphY is GraphComponents.H)
                trackBarHue.Value = y;
            else if (Component_GraphY == GraphComponents.S)
                trackBarSaturation.Value = y;
            else if (Component_GraphY == GraphComponents.L)
                trackBarLightness.Value = y;

            //var h = x;
            //var l = y;
            //var s = trackBarGraphZ.Value;
            //var color = ColorMath.HSLtoSNES_Int(h, s, l);
            //UpdateAllColorSliders(color, updateHue: false, updateSaturation: false, updateLightness: false);

            //var prev_TrackBar = updateColorValuesIgnore_TrackBar;
            //updateColorValuesIgnore_TrackBar = true;
            //{
            //    trackBarHue.Value = h;
            //    trackBarLightness.Value = l;
            //}
            //updateColorValuesIgnore_TrackBar = prev_TrackBar;

            //var prev_Numeric = updateColorValuesIgnore_Numeric;
            //updateColorValuesIgnore_Numeric = true;
            //{
            //    numericUpDownHue.Value = h;
            //    numericUpDownHue.Refresh();

            //    numericUpDownLightness.Value = l;
            //    numericUpDownLightness.Refresh();
            //}
            //updateColorValuesIgnore_Numeric = prev_Numeric;


            pictureBoxColorField.Refresh();
        }

        private void pictureBoxColorField_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                ColorPickToMouseLocation(e.Location);
            }
        }

        private void FormEditSingleColor_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosingDontTouchColorResult = true;
            MainFormInst.UnregisterColorEditForm(this);
            if (!userClickedCancel)
            {
                MainFormInst.SetColorByLocation(ColorLoc, COLOR);
            }
            else
            {
                MainFormInst.SetColorByLocation(ColorLoc, InitColor);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            userClickedCancel = true;
            Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            userClickedCancel = false;
            Close();
        }

        private void checkBoxUseHexForChannels_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownRed.Hexadecimal = checkBoxUseHexForChannels.Checked;
            numericUpDownGreen.Hexadecimal = checkBoxUseHexForChannels.Checked;
            numericUpDownBlue.Hexadecimal = checkBoxUseHexForChannels.Checked;
            numericUpDownHue.Hexadecimal = checkBoxUseHexForChannels.Checked;
            numericUpDownSaturation.Hexadecimal = checkBoxUseHexForChannels.Checked;
            numericUpDownLightness.Hexadecimal = checkBoxUseHexForChannels.Checked;
        }

        private void numericUpDownRed_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_Numeric)
                return;

            // Offload color update logic to the TrackBar version.
            trackBarRed.Value = (int)Math.Round(numericUpDownRed.Value);
        }

        private void numericUpDownGreen_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_Numeric)
                return;

            // Offload color update logic to the TrackBar version.
            trackBarGreen.Value = (int)Math.Round(numericUpDownGreen.Value);
        }

        private void numericUpDownBlue_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_Numeric)
                return;

            // Offload color update logic to the TrackBar version.
            trackBarBlue.Value = (int)Math.Round(numericUpDownBlue.Value);
        }

        private void numericUpDownHue_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_Numeric)
                return;

            // Offload color update logic to the TrackBar version.
            trackBarHue.Value = (int)Math.Round(numericUpDownHue.Value);
        }

        private void numericUpDownSaturation_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_Numeric)
                return;

            // Offload color update logic to the TrackBar version.
            // trackBarSaturationGraph will also be updated with this 
            trackBarSaturation.Value = (int)Math.Round(numericUpDownSaturation.Value);
        }

        private void numericUpDownLightness_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_Numeric)
                return;

            // Offload color update logic to the TrackBar version.
            trackBarLightness.Value = (int)Math.Round(numericUpDownLightness.Value);
        }

        private void trackBarRed_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_TrackBar)
                return;

            ColorMath.UnpackSNES(COLOR, out int r, out int g, out int b);

            r = trackBarRed.Value;

            UpdateAllColorSliders(ColorMath.RepackSNES(r, g, b), updateRed: false, updateGreen: false, updateBlue: false);

            var prev_Numeric = updateColorValuesIgnore_Numeric;
            updateColorValuesIgnore_Numeric = true;
            {
                numericUpDownRed.Value = r;
                numericUpDownRed.Refresh();
            }
            updateColorValuesIgnore_Numeric = prev_Numeric;
        }

        private void trackBarGreen_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_TrackBar)
                return;

            ColorMath.UnpackSNES(COLOR, out int r, out int g, out int b);

            g = trackBarGreen.Value;

            UpdateAllColorSliders(ColorMath.RepackSNES(r, g, b), updateRed: false, updateGreen: false, updateBlue: false);

            var prev_Numeric = updateColorValuesIgnore_Numeric;
            updateColorValuesIgnore_Numeric = true;
            {
                numericUpDownGreen.Value = g;
                numericUpDownGreen.Refresh();
            }
            updateColorValuesIgnore_Numeric = prev_Numeric;
        }

        private void trackBarBlue_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_TrackBar)
                return;

            ColorMath.UnpackSNES(COLOR, out int r, out int g, out int b);

            b = trackBarBlue.Value;

            UpdateAllColorSliders(ColorMath.RepackSNES(r, g, b), updateRed: false, updateGreen: false, updateBlue: false);

            var prev_Numeric = updateColorValuesIgnore_Numeric;
            updateColorValuesIgnore_Numeric = true;
            {
                numericUpDownBlue.Value = b;
                numericUpDownBlue.Refresh();
            }
            updateColorValuesIgnore_Numeric = prev_Numeric;
        }

        private void trackBarHue_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_TrackBar)
                return;

            int h = trackBarHue.Value;
            int s = trackBarSaturation.Value;
            int l = trackBarLightness.Value;
            UpdateAllColorSliders(ColorMath.HSLtoSNES_Int(h, s, l), updateHue: false, updateSaturation: false, updateLightness: false);

            var prev_Numeric = updateColorValuesIgnore_Numeric;
            updateColorValuesIgnore_Numeric = true;
            {
                numericUpDownHue.Value = h;
                numericUpDownHue.Refresh();
            }
            updateColorValuesIgnore_Numeric = prev_Numeric;
        }

        private void trackBarSaturation_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_TrackBar)
                return;

            //ColorMath.SNEStoHSL_Int(COLOR, out int h, out int s, out int l);

            int h = trackBarHue.Value;
            int s = trackBarSaturation.Value;
            int l = trackBarLightness.Value;
            UpdateAllColorSliders(ColorMath.HSLtoSNES_Int(h, s, l), updateHue: false, updateSaturation: false, updateLightness: false);

            var prev_Numeric = updateColorValuesIgnore_Numeric;
            updateColorValuesIgnore_Numeric = true;
            {
                numericUpDownSaturation.Value = s;
                numericUpDownSaturation.Refresh();
            }
            updateColorValuesIgnore_Numeric = prev_Numeric;

            // When its copied over to graph slider in UpdateAllColorSliders, it does this update in there
            //Meme2();
        }

        private void trackBarLightness_ValueChanged(object sender, EventArgs e)
        {
            if (updateColorValuesIgnore_TrackBar)
                return;

            int h = trackBarHue.Value;
            int s = trackBarSaturation.Value;
            int l = trackBarLightness.Value;
            UpdateAllColorSliders(ColorMath.HSLtoSNES_Int(h, s, l), updateHue: false, updateSaturation: false, updateLightness: false);

            var prev_Numeric = updateColorValuesIgnore_Numeric;
            updateColorValuesIgnore_Numeric = true;
            {
                numericUpDownLightness.Value = l;
                numericUpDownLightness.Refresh();
            }
            updateColorValuesIgnore_Numeric = prev_Numeric;
        }

        private void ParseTextBoxColorHex()
        {
            var parsed = Form1.ManualParseInputString(textBoxColorHex.Text, false, out _);
            if (parsed.Length > 0)
            {
                var color = parsed[0];
                UpdateAllColorSliders(color, updateColorHexAndSwatch: true);
                textBoxColorHex_PC.Text = Form1.GenerateAsmForColors_PC(new[] { COLOR });
                textBoxColorHex_PC.Refresh();
            }
        }

        ushort? snesColorLastGeneratedFromPCColor = null;

        private void ParseTextBoxColorHex_PC()
        {
            var parsed = Form1.ManualParseInputString_PC(textBoxColorHex_PC.Text, false, out _, out Color[] resultPC);
            if (parsed.Length > 0)
            {
                var color = parsed[0];
                var colorPC = resultPC[0];
                UpdateAllColorSliders(color, updateColorHexAndSwatch_PC: true);
                textBoxColorHex.Text = Form1.GenerateAsmForColors(new[] { COLOR });
                textBoxColorHex.Refresh();

                panelPCColorGeneratedFrom.BackColor = colorPC;
                panelPCColorGeneratedFrom.Visible = true;
                panelPCColorGeneratedFrom.Refresh();

                snesColorLastGeneratedFromPCColor = color;
                labelPCColorGeneratedFrom.Text = $"Generated From: #{(colorPC.R.ToString("X2"))}{(colorPC.G.ToString("X2"))}{(colorPC.B.ToString("X2"))}";
                labelPCColorGeneratedFrom.Visible = true;

                //textBoxColorHex_PC.Text = $"#{(colorPC.R.ToString("X2"))}{(colorPC.G.ToString("X2"))}{(colorPC.B.ToString("X2"))}";
                //textBoxColorHex_PC.SelectionStart = textBoxColorHex_PC.Text.Length;
                //textBoxColorHex_PC.SelectionLength = 0;
                //textBoxColorHex_PC.Refresh();
            }
        }

        private void textBoxColorHex_Validating(object sender, CancelEventArgs e)
        {
            ParseTextBoxColorHex();
        }

        private void FormEditSingleColor_Click(object sender, EventArgs e)
        {
            pictureBoxColorField.Focus();
            Focus();
        }

        private void textBoxColorHex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                ParseTextBoxColorHex();
            }
        }

        private void textBoxColorHex_PC_Validating(object sender, CancelEventArgs e)
        {
            ParseTextBoxColorHex_PC();
        }

        private void textBoxColorHex_PC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                ParseTextBoxColorHex_PC();
            }
        }

        private void textBoxColorHex_PC_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRevertColor_Click(object sender, EventArgs e)
        {
            UpdateAllColorSliders(InitColor);
        }

        private void FormEditSingleColor_Activated(object sender, EventArgs e)
        {
            MainFormInst.SetColorLocOfFocusedEditor(ColorLoc);
        }

        private void buttonDbgBenchmark_Click(object sender, EventArgs e)
        {
            benchmarkResults.Clear();
            benchmark = true;
            //TODO - fix this to check Graph_ComponentZ or whatever 
            //for (int i = trackBarGraphZ.Minimum; i <= trackBarGraphZ.Maximum; i++)
            //{
            //    trackBarGraphZ.Value = i;
            //    CopyValueFromTrackBarGraphZ();
            //}
            benchmark = false;
            labelDbgBenchmarkResult.Enabled = true;
            labelDbgBenchmarkResult.Text = $"0x{benchmarkResults.Count.ToString("X4")} colors";
            labelDbgBenchmarkResult.Visible = true;
        }

        private void CopyValueFromTrackBarGraphZ(int value)
        {
            if (updateColorValuesIgnore_TrackBar)
                return;

            int h = trackBarHue.Value;
            int s = trackBarSaturation.Value;
            int l = trackBarLightness.Value;

            //ColorMath.SNEStoHSL_Int(COLOR, out int h, out int s, out int l);
            ColorMath.UnpackSNES(COLOR, out int r, out int g, out int b);

            if (Component_GraphZ is GraphComponents.H or GraphComponents.S or GraphComponents.L)
            {


                if (Component_GraphZ is GraphComponents.H)
                    h = value;
                else if (Component_GraphZ is GraphComponents.S)
                    s = value;
                else if (Component_GraphZ is GraphComponents.L)
                    l = value;
                UpdateAllColorSliders(ColorMath.HSLtoSNES_Int(h, s, l), updateHue: false, updateSaturation: false, updateLightness: false);
            }
            else if (Component_GraphZ is GraphComponents.R or GraphComponents.G or GraphComponents.B)
            {
                if (Component_GraphZ is GraphComponents.R)
                    r = value;
                else if (Component_GraphZ is GraphComponents.G)
                    g = value;
                else if (Component_GraphZ is GraphComponents.B)
                    b = value;
                UpdateAllColorSliders(ColorMath.RepackSNES(r, g, b), updateRed: false, updateGreen: false, updateBlue: false);
            }

            var prev = updateColorValuesIgnore_TrackBar;
            updateColorValuesIgnore_TrackBar = true;
            {
                if (Component_GraphZ == GraphComponents.R)
                    trackBarRed.Value = value;
                else if (Component_GraphZ == GraphComponents.G)
                    trackBarGreen.Value = value;
                else if (Component_GraphZ == GraphComponents.B)
                    trackBarBlue.Value = value;
                else if (Component_GraphZ == GraphComponents.H)
                    trackBarHue.Value = value;
                else if (Component_GraphZ == GraphComponents.S)
                    trackBarSaturation.Value = value;
                else if (Component_GraphZ == GraphComponents.L)
                    trackBarLightness.Value = value;
            }
            updateColorValuesIgnore_TrackBar = prev;

            var prev_Numeric = updateColorValuesIgnore_Numeric;
            updateColorValuesIgnore_Numeric = true;
            {
                if (Component_GraphZ == GraphComponents.R)
                {
                    numericUpDownRed.Value = r;
                    numericUpDownRed.Refresh();
                }
                else if (Component_GraphZ == GraphComponents.G)
                {
                    numericUpDownGreen.Value = g;
                    numericUpDownGreen.Refresh();
                }
                else if (Component_GraphZ == GraphComponents.B)
                {
                    numericUpDownBlue.Value = b;
                    numericUpDownBlue.Refresh();
                }
                else if (Component_GraphZ == GraphComponents.H)
                {
                    numericUpDownHue.Value = h;
                    numericUpDownHue.Refresh();
                }
                else if (Component_GraphZ == GraphComponents.S)
                {
                    numericUpDownSaturation.Value = s;
                    numericUpDownSaturation.Refresh();
                }
                else if (Component_GraphZ == GraphComponents.L)
                {
                    numericUpDownLightness.Value = l;
                    numericUpDownLightness.Refresh();
                }
            }
            updateColorValuesIgnore_Numeric = prev_Numeric;
        }

        private void FormEditSingleColor_SizeChanged(object sender, EventArgs e)
        {
            //UpdateGraphSizeForWindowSize();
        }

        private void comboBoxGraphMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGraphMode.SelectedIndex >= 0 && comboBoxGraphMode.SelectedIndex < graphModeDropdown_Values.Count)
            {
                ChangeGraphMode(graphModeDropdown_Values[comboBoxGraphMode.SelectedIndex]);
            }
            else
            {
                comboBoxGraphMode.SelectedIndex = 0;
            }

            Properties.Settings.Default.LastGraphMode = comboBoxGraphMode.SelectedIndex;
        }

        private void TrackBarGraphZPickMouseLocation(Point location)
        {
            int maxZ = ColorMath.NUM_HUES;

            if (Component_GraphZ is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxZ = 0b11111;
            else if (Component_GraphZ is GraphComponents.H)
                maxZ = ColorMath.NUM_HUES;
            else if (Component_GraphZ == GraphComponents.S)
                maxZ = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphZ == GraphComponents.L)
                maxZ = ColorMath.NUM_LIGHTNESSES;

            var z = (int)Math.Round(((float)location.Y / (float)(pixelPictureBoxGraphZ.Height)) * maxZ);

            if (z < 0)
                z = 0;
            if (z > maxZ)
                z = maxZ;

            z = maxZ - z;

            //var xRatio = ColorMath.Clamp((float)x / (float)pictureBoxColorField.Width, 0, 1);
            //var yRatio = 1 - ColorMath.Clamp((float)y / (float)pictureBoxColorField.Height, 0, 1);


            if (Component_GraphZ is GraphComponents.R)
                trackBarRed.Value = z;
            else if (Component_GraphZ is GraphComponents.G)
                trackBarGreen.Value = z;
            else if (Component_GraphZ is GraphComponents.B)
                trackBarBlue.Value = z;
            else if (Component_GraphZ is GraphComponents.H)
                trackBarHue.Value = z;
            else if (Component_GraphZ == GraphComponents.S)
                trackBarSaturation.Value = z;
            else if (Component_GraphZ == GraphComponents.L)
                trackBarLightness.Value = z;

            pixelPictureBoxGraphZ.Refresh();
        }

        private void pixelPictureBoxGraphZ_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            //float h = (float)trackBarHue.Value / (float)(ColorMath.NUM_HUES);
            //float l = 1 - ((float)trackBarLightness.Value / (float)(ColorMath.NUM_VALUES));

            //int x = (int)Math.Floor(Math.Floor(h * (float)(ColorMath.NUM_HUES)) * ((float)(pictureBoxColorField.Width) / (float)(ColorMath.NUM_HUES + 1)));
            //int y = (int)Math.Floor(Math.Floor(l * (float)(ColorMath.NUM_VALUES)) * ((float)(pictureBoxColorField.Height) / (float)(ColorMath.NUM_VALUES + 1)));

            int maxZ = ColorMath.NUM_LIGHTNESSES;

            if (Component_GraphZ is GraphComponents.R or GraphComponents.G or GraphComponents.B)
                maxZ = 0b11111;
            else if (Component_GraphZ is GraphComponents.H)
                maxZ = ColorMath.NUM_HUES;
            else if (Component_GraphZ == GraphComponents.S)
                maxZ = ColorMath.NUM_SATURATIONS;
            else if (Component_GraphZ == GraphComponents.L)
                maxZ = ColorMath.NUM_LIGHTNESSES;

            int z = 0;

            if (Component_GraphZ is GraphComponents.R)
                z = trackBarRed.Value;
            else if (Component_GraphZ is GraphComponents.G)
                z = trackBarGreen.Value;
            else if (Component_GraphZ is GraphComponents.B)
                z = trackBarBlue.Value;
            else if (Component_GraphZ is GraphComponents.H)
                z = trackBarHue.Value;
            else if (Component_GraphZ == GraphComponents.S)
                z = trackBarSaturation.Value;
            else if (Component_GraphZ == GraphComponents.L)
                z = trackBarLightness.Value;

            z = (int)Math.Round((maxZ - z) * ((float)pixelPictureBoxGraphZ.Height / (float)maxZ));

            const int arrowThicknessY = 4;
            const int arrowThicknessX = 7;

            using (var b = new SolidBrush((ColorMath.GetApparentBrightness(COLOR) < 0.5f) ? Color.White : Color.Black))
            {
                //e.Graphics.FillRectangle(b, 0, z - 1, pixelPictureBoxGraphZ.Width, 3);

                e.Graphics.FillPolygon(b, new Point[]
                {
                    new Point(0, z - arrowThicknessY),
                    new Point(arrowThicknessX, z),
                    new Point(0, z + arrowThicknessY),
                });

                e.Graphics.FillPolygon(b, new Point[]
                {
                    new Point((pixelPictureBoxGraphZ.Width), z - arrowThicknessY),
                    new Point((pixelPictureBoxGraphZ.Width) - arrowThicknessX, z),
                    new Point((pixelPictureBoxGraphZ.Width), z + arrowThicknessY),
                });
            }
        }

        private void pixelPictureBoxGraphZ_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                TrackBarGraphZPickMouseLocation(e.Location);
            }
        }

        private void pixelPictureBoxGraphZ_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                TrackBarGraphZPickMouseLocation(e.Location);
            }
        }

        private void FormEditSingleColor_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBoxColorField?.Image?.Dispose();
            pixelPictureBoxGraphZ?.Image?.Dispose();
        }
    }
}
