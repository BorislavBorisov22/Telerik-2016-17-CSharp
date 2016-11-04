using System;

class BobiAvokadoto
{
    static void Main()
    {
        uint bobisHair = uint.Parse(Console.ReadLine());
        int combsCount = int.Parse(Console.ReadLine());
        int maxOnesCount = -1;
        uint bestComb = 0;
        for (int i = 0; i < combsCount; i++)
        {
            uint currComb = uint.Parse(Console.ReadLine());

            if ((currComb & bobisHair) == 0)
            {
                int currCombOnesCount = 0;
                for (int position = 0; position < 32; position++)
                {
                    if ((currComb >> position & 1) == 1)
                    {
                        currCombOnesCount++;
                    }
                }
                if (currCombOnesCount > maxOnesCount)
                {
                    maxOnesCount = currCombOnesCount;
                    bestComb = currComb;
                }
            }

        }

        Console.WriteLine(bestComb);
    }
}

