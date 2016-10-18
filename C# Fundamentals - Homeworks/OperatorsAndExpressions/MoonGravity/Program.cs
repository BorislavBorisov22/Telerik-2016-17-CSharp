using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonGravity
{
    class Program
    {
        static void Main(string[] args)
        {
            double earthWeight = double.Parse(Console.ReadLine());
            double moonWeight = earthWeight * 0.17;
            Console.WriteLine("{0:f3}",moonWeight);
        }
    }
}
