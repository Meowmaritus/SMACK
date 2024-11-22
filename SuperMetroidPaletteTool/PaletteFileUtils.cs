using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMetroidPaletteTool
{
    internal class PaletteFileUtils
    {

        public static ushort[] ReadTPL(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return ReadTPL(stream);
            }
        }

        public static ushort[] ReadTPL(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                return ReadTPL(stream);
            }
        }

        public static ushort[] ReadTPL(Stream stream)
        {
            List<ushort> result = new List<ushort>(16);
            //54 50 4C 00
            using (var br = new BinaryReader(stream, Encoding.ASCII, leaveOpen: true))
            {
                br.BaseStream.Position += 4;
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    byte r = (byte)(br.ReadByte() / 8);
                    byte g = (byte)(br.ReadByte() / 8);
                    byte b = (byte)(br.ReadByte() / 8);
                    result.Add((ushort)((r & 0b11111) | ((g & 0b11111) << 5) | ((b & 0b11111) << 10)));
                }
            }

            return result.ToArray();
        }


        public static ushort[] ReadPAL(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return ReadPAL(stream);
            }
        }

        public static ushort[] ReadPAL(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                return ReadPAL(stream);
            }
        }

        public static ushort[] ReadPAL(Stream stream)
        {
            List<ushort> result = new List<ushort>(16);
            using (var br = new BinaryReader(stream, Encoding.ASCII, leaveOpen: true))
            {
                // No magic in PAL
                //br.BaseStream.Position += 4;
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    byte r = (byte)(br.ReadByte() / 8);
                    byte g = (byte)(br.ReadByte() / 8);
                    byte b = (byte)(br.ReadByte() / 8);
                    result.Add((ushort)((r & 0b11111) | ((g & 0b11111) << 5) | ((b & 0b11111) << 10)));
                }
            }

            return result.ToArray();
        }
    }
}
