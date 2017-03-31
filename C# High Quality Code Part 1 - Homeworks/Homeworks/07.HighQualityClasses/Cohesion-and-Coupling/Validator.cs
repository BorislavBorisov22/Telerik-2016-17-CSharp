namespace CohesionAndCoupling
{
    using System;

    public static class Validator
    {
        public static void ValidatePositiveDouble(double value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateNullOrEmptyString(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
