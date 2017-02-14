using Poker.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpOfProjectBratt
{
    class Start
    {
        static void Main()
        {
            for (int i = 0; i < 10000000; i++)
            {
                var hand = PokerProvider.ProvideRandomHand();

                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    var currentCard = hand.Cards[j];
                    for (int k = j+1; k < hand.Cards.Count; k++)
                    {
                        var checkCard = hand.Cards[k];

                        if (currentCard.Face == checkCard.Face && currentCard.Suit == checkCard.Suit)
                        {
                            Console.WriteLine("yes");
                        }
                    }
                }
              
            }

            
        }
    }
}
