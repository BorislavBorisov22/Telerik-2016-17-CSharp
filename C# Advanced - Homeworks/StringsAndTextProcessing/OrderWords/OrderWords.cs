using System;
using System.Collections.Generic;
using System.Linq;

class OrderWords
{
    static void Main()
    {
        var words = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        words = words.OrderBy(n => n).ToList();
        Console.WriteLine(string.Join(" ",words));
    }
}

