namespace Methods.Students
{
    using System;

    public static class Validator
    {
        public static void ValidateNullOrEmptyString(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || max < value)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
