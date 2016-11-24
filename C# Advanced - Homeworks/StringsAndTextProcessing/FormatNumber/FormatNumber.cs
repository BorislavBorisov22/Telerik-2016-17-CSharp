using System;

using System.Threading;

class FormatNumber
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        int number = 15;// int.Parse(Console.ReadLine());

        Console.WriteLine("{0, 15}",number);
        Console.WriteLine("{0, 15:X}",number);
        Console.WriteLine("{0, 15:P}",number);
        Console.WriteLine("{0, 15:E}",number);
        
        
    }
}

