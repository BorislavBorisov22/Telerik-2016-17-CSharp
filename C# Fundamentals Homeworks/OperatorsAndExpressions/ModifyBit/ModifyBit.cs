using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyBit
{
    class ModifyBit
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            int bit = int.Parse(Console.ReadLine());

            if (bit == 1)
            {
                number = number | ((ulong)1 << position);
            }
            else
            {
                number = number & (ulong)(~(1 << position));
            }

            Console.WriteLine(number);
              
            
            
        }
    }
}
