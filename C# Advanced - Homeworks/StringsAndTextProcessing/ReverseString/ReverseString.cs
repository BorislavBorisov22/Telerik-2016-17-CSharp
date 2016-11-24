using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        string result = string.Empty;
        StringBuilder str = new StringBuilder();
        
        for (int i = input.Length - 1; i >= 0; i--)
        {
            str.Append(input[i]);
        }

        result = str.ToString();
        Console.WriteLine(result);

    }
}

