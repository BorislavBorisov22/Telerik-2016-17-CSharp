using System;


namespace FibonacciNumbers
{
    class FibonacciNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int firstFibonacciNumber = 0;
            int secondFibonacciNumber = 1;
            int thirdFibonacciNumber = 0;

            Console.Write("{0}, {1}, ",firstFibonacciNumber,secondFibonacciNumber);
           

            for (int i = 0; i < n - 2; i++)
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
