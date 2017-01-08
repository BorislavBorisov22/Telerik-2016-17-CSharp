namespace StringBuilder.Extensions
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder input, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= input.Length || length < 0)
            {
                throw new IndexOutOfRangeException("StartIndex or length is less than zero..");
            }

            if (startIndex + length - 1 >= input.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex plus length indicates a position not within this instance.");
            }

            var result = new StringBuilder();
            int currentIndex = startIndex;
            while (length > 0)
            {
                result.Append(input[currentIndex]);
                currentIndex++;
                length--;
            }

            return result;
        }

        public static StringBuilder Substring(this StringBuilder input, int startIndex)
        {
            if (startIndex < 0 || startIndex >= input.Length)
            {
                throw new ArgumentOutOfRangeException("StartIndex must be between zero and StringBuilder's length -1");
            }

            var result = new StringBuilder();

            for (int i = startIndex; i < input.Length; i++)
            {
                result.Append(input[i]);
            }

            return result;
        }
    }
}
