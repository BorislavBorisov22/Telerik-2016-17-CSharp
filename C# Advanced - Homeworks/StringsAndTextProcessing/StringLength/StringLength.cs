using System;
using System.Text;


class StringLength
{
    static void Main()
    {
        string inputText = Console.ReadLine();

        inputText = inputText.PadRight(20,'*');
        Console.WriteLine(inputText);
    }
}

