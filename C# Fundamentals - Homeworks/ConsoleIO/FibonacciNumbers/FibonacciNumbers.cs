using System;


namespace FibonacciNumbers
{
    class FibonacciNumbers
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            long firstFibonacciNumber = 0;
            long secondFibonacciNumber = 1;
            long thirdFibonacciNumber = 0;

            Console.Write("{0}, {1}, ",firstFibonacciNumber,secondFibonacciNumber);
           

            for (long i = 0; i < n - 2; i++)
            {
                
                thirdFibonacciNumber = firstFibonacciNumber + secondFibonacciNumber;
                if (i != n - 3)
                {
                    Console.Write(thirdFibonacciNumber+ ", ");
                }
                else
                {
                    Console.WriteLine(thirdFibonacciNumber);
                }
                
                firstFibonacciNumber = secondFibonacciNumber;
                secondFibonacciNumber = thirdFibonacciNumber;
            }
        }
    }
}
