using System;

class RandomNumbers
{
    static void Main()
    {
        Random rnd = new Random();

        int numbersToPrint = 10;

        for (int i = 0; i < numbersToPrint; i++)
        {
            int currentRandomNumber = rnd.Next(100, 201);
            Console.WriteLine(currentRandomNumber);
        }
        
    }
}

