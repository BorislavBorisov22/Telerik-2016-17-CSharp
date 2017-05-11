using SchoolSystem.Contracts;
using System;

namespace SchoolSystem.Models
{
    public class Validator : IValidator
    {
        public void ValidateNullOrEmptyString(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public void ValidateValueRange<T>(T min, T max, T value, string message) where T : IComparable
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public void ValidateStringLatinLetters(string value, string message)
        { 
            for (int i = 0; i < value.Length; i++)
            {
                bool smallLatin = value[i] >= 'a' && value[i] <= 'z';
                bool bigLatin = value[i] >= 'A' && value[i] <= 'Z';

                if (!smallLatin && !bigLatin)
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public void ValidateNullObject(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
