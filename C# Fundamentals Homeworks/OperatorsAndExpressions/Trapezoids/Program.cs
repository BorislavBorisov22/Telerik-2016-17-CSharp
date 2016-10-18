using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoids
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double trapezoidArea = height *( (sideA + sideB) / 2);

            Console.WriteLine("{0:f7}",trapezoidArea);
        }
    }
}
