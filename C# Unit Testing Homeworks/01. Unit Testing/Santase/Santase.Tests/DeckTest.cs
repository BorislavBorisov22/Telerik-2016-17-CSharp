namespace Deck.Tests
{
    using System;

    using NUnit.Framework;
    using Santase.Logic.Cards;
    using Santase.Logic;

    [TestFixture]
    public class DeckTest
    {
        private const int DeckSize = 24;

        [Test]
        public void DeckShouldNotThrowExceptionWhenCreated()
        {
            var deck = new Deck();
        }

        [Test]
        public void DeckSizeShouldBeCorrect()
        {
            var deck = new Deck();

            Assert.AreEqual(DeckSize, deck.CardsLeft);
        }

        [Test]
        public void DeckTrumpCardShouldBeValid()
        {
            var deck = new Deck();
            Assert.IsTrue(Enum.IsDefined(typeof(CardSuit), deck.TrumpCard.Suit));
            Assert.IsTrue(Enum.IsDefined(typeof(CardType), deck.TrumpCard.Type));
        }

        [Test]
        public void DeckCradsLeftShouldDecreaseWhenGettingNextCard()
        {
            var deck = new Deck();
            var cardToDraw = deck.GetNextCard();

            Assert.AreEqual(DeckSize - 1, deck.CardsLeft);
        }

        [Test]
        public void TrumpCardShouldBeChangedCorrectly()
        {
            var newTrumpCard = Card.GetCard(CardSuit.Spade, CardType.Ace);
            var deck = new Deck();
            deck.ChangeTrumpCard(newTrumpCard);

            Assert.AreEqual(newTrumpCard, deck.TrumpCard);
        }

        [Test]
        public void GetNextCardShouldThrowExceptionWhenThereAreNoCardsLeft()
        {
            var deck = new Deck();

            for (int i = 0; i < DeckTest.DeckSize; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [TestCase(5, 19)]
        [TestCase(24, 0)]
        [TestCase(14, 10)]
        public void CardsLeftShouldBeRightAmountWhenDrawingSomeOut(int cardsToDraw, int expectedOutput)
        {
            var deck = new Deck();

            for (int i = 0; i < cardsToDraw; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(expectedOutput, deck.CardsLeft);
        }

        [Test]
        public void AllCardsFromDeckShouldBeValid()
        {
            var deck = new Deck();

            for (int i = 0; i < DeckTest.DeckSize; i++)
            {
                var currentCard = deck.GetNextCard();
                Assert.IsTrue(Enum.IsDefined(typeof(CardSuit), currentCard.Suit));
                Assert.IsTrue(Enum.IsDefined(typeof(CardType), currentCard.Type));
            }
        }

    }
}
