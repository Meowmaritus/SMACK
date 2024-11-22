using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//using static SuperMetroidPaletteTool.Form1;

namespace SuperMetroidPaletteTool
{
    public static class ColorMath
    {
        public enum GradientTypes
        {
            RGB,
            HSV,
            EntireValue
        }

        public static Vector3 Lerp(Vector3 value1, Vector3 value2, float amount)
        {
            var x = Lerp(value1.X, value2.X, amount);
            var y = Lerp(value1.Y, value2.Y, amount);
            var z = Lerp(value1.Z, value2.Z, amount);
            return new Vector3(x, y, z);
        }

        public static float Lerp(float value1, float value2, float amount)
        {
            return value1 + (value2 - value1) * amount;
        }

        public static Color SNEStoPC(ushort c)
        {
            int r = (c & 0b11111) * 8;
            int g = ((c >> 5) & 0b11111) * 8;
            int b = ((c >> 10) & 0b11111) * 8;
            return Color.FromArgb(r, g, b);
        }

        public static ushort PCtoSNES(Color c)
        {
            return RepackSNES(c.R / 8, c.G / 8, c.B / 8);
        }

        public static Vector3 PCtoVEC3(Color c)
        {
            return new Vector3(c.R / 255f, c.G / 255f, c.B / 255f);
        }

        public static Vector3 SNEStoVEC3(ushort c)
        {
            return PCtoVEC3(SNEStoPC(c));
        }

        public static ushort VEC3toSNES(Vector3 c)
        {
            return PCtoSNES(VEC3toPC(c));
        }

        public static float GetApparentBrightness(ushort snes)
        {
            return GetApparentBrightness(SNEStoVEC3(snes));
        }

        public static float GetApparentBrightness(Color pc)
        {
            return GetApparentBrightness(PCtoVEC3(pc));
        }

        public static float GetApparentBrightness(Vector3 vec3)
        {
            return (float)(0.3086 * vec3.X + 0.6094 * vec3.Y + 0.0820 * vec3.Z);
        }

        public static Color VEC3toPC(Vector3 c)
        {

            int r = (int)Math.Round(Clamp(c.X, 0, 1) * 255f);
            int g = (int)Math.Round(Clamp(c.Y, 0, 1) * 255f);
            int b = (int)Math.Round(Clamp(c.Z, 0, 1) * 255f);



            return Color.FromArgb(r, g, b);
        }

        public static Vector3 SNEStoHSL(ushort snes)
        {
            return RGBtoHSL(SNEStoVEC3(snes));
        }

        public const int NUM_HUES = 128;
        public const int NUM_LIGHTNESSES = 128;
        public const int NUM_SATURATIONS = 31;

        public static void SNEStoHSL_Int(ushort snes, out int h, out int s, out int v)
        {
            var hsl = SNEStoHSL(snes);
            h = (int)Math.Round(Clamp(hsl.X, 0, 1) * (float)NUM_HUES);
            s = (int)Math.Round(Clamp(hsl.Y, 0, 1) * (float)NUM_SATURATIONS);
            v = (int)Math.Round(Clamp(hsl.Z, 0, 1) * (float)NUM_LIGHTNESSES);
        }

        public static ushort HSLtoSNES(Vector3 hsl)
        {
            return VEC3toSNES(HSLtoRGB(hsl));
        }

        public static ushort HSLtoSNES_Int(int h, int s, int l)
        {
            return HSLtoSNES(new Vector3(
                (float)h / (float)NUM_HUES, 
                (float)s / (float)NUM_SATURATIONS, 
                (float)l / (float)NUM_LIGHTNESSES));
        }

        public static void UnpackSNES(ushort snes, out int r, out int g, out int b)
        {
            r = (snes & 0b11111);
            g = ((snes >> 5) & 0b11111);
            b = ((snes >> 10) & 0b11111);
        }

