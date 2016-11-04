using System;

class BirdsAndFeathers
{
    static void Main()
    {
        long birdsCount = long.Parse(Console.ReadLine());
        long feathersCount = long.Parse(Console.ReadLine());


        double feathersPerBird = (double)feathersCount / birdsCount;

        if (birdsCount % 2 == 0)
        {
            feathersPerBird *= 123123123123;
        }
        else
        {
            feathersPerBird /= 317;
        }

        Console.WriteLine("{0:f4}",feathersPerBird);
    }
}

