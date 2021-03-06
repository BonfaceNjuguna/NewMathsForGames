using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixclasses
{
    public class Colour
    {
        public UInt32 colour;
        public Colour() { colour = 0; }
        public Colour(byte red, byte green, byte blue, byte alpha) 
        {
            SetGreen(green);
            SetRed(red);
            SetBlue(blue);
            SetAlpha(alpha);
        }

        public byte GetRed()
        {
            UInt32 rValue = colour & 0xff000000;
            return (byte)((colour & 0xff000000) >> 24);
        }
        public void SetRed(byte red) 
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)red << 24;
        }
        public byte GetGreen() 
        {
            UInt32 gValue = colour & 0x00ff0000;
            return (byte)((colour & 0x00ff0000) >> 16);
        }
        public void SetGreen(byte green) 
        {
            colour = colour & 0xff00ffff;
            colour |= (UInt32)green << 16;
        }
        public byte GetBlue() 
        {
            UInt32 bValue = colour & 0x0000ff00;
            return (byte)((colour & 0x0000ff00) >> 8);          
        }
        public void SetBlue(byte blue) 
        {
            colour = colour & 0xffff00ff;
            colour |= (UInt32)blue << 8;
        }
        public byte GetAlpha() 
        {
            UInt32 aValue = colour & 0x000000ff;
            return (byte)((colour & 0x000000ff));
        }
        public void SetAlpha(byte alpha) 
        {
            colour = colour & 0xffffff00;
            colour |= (UInt32)alpha;
        }
    }
}
