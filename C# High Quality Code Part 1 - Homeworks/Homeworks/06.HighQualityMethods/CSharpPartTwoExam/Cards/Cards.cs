namespace Methods.CSharpPartTwoExam._02.Cards
{
    using System;
    using System.Collections.Generic;

    public class Cards
    {
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            var totalDeck = GetPresentCards(linesCount);

            bool isDeckFull = IsDeckFull(totalDeck);

            if (isDeckFull)
            {
                Console.WriteLine("Full deck");
            }
            else
            {
                Console.WriteLine("Wa wa!");
            }

            // get numbers with odd occurences
            List<string> oddOccurences = GetCardsWithOddOccurence(totalDeck);
            Console.WriteLine(string.Join(" ", oddOccurences));
        }

        private static int[] GetPresentCards(int linesCount)
        {
            int[] totalDeck = new int[52];
            for (int i = 0; i < linesCount; i++)
            {
                long currentHand = long.Parse(Console.ReadLine());

                for (int position = 0; position < 52; position++)
                {
                    long currentBit = (currentHand >> position) & 1;
                    if (currentBit == 1)
                    {
                        totalDeck[position]++;
                    }
                }
            }

            return totalDeck;
        }

        private static bool IsDeckFull(int[] deck)
        {
            bool isDeckFull = true;
            foreach (var card in deck)
            {
                if (card <= 0)
                {
                    isDeckFull = false;
                    break;
                }
            }

            return isDeckFull;
        }

        private static List<string> GetCardsWithOddOccurence(int[] totalDeck)
        {
            var oddOccurences = new List<string>();

            string[] cards =
            {
            "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "Tc", "Jc", "Qc", "Kc", "Ac",
             "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "Td", "Jd", "Qd", "Kd", "Ad",
             "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "Th", "Jh", "Qh", "Kh", "Ah",
             "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "Ts", "Js", "Qs", "Ks", "As"
            };

            for (int i = 0; i < totalDeck.Length; i++)
            {
                if (totalDeck[i] % 2 == 1)
                {
                    oddOccurences.Add(cards[i]);
                }
            }

            return oddOccurences;
        }
    }
}
