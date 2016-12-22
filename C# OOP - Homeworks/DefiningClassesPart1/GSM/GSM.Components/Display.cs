namespace GSM.Components
{
    using System;
    using System.Text;

    public class Display
    {
        private double? size;
        private int? numberOfColors;

        public Display(double? initialSize = null, int? initialColors = null)
        {
            this.Size = initialSize;
            this.NumberOfColors = initialColors;
        }

        public double? Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Size of display cannot be zero or less");
                }

                this.size = value;
            }
        }

        public int? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                if (value <= 1)
                {
                    throw new ArgumentOutOfRangeException("Display colors cannot be less than two");
                }

                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("Size: {0} inches, Number of colors: {1}", this.Size, this.NumberOfColors);

            return output.ToString().Trim();
        }
    }
}
