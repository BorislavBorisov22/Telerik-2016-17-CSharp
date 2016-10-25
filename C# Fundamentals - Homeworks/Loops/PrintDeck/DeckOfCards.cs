using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDeck
{
    class DeckOfCards
    {
        static void Main()
        {
            string[] cardTypes = { "spades", "clubs", "hearts","diamonds" };
            string[] cards =
            {
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "J",
                "Q",
                "K",
                "A"
            };
            int printingEndPosition = 0;
            string startingCard = Console.ReadLine();

            switch (startingCard)
            {
                case "2": printingEndPosition = 0; break;
                case "3": printingEndPosition = 1; break;
                case "4": printingEndPosition = 2; break;
                case "5": printingEndPosition = 3; break;
                case "6": printingEndPosition = 4; break;
                case "7": printingEndPosition = 5; break;
                case "8": printingEndPosition = 6; break;
                case "9": printingEndPosition = 7; break;
                case "10": printingEndPosition = 8; break;
                case "J": printingEndPosition = 9; break;
                case "Q": printingEndPosition = 10; break;
                case "K": printingEndPosition = 11; break;
                case "A": printingEndPosition = 12; break;

            }


            for (int i=0;i <= printingEndPosition ; i++)
            {
                for (int k = 0; k < cardTypes.Length; k++)
                {
                    if (k == 3)
                    {
                        Console.Write("{0} of {1}", cards[i], cardTypes[k]);
                    }
                    else
                    {
                        Console.Write("{0} of {1}, ", cards[i], cardTypes[k]);
                    }
                }
                Console.WriteLine();
            }
            
        }
    }
}
