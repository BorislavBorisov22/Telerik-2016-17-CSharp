namespace StudentsAndCourses
{
    using System;

    public static class Validator
    {
        public static void StringNullOfEmpty(string str, string message = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ObjectIsNull(object obj, string message = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ValidateIntRange(int value, int min, int max, string message = null)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
