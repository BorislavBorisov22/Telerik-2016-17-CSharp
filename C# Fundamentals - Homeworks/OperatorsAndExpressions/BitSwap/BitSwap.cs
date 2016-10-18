using System;


namespace BitSwap
{

    class BitSwap
    {
        static uint GetBit(uint number, int position)
        {
            uint bit = number >> position & 1;
            return bit;
        }
        static uint ChangeBit(uint number, int position, uint bit)
        {
            uint mask = 1;
            uint newNumber;
            if (bit == 1)
            {
                newNumber = number | (mask << position);
            }
            else
            {
                newNumber = number & ~(mask << position);
            }
            return newNumber;
        }
        static void Main()
        {
            uint number = uint.Parse(Console.ReadLine());
            int startP = int.Parse(Console.ReadLine());
            int startQ = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            uint firstBit = 0;
            uint secondBit = 0;


            for (int i = 0; i < length; i++)
            {
                firstBit = GetBit(number, startP + i);
                secondBit = GetBit(number, startQ + i);
                number = ChangeBit(number, startP + i, secondBit);
                number = ChangeBit(number, startQ + i, firstBit);
            }
            Console.WriteLine(number);
        }
    }
}
