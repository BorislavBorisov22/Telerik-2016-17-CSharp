using System;

class BinaryShort
{
    static string GetShortBinaryString(short number)
    {
        char[] bitsNumber = new char[16];

        for (int position = 0;position < 16; position++)
        {
            short currBit = (short)(number >> position & 1);
            bitsNumber[15 - position] = currBit == 1 ? '1' : '0';
        }

        string binaryString = string.Join("", bitsNumber);

        return binaryString;
    }

    static void Main()
    {
        short number = short.Parse(Console.ReadLine());
        Console.WriteLine(GetShortBinaryString(number));
    }
}