namespace Deck.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Santase.Logic.Cards;
    using Santase.Logic.PlayerActionValidate;
    using Santase.Logic.Players;
    using Santase.Logic.RoundStates;
    using Santase.Logic;

    [TestClass]
    public class PlayerActionValidatorTest
    {
        private PlayerActionValidator validator = new PlayerActionValidator();

        [TestMethod]
        public void IsValid_PlayingCardNotInHand_ShouldBeInvalid()
        {
            var action = PlayerAction.PlayCard(Card.GetCard(CardSuit.Diamond, CardType.Jack));
            var state = new StateManager();
            var round = new MoreThanTwoCardsLeftRoundState(state);
            var context = new PlayerTurnContext(round, Card.GetCard(CardSuit.Spade, CardType.Nine), 15, 15, 20);

            var playerCards = new List<Card>()
            {
               Card.GetCard(CardSuit.Heart, CardType.Jack)
            };

            Assert.IsFalse(validator.IsValid(action, context, playerCards));
        }

        [TestMethod]
        public void IsValid_PlayingCardThatIsInHand_ShouldBeValid()
        {
            var action = PlayerAction.PlayCard(Card.GetCard(CardSuit.Diamond, CardType.Jack));
            var state = new StateManager();
            var round = new MoreThanTwoCardsLeftRoundState(state);
            var context = new PlayerTurnContext(round, Card.GetCard(CardSuit.Spade, CardType.Nine), 15, 15, 20);

            var playerCards = new List<Card>()
            {
               Card.GetCard(CardSuit.Heart, CardType.Jack),
               Card.GetCard(CardSuit.Diamond, CardType.Jack)
            };

            Assert.IsTrue(validator.IsValid(action, context, playerCards));
        }

        [TestMethod]
        public void IsValid_ChangingTrumpCardWithoutHavingNineWithTheSameSuit_ShouldBeInvalid()
        {
            var action = PlayerAction.ChangeTrump();
            var state = new StateManager();
            var round = new MoreThanTwoCardsLeftRoundState(state);
            var context = new PlayerTurnContext(round, Card.GetCard(CardSuit.Spade, CardType.Ten), 15, 15, 20);

            var playerCards = new List<Card>()
            {
               Card.GetCard(CardSuit.Heart, CardType.Jack),
               Card.GetCard(CardSuit.Diamond, CardType.Jack)
            };

            Assert.IsFalse(validator.IsValid(action, context, playerCards));
        }

        [TestMethod]
        public void IsValid_ChangingTrumpCardWithANineSameSuit_ShouldBeValid()
        {
            var action = PlayerAction.ChangeTrump();
            var state = new StateManager();
            var round = new MoreThanTwoCardsLeftRoundState(state);
            var context = new PlayerTurnContext(round, Card.GetCard(CardSuit.Spade, CardType.Ten), 15, 15, 20);

            var playerCards = new List<Card>()
            {
               Card.GetCard(CardSuit.Heart, CardType.Jack),
               Card.GetCard(CardSuit.Diamond, CardType.Jack),
               Card.GetCard(CardSuit.Spade, CardType.Nine)
            };

            Assert.IsTrue(validator.IsValid(action, context, playerCards));
        }

        [TestMethod]
        public void IsValid_ClosingGameWithMoreThanTwoCardsLeft_ShouldBeValid()
        {
            var action = PlayerAction.CloseGame();
            var state = new StateManager();
            var round = new MoreThanTwoCardsLeftRoundState(state);
            var context = new PlayerTurnContext(round, Card.GetCard(CardSuit.Spade, CardType.Ten), 15, 15, 20);

            var playerCards = new List<Card>()
            {
               Card.GetCard(CardSuit.Heart, CardType.Jack),
               Card.GetCard(CardSuit.Diamond, CardType.Jack),
               Card.GetCard(CardSuit.Spade, CardType.Nine)
            };

            Assert.IsTrue(validator.IsValid(action, context, playerCards));
        }

        [TestMethod]
        public void IsValid_ClosingGameWhenNoCardsToDrawLeft_ShouldBeInvalid()
        {
            var action = PlayerAction.CloseGame();
            var state = new StateManager();
            var round = new FinalRoundState(state);
            var context = new PlayerTurnContext(round, Card.GetCard(CardSuit.Spade, CardType.Ten), 15, 15, 20);

            var playerCards = new List<Card>()
            {
               Card.GetCard(CardSuit.Heart, CardType.Jack),
               Card.GetCard(CardSuit.Diamond, CardType.Jack),
               Card.GetCard(CardSuit.Spade, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, playerCards));
        }

        [TestMethod]
        public void IsValid_ClosingGameInStartingRound_ShouldBeInvalid()
        {
            var action = PlayerAction.CloseGame();
            var state = new StateManager();
            var round = new StartRoundState(state);
            var context = new PlayerTurnContext(round, Card.GetCard(CardSuit.Spade, CardType.Ten), 15, 15, 20);

            var playerCards = new List<Card>()
            {
               Card.GetCard(CardSuit.Heart, CardType.Jack),
               Card.GetCard(CardSuit.Diamond, CardType.Jack),
               Card.GetCard(CardSuit.Spade, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, playerCards));
        }

        [TestMethod]
        public void IsValid_PuttingNullActionAsParameter_ShouldReturnFalse()
        {
            PlayerAction action = null;

            var state = new StateManager();
            var round = new StartRoundState(state);
            var context = new PlayerTurnContext(round, Card.GetCard(CardSuit.Spade, CardType.Ten), 15, 15, 20);

            var playerCards = new List<Card>()
            {
               Card.GetCard(CardSuit.Heart, CardType.Jack),
               Card.GetCard(CardSuit.Diamond, CardType.Jack),
               Card.GetCard(CardSuit.Spade, CardType.Nine)
            };

            Assert.IsFalse(validator.IsValid(action, context, playerCards));
        }

        [TestMethod]
        public void InstanceProperty_RetugningInstaceOfValidator_ShouldWorkCorrectly()
        {
            var validator = PlayerActionValidator.Instance;

            Assert.AreEqual(typeof(PlayerActionValidator), validator.GetType());
        }
        
        [TestMethod]
        public void GetPossibleCards_GettingPossibleCardsInMoreThanTwoCardsLeftRound_AllCardsShouldBeValidToPlay()
        {

            var state = new StateManager();
            var round = new MoreThanTwoCardsLeftRoundState(state);
            var context = new PlayerTurnContext(round, Card.GetCard(CardSuit.Spade, CardType.Ten), 15, 15, 20);

            var playerCards = new List<Card>()
            {
               Card.GetCard(CardSuit.Heart, CardType.Jack),
               Card.GetCard(CardSuit.Diamond, CardType.Jack),
               Card.GetCard(CardSuit.Spade, CardType.Nine),
               Card.GetCard(CardSuit.Spade, CardType.Ace)
            };

            var returnedCardsToPlay = this.validator.GetPossibleCardsToPlay(context, playerCards);

            Assert.AreEqual(playerCards.Count, returnedCardsToPlay.Count);
        }
    }
}
