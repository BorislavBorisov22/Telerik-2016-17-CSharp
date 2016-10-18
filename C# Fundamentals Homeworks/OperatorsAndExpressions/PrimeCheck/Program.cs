using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool isPrime = true;
            if (number <= 1)
            {
                isPrime = false;
            }
            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            

            if (isPrime)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            
        }
    }
}
