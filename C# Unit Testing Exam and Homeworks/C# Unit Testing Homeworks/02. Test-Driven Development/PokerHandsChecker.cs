namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("Hand to check cannot be null!");
            }

            if (hand.Cards == null)
            {
                throw new ArgumentNullException("Hand cannot have cards with null value!");
            }

            if (hand.Cards.Any(c => c == null))
            {
                throw new ArgumentNullException("Cards of a hand cannot consist of null cards!");
            }

            if (hand.Cards.Count != 5)
            {
                return false;
            }

            if (AreCardsRepeating(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            return this.IsStraight(hand) && this.IsFlush(hand);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }


            for (int i = 2; i <= 14; i++)
            {
                CardFace currentFace = (CardFace)i;
                if (hand.Cards.Where(c => c.Face == currentFace).Count() == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            bool hasThreeOfAKind = false;
            for (int i = 2; i <= 14; i++)
            {
                if (hand.Cards.Where(c => c.Face == (CardFace)i).Count() == 3)
                {
                    hasThreeOfAKind =  true;
                    break;
                }
            }

            var occurences = GetCardsOccurences(hand);

            bool hasOnePair = occurences.Where(x => x == 2).Count() == 2;

            return hasThreeOfAKind && hasOnePair;
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            for (int i = 1; i <= 4; i++)
            {
                var currentSuit = (CardSuit)i;
                if (hand.Cards.All(c => c.Suit == currentSuit))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsStraight(IHand hand)
        {
            bool isValid = this.IsValidHand(hand);
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var orderedCards = hand.Cards.OrderBy(c => c.Face).ToList();

            for (int i = 1; i < orderedCards.Count; i++)
            {
                if ((int)orderedCards[i].Face - (int)orderedCards[i - 1].Face != 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.IsFullHouse(hand))
            {
                return false;
            }

            for (int i = 2; i <= 14; i++)
            {
                if (hand.Cards.Where(c => c.Face == (CardFace)i).Count() == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var occurences = this.GetCardsOccurences(hand);

            return occurences.Where(x => x == 2).Count() == 4;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.IsFullHouse(hand))
            {
                return false;
            }

            var occurences = GetCardsOccurences(hand);

            return occurences.Where(x => x == 2).Count() == 2;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            bool isOtherAnyOtherCombination =
                this.IsOnePair(hand) ||
                this.IsTwoPair(hand) ||
                this.IsThreeOfAKind(hand) ||
                this.IsFourOfAKind(hand) ||
                this.IsFullHouse(hand) ||
                this.IsStraight(hand) ||
                this.IsFlush(hand) ||
                this.IsStraightFlush(hand); 
            
            if (isOtherAnyOtherCombination)
            {
                return false;
            }

            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsValidHand(firstHand) || !this.IsValidHand(secondHand))
            {
                throw new ArgumentException("Cannot compare invalid hands");
            }

            if (this.AreHandsEqual(firstHand, secondHand))
            {
                return 0;
            }

            throw new NotImplementedException();
        }

        private bool AreHandsEqual(IHand first, IHand second)
        {
            var firstCards = first.Cards.OrderBy(x => x.Face).ThenBy(x => x.Suit).ToList();
            var secondCards = second.Cards.OrderBy(x => x.Face).ThenBy(x => x.Suit).ToList();


            for (int i=0; i < firstCards.Count; i++)
            {
                if (!this.AreTwoCardsEqual(firstCards[i], secondCards[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreCardsRepeating(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var current = hand.Cards[i];

                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    var next = hand.Cards[j];

                    if (AreTwoCardsEqual(current, next))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool AreTwoCardsEqual(ICard first, ICard second)
        {
            return first.Face == second.Face && first.Suit == second.Suit;
        }

        private int[] GetCardsOccurences(IHand hand)
        {
            int[] occurences = new int[5];

            for (int i = 0; i < hand.Cards.Count; ++i)
            {
                var current = hand.Cards[i];
                for (int j = 0; j < hand.Cards.Count; ++j)
                {
                    var next = hand.Cards[j];
                    if (next.Face == current.Face)
                    {
                        occurences[i]++;
                    }
                }
            }

            return occurences;
        }
    }
}
