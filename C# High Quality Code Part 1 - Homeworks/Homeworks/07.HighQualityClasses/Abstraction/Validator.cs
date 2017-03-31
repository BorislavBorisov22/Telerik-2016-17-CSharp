namespace Abstraction
{
    using System;

    public static class Validator
    {
        public static void ValidateParameterLength(double length, string message)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
