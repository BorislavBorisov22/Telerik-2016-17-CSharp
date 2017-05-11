using System;

namespace AcademyEcosystem
{
    public struct Point : IPoint
    {
        private readonly int x;

        private readonly int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(string xString, string yString)
        {
            this.x = int.Parse(xString);
            this.y = int.Parse(yString);
        }

        public int X
        {
            get
            {
                return this.x;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
        }

        public static IPoint Parse(string pointString)
        {
            string coordinatesPairString = pointString.Substring(1, pointString.Length - 2);
            string[] coordinates = coordinatesPairString.Split(',');

            return new Point(coordinates[0], coordinates[1]);
        }

        public static int GetManhattanDistance(IPoint a, IPoint b)
        {
            return Math.Abs(a.X - b.Y) + Math.Abs(a.X - b.Y);
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.x, this.y);
        }

        public override int GetHashCode()
        {
            return (this.x * 7) + this.y;
        }
    }
}
