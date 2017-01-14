namespace RangeException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T startOfRange, T endOfRange)
            : base(string.Format("{0}\nInvalid range of the values! Values must be in the range {1} - {2}.", message, startOfRange, endOfRange))
        {
            this.StartOfRange = startOfRange;
            this.EndOfRange = endOfRange;
        }

        public T StartOfRange { get; set; }

        public T EndOfRange { get; set; }
    }
}