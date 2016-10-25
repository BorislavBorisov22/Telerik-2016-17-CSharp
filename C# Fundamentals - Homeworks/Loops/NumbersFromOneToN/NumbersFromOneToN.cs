using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersFromOneToN
{
    class NumbersFromOneToN
    {
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                if (i == n)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
