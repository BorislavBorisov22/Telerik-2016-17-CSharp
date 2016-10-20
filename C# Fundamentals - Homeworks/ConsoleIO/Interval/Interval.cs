using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interval
{
    class Interval
    {
        static void Main(string[] args)
        {
            int startingNumber = int.Parse(Console.ReadLine());
            int endingNumber = int.Parse(Console.ReadLine());
            int dividedByFiveCount = 0;
            for (int i=startingNumber;i<= endingNumber; i++)
            {
                if (i % 5 == 0)
                {
                    dividedByFiveCount++;
                }
            }
            Console.WriteLine(dividedByFiveCount);
        }
    }
}
