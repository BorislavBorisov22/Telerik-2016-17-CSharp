using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            char thirdDigit = '0';
       
            if (number.Length >= 3)
            {
                thirdDigit = number[number.Length - 3];
            }
            
            if (thirdDigit == '7')
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false {0}",thirdDigit);
            }
        }
    }
}
