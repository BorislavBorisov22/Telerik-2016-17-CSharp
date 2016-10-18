using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExchange
{
    class BitExchange
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            long thirdBit = (number >> 3) & 1;
            long fourthBit = (number >> 4) & 1;
            long fifthBit = (number >> 5) & 1;

            long twentyFourthBit = (number >> 24) & 1;
            long twentyFifthBit = (number >> 25) & 1;
            long twentySixthBIt = (number >> 26) & 1;

            if (thirdBit == 1)
            {
                long mask = 1 << 24;
                number = number | mask;
            }
            else
            {
                long mask = ~(1 << 24);
                number = number & mask;
            }
            if (fourthBit == 1)
            {
                long mask = 1 << 25;
                number = number | mask;
            }
            else
            {
                long mask = ~(1 << 25);
                number = number & mask;
            }
            if (fifthBit == 1)
            {
                long mask = 1 << 26;
                number = number | mask;
            }
            else
            {
                long mask = ~(1 << 26);
                number = number & mask;
            }
            if (twentyFourthBit == 1)
            {
                long mask = 1 << 3;
                number = number | mask;
            }
            else
            {
                long mask = ~(1 << 3);
                number = number & mask;
            }
            if (twentyFifthBit == 1)
            {
                long mask = 1 << 4;
                number = number | mask;
            }
            else
            {
                long mask = ~(1 << 4);
                number = number & mask;
            }
            if (twentySixthBIt == 1)
            {
                long mask = 1 << 5;
                number = number | mask;
            }
            else
            {
                long mask = ~(1 << 5);
                number = number & mask;
            }
            Console.WriteLine(number);


        }
    }
}
