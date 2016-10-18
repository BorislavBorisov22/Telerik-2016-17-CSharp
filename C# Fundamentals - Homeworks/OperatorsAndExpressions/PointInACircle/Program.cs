using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInACircle
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            x = Math.Abs(x);
            double y = double.Parse(Console.ReadLine());
            y = Math.Abs(y);
            double radius = 2;
            double pointDistanceFromCenter = Math.Sqrt((x * x) + (y * y));
            bool isInside = pointDistanceFromCenter <= radius;

            if (isInside)
            {
                Console.WriteLine("yes {0:f2}",pointDistanceFromCenter);
                
            }
            else
            {
                Console.WriteLine("no {0:f2}",pointDistanceFromCenter);
                
            }
        }
    }
}
