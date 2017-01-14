namespace Shapes
{
    using System;

    public abstract class Shape : IShape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
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
                if (!this.IsShapeSideValid(value))
                {
                    throw new ArgumentOutOfRangeException("Shape's width cannot be zero or less");
                }

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
                if (!this.IsShapeSideValid(value))
                {
                    throw new ArgumentOutOfRangeException("Shapes's height cannot be zero or less");
                }

                this.height = value;
            }
        }

        public virtual double CalculateSurface()
        {
            return this.width * this.height;
        }

        private bool IsShapeSideValid(double side)
        {
            if (side <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
