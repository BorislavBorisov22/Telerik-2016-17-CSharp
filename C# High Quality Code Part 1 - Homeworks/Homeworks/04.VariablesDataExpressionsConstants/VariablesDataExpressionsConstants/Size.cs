namespace VariablesDataExpressionsConstants
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be a postive number");
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

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be a positive number");
                }

                this.height = value;
            }
        }

        public static Size GetRotatedSize(Size sizeToRotate, double rotationAngle)
        {
            double widthAfterRotation = (Math.Abs(Math.Cos(rotationAngle)) * sizeToRotate.Width) + (Math.Abs(Math.Sin(rotationAngle)) * sizeToRotate.Width);

            double heightAfterRotation = Math.Abs(Math.Sin(rotationAngle) * sizeToRotate.Width) + Math.Abs(Math.Cos(rotationAngle) * sizeToRotate.Height);

            return new Size(widthAfterRotation, heightAfterRotation);    
        }
    }
}
