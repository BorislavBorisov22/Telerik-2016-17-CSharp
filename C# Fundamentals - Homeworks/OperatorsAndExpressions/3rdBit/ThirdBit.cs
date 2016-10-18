using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdBit
{
    class ThirdBit
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int mask = 1 << 3;
            int numberAndMask = number & mask;
            int bit = numberAndMask >> 3;
            Console.WriteLine(bit);


            //int bit = (number >> 3) & 1; - shorter solution
            
        }
    }
}
