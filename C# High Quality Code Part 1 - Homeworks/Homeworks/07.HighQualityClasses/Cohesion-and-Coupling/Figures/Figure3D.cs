namespace CohesionAndCoupling.Figures
{
    using System;

    public class Figure3D : Figure
    {
        private double depth;

        public Figure3D(double width, double height, double depth)
            : base(width, height)
        {
            this.Depth = depth;  
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                Validator.ValidatePositiveDouble(value, "Figure depth must be a positive number!");

                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = DistanceCalculator.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
