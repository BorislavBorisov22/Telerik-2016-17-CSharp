namespace Coordinates
{
    using System.Text;

    public struct Point3D
    {
        private static readonly Point3D CoordinateSystemStartPoint = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D StartPoint
        {
            get
            {
                return CoordinateSystemStartPoint;
            }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("{0}, {1}, {2}", this.X, this.Y, this.Z);

            return result.ToString().Trim();
        }
    }
}
