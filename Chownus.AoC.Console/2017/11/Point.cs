using System;

namespace Chownus.AoC.Console
{
    public class Point
    {
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X;
        public int Y;
        public int Z;


        public Point AddPoint(Point other)
        {
            return new Point(this.X + other.X, this.Y + other.Y, this.Z + other.Z);
        }

        public int CalculateDistance()
        {
            return (Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z)) / 2;
        }
    }
}