using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullValuesArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            // these type of variables cannot have null value !!!!!
            int integer = int.Parse(null);
            double floatingPointNumber = double.Parse(null);
            Console.WriteLine(integer);
            Console.WriteLine(floatingPointNumber);
        }
    }
}
