namespace CohesionAndCoupling.Figures
{
    public class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                Validator.ValidatePositiveDouble(value, "Figure width must be a positive number!");

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                Validator.ValidatePositiveDouble(value, "Height must be a positive number!");

                this.height = value;
            }
        }

        public double CalcDiagonalXY()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }
    }
}
