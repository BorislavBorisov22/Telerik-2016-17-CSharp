using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoscelesTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            char copyrightSymbol = '\u00A9';

            Console.WriteLine("   {0}",copyrightSymbol);
            Console.WriteLine("  {0} {0}",copyrightSymbol);
            Console.WriteLine(" {0} {0} {0}",copyrightSymbol);
            Console.WriteLine("{0} {0} {0} {0}", copyrightSymbol);
        }
    }
}
