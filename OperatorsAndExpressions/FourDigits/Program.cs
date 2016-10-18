using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int a = number[0] - '0';
            int b = number[1] - '0';
            int c = number[2] - '0';
            int d = number[3] - '0';

            int sumDigits = a + b + c + d;
            Console.WriteLine(sumDigits);
            Console.WriteLine("{0}{1}{2}{3}",d,c,b,a);
            Console.WriteLine("{0}{1}{2}{3}",d,a,b,c);
            Console.WriteLine("{0}{1}{2}{3}", a,c,b,d);



        }
    }
}
