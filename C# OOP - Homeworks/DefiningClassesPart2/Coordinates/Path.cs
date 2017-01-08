namespace Coordinates
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        public Path()
        {
            this.Points = new List<Point3D>();
        }

        public List<Point3D> Points { get; set; }
       
        public void AddPoint(Point3D point)
        {
            this.Points.Add(point);
        }

        public override string ToString()
        {
            return string.Join("\n\r", this.Points);
        }
    }
}
