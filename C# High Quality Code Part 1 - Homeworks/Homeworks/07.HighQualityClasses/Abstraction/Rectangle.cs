namespace Abstraction
{
    using System;

    public class Rectangle : Figure, IFigure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
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

            set
            {          
                Validator.ValidateParameterLength(value, "Width cannot be zero or less!");
                
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
               Validator.ValidateParameterLength(value, "Height cannot be zero or less!");

                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
