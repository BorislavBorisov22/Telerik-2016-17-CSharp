using System;



class Greeting
{
    private static void SayHello(string name)
    {
        Console.WriteLine("Hello, {0}!",name);
    }
    static void Main()
    {
        string name = Console.ReadLine();
        SayHello(name);

    }
}

