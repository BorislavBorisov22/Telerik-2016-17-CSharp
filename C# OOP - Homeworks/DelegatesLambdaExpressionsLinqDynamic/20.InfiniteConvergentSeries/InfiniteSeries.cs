namespace InfiniteConvergentSeries
{
    using System;

    public static class InfiniteSeries
    {
        public static decimal GetSum(
            decimal firstArgument,
            decimal secondArgument,
            Func<decimal, decimal, decimal> sum,
            Func<decimal, decimal> changeFirstArg,
            Func<decimal, decimal> changeSecondArg)
        {
            decimal totalSum = 0;

            decimal previousSum;

            while (true)
            {
                previousSum = totalSum;

                totalSum += sum(firstArgument, secondArgument);
                firstArgument = changeFirstArg(firstArgument);
                secondArgument = changeSecondArg(secondArgument);

                if (Math.Abs(totalSum - previousSum) < 0.0000001m)
                {
                    return totalSum;
                }
            }
        }

        public static decimal Factorial(decimal number)
        {
            decimal result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
