namespace InheritanceAndPolymorphism
{
    using System;

    public static class Validator
    {
        public static void ValidateNullObject(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
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
