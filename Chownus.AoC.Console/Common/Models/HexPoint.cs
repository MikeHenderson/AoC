using System;

namespace Chownus.AoC.Console.Common.Models
{
    public class HexPoint
    {
        public HexPoint(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X;
        public int Y;
        public int Z;


        public HexPoint AddPoint(HexPoint other)
        {
            return new HexPoint(X + other.X, Y + other.Y, Z + other.Z);
        }

        public int CalculateDistanceToRoot()
        {
            return (Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z)) / 2;
        }
    }
}