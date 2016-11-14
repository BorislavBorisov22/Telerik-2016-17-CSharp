using System;
using System.Collections.Generic;
using System.Linq;

class SortByStringLength
{
    static void Main()
    {
        var texts = new List<string>();
        Console.Write("Please enter how many string would you like to add: ");
        int stringsToRead = int.Parse(Console.ReadLine());

        for (int i = 0; i < stringsToRead; i++)
        {
            string currString = Console.ReadLine();
            texts.Add(currString);
        }


        texts = texts.OrderBy(s => s.Length).ToList();

        Console.WriteLine(string.Join("\n",texts));
    }
}

