using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingFloats
{
    class Program
    {
        static void Main(string[] args)
        {

            double firstNumber = Math.Abs(double.Parse(Console.ReadLine()));
            double secondNumer = Math.Abs(double.Parse(Console.ReadLine()));
            double eps = 0.000001;

            double diff = 0;
            if (firstNumber > secondNumer)
            {
                diff = firstNumber - secondNumer;
            }
            else
            {
                diff = secondNumer - firstNumber;
            }


            string output = diff < eps ? "true" : "false";

            Console.WriteLine(output);
        }
    }
}
