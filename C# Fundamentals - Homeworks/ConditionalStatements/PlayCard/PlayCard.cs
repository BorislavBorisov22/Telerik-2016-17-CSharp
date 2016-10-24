using System;


namespace PlayCard
{
    class PlayCard
    {
        static void Main()
        {
            string cardSymbol = Console.ReadLine();

            
            if (cardSymbol == "2" || cardSymbol == "3" || cardSymbol == "4" || cardSymbol == "5"
                || cardSymbol == "6" || cardSymbol == "7" || cardSymbol == "8" || cardSymbol == "9"
                || cardSymbol == "10" || cardSymbol == "J" || cardSymbol == "Q" || cardSymbol=="K"
                || cardSymbol == "A")
            {
                Console.WriteLine("yes {0}",cardSymbol);
            }
            else
            {
                Console.WriteLine("no {0}",cardSymbol);
            }

            
        }
    }
}