        public static ushort RepackSNES(int r, int g, int b)
        {
            return (ushort)(r | (g << 5) | (b << 10));
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        // Loosely based on Unity's Mathf.Repeat
        public static float Repeat(float t, float length)
        {
            return Clamp(t - (float)Math.Floor(t / length) * length, 0.0f, length);
        }

        // Loosely based on Unity's Mathf.LerpAngle
        public static float LerpAngle(float a, float b, float t)
        {
            float delta = Repeat((b - a), 360);
            if (delta > 180)
                delta -= 360;
            return a + delta * Clamp(t, 0, 1);
        }

        private static void MinMaxRgb(out float min, out float max, float r, float g, float b)
        {
            if (r > g)
            {
                max = r;
                min = g;
            }
            else
            {
                max = g;
                min = r;
            }
            if (b > max)
            {
                max = b;
            }
            else if (b < min)
            {
                min = b;
            }
        }

        public static float GetHueForVector3(Vector3 input)
        {
            if (input.X == input.Y && input.Y == input.Z)
                return 0;
            MinMaxRgb(out float min, out float max, input.X, input.Y, input.Z);

            float delta = max - min;
            float hue;

            if (input.X == max)
                hue = (input.Y - input.Z) / delta;
            else if (input.Y == max)
                hue = (input.Z - input.X) / delta + 2f;
            else
                hue = (input.X - input.Y) / delta + 4f;

            hue *= 60f;
            if (hue < 0f)
                hue += 360f;

            return hue;
        }

        public static ushort GetGradientColor(ushort a, ushort b, GradientTypes type, int i, int count, float curveEaseMemeValue)
        {
            if (i == 0)
                return a;
            if (i == (count - 1))
                return b;

            // HYPER SPECIFIC HEURISTIC BULLSHIT I'M SORRY
            float superMeme = curveEaseMemeValue > 0 
                ? MathF.Pow(curveEaseMemeValue, 2) : 
                1 - (MathF.Pow(MathF.Abs(1 - curveEaseMemeValue), 0.5f));
            float ratio = ((float)i - Clamp(superMeme, -0.5f, 0.5f)) 
                / ((float)count + Clamp(superMeme, -2f, 2f));

            if (ratio < 0)
                ratio = 0;

            if (ratio > 1)
                ratio = 1;

            float origRatio = ratio;

            //ratio *= 2;

            if (curveEaseMemeValue > 0)
            {
                ratio = 1 - ratio;
                ratio = MathF.Pow(ratio, 1 + curveEaseMemeValue);
                ratio = 1 - ratio;

                //ratio = Lerp(origRatio, ratio, 1 - MathF.Pow(1 - origRatio, 2));
            }
            else
            {
                ratio = MathF.Pow(ratio, 1 + MathF.Abs(curveEaseMemeValue));
                //ratio = Lerp(ratio, origRatio, 1 - MathF.Pow(1 - origRatio, 2));
            }

            //ratio *= 0.5f;

            

            if (type is GradientTypes.EntireValue)
            {
                var c = Color.Red;
                return (ushort)(int)Math.Round(Lerp((float)a, (float)b, ratio));
            }
            else if (type is GradientTypes.RGB)
            {
                Vector3 va = SNEStoVEC3(a);
                Vector3 vb = SNEStoVEC3(b);
                return VEC3toSNES(
                    new Vector3(
                        Lerp(va.X, vb.X, ratio),
                        Lerp(va.Y, vb.Y, ratio),
                        Lerp(va.Z, vb.Z, ratio)));
            }
            else if (type is GradientTypes.HSV)
            {
                Vector3 va = SNEStoVEC3(a);
                Vector3 vb = SNEStoVEC3(b);

                Vector3 hslA = NewRGBtoHSV(va);
                Vector3 hslB = NewRGBtoHSV(vb);

                // Testing
                //hslA.X = SnesColorToWinformsColor(a).GetHue() / 360f;
                //hslB.X = SnesColorToWinformsColor(b).GetHue() / 360f;
                //hslA.X = GetHueForVector3(va) / 360f;
                //hslB.X = GetHueForVector3(vb) / 360f;

                var hsl = new Vector3(
                        ((LerpAngle(((hslA.X) * 360), ((hslB.X) * 360), ratio)) / 360f),
                        Lerp(hslA.Y, hslB.Y, ratio),
                        Lerp(hslA.Z, hslB.Z, ratio));

                //hsl.Y = 0.5f;
                //hsl.Z = 0.5f;

                return VEC3toSNES(
                    NewHSVtoRGB(hsl));
            }
            return a;
        }

        public static float ColorEpsilon = 0.0000000001f;//1e-10f;  //0.0000000001 ?                  

        public static Vector3 RGBtoHCV(Vector3 rgb)
        {
            // Based on work by Sam Hocevar and Emil Persson
            Vector4 P = (rgb.Y < rgb.Z) ? new Vector4(rgb.Z, rgb.Y, -1.0f, 2.0f / 3.0f) : new Vector4(rgb.Y, rgb.Z, 0.0f, -1.0f / 3.0f);
            Vector4 Q = (rgb.X < P.X) ? new Vector4(P.X, P.Y, P.W, rgb.X) : new Vector4(rgb.X, P.Y, P.Z, P.X);
            float C = Q.X - Math.Min(Q.W, Q.Y);
            float H = (float)(Math.Abs((Q.W - Q.Y) / (6.0f * C + ColorEpsilon) + Q.Z));
            return new Vector3(H, C, Q.X);
        }

        public static Vector3 RGBtoHSL(Vector3 rgb)
        {
            Vector3 HCV = RGBtoHCV(rgb);
            float L = HCV.Z - HCV.Y * 0.5f;
            float S = (float)(HCV.Y / (1.0f - Math.Abs(L * 2.0f - 1.0f) + ColorEpsilon));
            return new Vector3(HCV.X, S, L);
        }

        public static Vector3 HUEtoRGB(float h)
        {
            float r = (float)(Math.Abs(h * 6.0f - 3.0f) - 1.0f);
            float g = (float)(2.0f - Math.Abs(h * 6.0f - 2.0f));
            float b = (float)(2.0f - Math.Abs(h * 6.0f - 4.0f));
            return new Vector3(Math.Max(Math.Min(r, 1.0f), 0.0f), Math.Max(Math.Min(g, 1.0f), 0.0f), Math.Max(Math.Min(b, 1.0f), 0.0f));
        }


        public static Vector3 HSVtoRGB(Vector3 hsv)
        {
            Vector3 rgb = HUEtoRGB(hsv.X);
            return new Vector3(((rgb.X - 1.0f) * hsv.Y + 1.0f) * hsv.Z, ((rgb.Y - 1.0f) * hsv.Y + 1.0f) * hsv.Z, ((rgb.Z - 1.0f) * hsv.Y + 1.0f) * hsv.Z);
        }


        public static Vector3 HSLtoRGB(Vector3 hsl)
        {
            Vector3 rgb = HUEtoRGB(hsl.X);
            float C = (float)((1.0f - Math.Abs(2.0f * hsl.Z - 1.0f)) * hsl.Y);
            return new Vector3((rgb.X - 0.5f) * C + hsl.Z, (rgb.Y - 0.5f) * C + hsl.Z, (rgb.Z - 0.5f) * C + hsl.Z);
        }

        public static Vector3 NewRGBtoHSV(Vector3 color)
        {
            // old hue = (float)(Math.Atan2((Math.Sqrt(3) * color.Y - color.Z), 2 * color.X - color.Y - color.Z) / Math.PI / 2)
            float hue = ColorMath.GetHueForVector3(color) / 360f;
            float max = Math.Max(color.X, Math.Max(color.Y, color.Z));
            float min = Math.Min(color.X, Math.Min(color.Y, color.Z));

            return new Vector3(
                 hue,
                 (float)((max == 0) ? 0 : 1d - (1d * min / max)),
                 max);
        }

        public static Vector3 NewHSVtoRGB(Vector3 input)
        {
            float hue = input.X * 360;
            float saturation = input.Y;
            float value = input.Z;
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60f - Math.Floor(hue / 60f);

            //value = value * 255;
            float v = (float)(value);
            float p = (float)(value * (1 - saturation));
            float q = (float)(value * (1 - f * saturation));
            float t = (float)(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return new Vector3(v, t, p);
            else if (hi == 1)
                return new Vector3(q, v, p);
            else if (hi == 2)
                return new Vector3(p, v, t);
            else if (hi == 3)
                return new Vector3(p, q, v);
            else if (hi == 4)
                return new Vector3(t, p, v);
            else
                return new Vector3(v, p, q);
        }
    }
}
