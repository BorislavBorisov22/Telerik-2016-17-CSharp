using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLoses
{
    public class Program
    {
        static string targetCode;

        public static void Main()
        {
            var initialCode = Console.ReadLine();
            targetCode = Console.ReadLine();

            var forbidden = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                forbidden.Add(Console.ReadLine());
            }

            var result = 0;
            for (int i = 0; i < initialCode.Length; i++)
            {
                result += Math.Abs((initialCode[i] - '0') - (targetCode[i] - '0'));   
            }

            Console.WriteLine(result);
        }

        static int min = int.MaxValue;

        public static void Solve(int index, string currentCode, HashSet<string> forbidden, int steps)
        {
            if (index >= currentCode.Length)
            {
                if (currentCode == targetCode)
                {
                    if (steps < min)
                    {
                        min = steps;
                    }
                }

                return;
            }

            int currentDigit = currentCode[index] - '0';
            int targetDigit = currentCode[index] - '0';
        }
    }
}
