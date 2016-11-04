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
            int currCombOnesCount = 0;
            bool canCombBeUsed = true;
            for (int position = 0; position < 32; position++)
            {
                uint combBit = currComb >> position & 1;
                uint hairBit = bobisHair >> position & 1;
                if (combBit == 1)
                {
                    currCombOnesCount++;
                }
                if (combBit == 1 && hairBit == 1)
                {
                    canCombBeUsed = false;
                    break;
                }
            }

            if (canCombBeUsed)
            {
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

