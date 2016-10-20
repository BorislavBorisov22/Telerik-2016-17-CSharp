using System;

namespace QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double discriminant = (b * b) - 4 * (a * c);

            if (discriminant > 0)
            {
                double firstRoot = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double secondRoot = (-b - Math.Sqrt(discriminant)) / (2 * a);
                if (firstRoot < secondRoot)
                {
                    Console.WriteLine("{0:f2}", firstRoot);
                    Console.WriteLine("{0:f2}", secondRoot);
                }
                else
                {
                    Console.WriteLine("{0:f2}", secondRoot);
                    Console.WriteLine("{0:f2}", firstRoot);
                }

            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                Console.WriteLine("{0:f2}", root);
            }
            else
            {
                Console.WriteLine("no real roots");
            }

        }
    }
}
