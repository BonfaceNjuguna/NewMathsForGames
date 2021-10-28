﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixclasses
{
    public class Colour
    {
        public UInt32 colour;
        public Colour() {}
        public Colour(byte red, byte green, byte blue, byte alpha) 
        {
            red = 255;
            green = 255;
            blue = 255;
            alpha = 255;
        }

        public byte GetRed()
        {
            return (byte)((colour & 0xff000000) >> 24);
            UInt32 value = colour & 0xff000000;
        }
        public void SetRed(byte red) 
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)red << 24;
        }
        public byte GetGreen() 
        {
            return (byte)((colour & 0x00ff0000) >> 24);
            UInt32 value = colour & 0x00ff0000;
        }
        public void SetGreen(byte green) 
        {
            colour = colour & 0xff00ffff;
            colour |= (UInt32)green << 24;
        }
        public byte GetBlue() 
        {
            return (byte)((colour & 0x0000ff00) >> 24);
            UInt32 value = colour & 0x0000ff00;
        }
        public void SetBlue(byte blue) 
        {
            colour = colour & 0x00ff00ff;
            colour |= (UInt32)blue << 24;
        }
        public byte GetAlpha() 
        {
            return (byte)((colour & 0x000000ff) >> 24);
            UInt32 value = colour & 0x000000ff;
        }
        public void SetAlpha(byte alpha) 
        {
            colour = colour & 0xffffff00;
            colour |= (UInt32)alpha << 24;
        }
    }
}