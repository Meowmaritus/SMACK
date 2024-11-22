using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMetroidPaletteTool
{
    public struct ColorLocation
    {
        public enum ColorLocationTypes
        {
            InputFROM,
            InputTO,
            Output,
        }

        public ColorLocationTypes LocationType;
        public int Index;
    }
}
