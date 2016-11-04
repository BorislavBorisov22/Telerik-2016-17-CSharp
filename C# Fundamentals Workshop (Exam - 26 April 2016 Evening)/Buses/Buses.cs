using System;

class Buses
{
    static void Main()
    {
        int busesCount = int.Parse(Console.ReadLine());

        int firstInLineSpeed = int.Parse(Console.ReadLine());
        int formedGroups = 1;
        for (int i = 0; i < busesCount - 1; i++)
        {
            int currInLineSpeed = int.Parse(Console.ReadLine());
            if (currInLineSpeed > firstInLineSpeed)
            {
                continue;
            }
            else
            {
                formedGroups++;
                firstInLineSpeed = currInLineSpeed;
            }
        }

        Console.WriteLine(formedGroups);
    }
}

