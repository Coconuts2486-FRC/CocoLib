using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoLib.Pixy
{
    public class PixyBlock
    {
        public int Sync;
        public int Checksum;
        public int Signature;
        public int CenterX;
        public int CenterY;
        public int Width;
        public int Height;
    }
}
