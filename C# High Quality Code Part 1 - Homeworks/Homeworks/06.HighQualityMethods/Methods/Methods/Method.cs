namespace Methods
{
    using System;

    public static class Method
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            bool areSidesPositive = IsNumberPositive(a) && IsNumberPositive(b) && IsNumberPositive(c);

            if (!areSidesPositive)
            {
                throw new ArgumentOutOfRangeException("All sides of the triangle must be positive numbers!");
            }

            if (!IsValidTriangle(a, b, c))
            {
                throw new ArgumentException("Provided sides must form a valid triangle!");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    throw new ArgumentException("Provided number must be a digit");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Elements cannot be null and the should be at least one element provided!");
            }

            int max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintNumberTwoDigitsPrecision(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberInPercentage(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintNumberRightAligned(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distanceX = (x2 - x1) * (x2 - x1);
            double distanceY = (y2 - y1) * (y2 - y1);

            double distance = Math.Sqrt(distanceX + distanceY);
            return distance;
        }

        public static bool IsLineHorizontal(double startX, double endX)
        {
            return startX == endX;
        }

        public static bool IsLineVertical(double startY, double endY)
        {
            return startY == endY;
        }

        private static bool IsNumberPositive(double number)
        {
            bool isPositive = number > 0;

            return isPositive;
        }

        private static bool IsValidTriangle(double a, double b, double c)
        {
            bool isFirstSmaller = a < b + c;
            bool isSecondSmaller = b < a + c;
            bool isThirdSmaller = c < a + b;

            bool isValidTriangle = isFirstSmaller && isSecondSmaller && isThirdSmaller;

            return isValidTriangle;
        }
    }
}
