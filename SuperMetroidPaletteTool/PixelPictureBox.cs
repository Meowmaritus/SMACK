using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SuperMetroidPaletteTool
{
    internal class PixelPictureBox : PictureBox
    {
        public struct BitmapPixelStruct
        {
            public byte B;
            public byte G;
            public byte R;
            //public byte A;
        }

        private GCHandle Handle;

        public BitmapPixelStruct[,] TestBitmapPixels { get; private set; }

        public void InitializePixels(int width, int height)
        {
            int stride = width;

            if (stride < 4)
                stride = 4;

            if (stride % 4 != 0)
                stride += (4 - (stride % 4));

            if (Handle.IsAllocated)
                Handle.Free();
            Image?.Dispose();
            TestBitmapPixels = new BitmapPixelStruct[height, stride];

            Handle = GCHandle.Alloc(TestBitmapPixels, GCHandleType.Pinned);

            nint test = System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(TestBitmapPixels, 0);

            Image?.Dispose();
            Image = new Bitmap(width, height, stride * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, test);
        }

        protected override void Dispose(bool disposing)
        {

            if (Handle.IsAllocated)
                Handle.Free();

            Image?.Dispose();

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pe.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            base.OnPaint(pe);
        }
    }
}
