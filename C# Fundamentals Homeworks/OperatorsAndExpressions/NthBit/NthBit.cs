using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthBit
{
    class NthBit
    {
        static void Main(string[] args)
        {
            
            int number = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());

            int bit = number >> position & 1;
            
            Console.WriteLine(bit);


            
            
        }
    }
}
