using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCirlceRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
                double x = double.Parse(Console.ReadLine());
                double y = double.Parse(Console.ReadLine());
                double radiusCircle = 1.5;
                bool isInsideCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= radiusCircle * radiusCircle;
                bool isInsideRectangle = x >= -1 && x <= 5 && y <= 1 && y >= -1;
                
            if (isInsideCircle)
            {
                Console.Write("inside circle ");
            }
            else
            {
                Console.Write("outside circle ");
            }


            if (isInsideRectangle)
            {
                Console.WriteLine("inside rectangle");
            }
            else
            {
                Console.WriteLine("outside rectangle");
            }


                

            
           
        }
    }
}
