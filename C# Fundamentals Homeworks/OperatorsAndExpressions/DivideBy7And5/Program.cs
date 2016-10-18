using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideBy7And5
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isDIvisible = number % 5 == 0 && number % 7 == 0;
            if (isDIvisible)
            {
                Console.WriteLine("true " + number);
            }
            else
            {
                Console.WriteLine("false " + number);
            }
           
            
        }
    }
}
