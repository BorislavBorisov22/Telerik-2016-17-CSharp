using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFullOfBalls
{
    public class Program
    {
        public static void Main()
        {
            var moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];

            var result = 0;


            var wins = new bool[end + 1];
            wins[0] = true;
            for (int i =1; i <= end; i++)
            {
                foreach (var m in moves)
                {
                    if (m > i)
                    {
                        continue;
                    }


                }
            }


            Console.WriteLine(result);
        }
    }
}
