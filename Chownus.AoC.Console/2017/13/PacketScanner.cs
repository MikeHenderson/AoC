﻿namespace Chownus.AoC.Console._2017._13
{
    public class PacketScanner
    {
        public int Depth;

        public bool WillHit(int picoseconds)
        {
            return picoseconds % (2 * (Depth - 1)) == 0;
        }
    }
}