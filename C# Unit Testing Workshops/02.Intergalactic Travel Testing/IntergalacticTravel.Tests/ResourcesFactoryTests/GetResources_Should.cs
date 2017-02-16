namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class GetResources_Should
    {
        [TestCase("create resource gold(20) silver(30) bronze(40)")]
        [TestCase("create resource gold(20) bronze(40) silver(30)")]
        [TestCase("create resource silver(30) bronze(40) gold(20)")]
        [TestCase("create resource silver(30) gold(20) bronze(40)")]
        [TestCase("create resource bronze(40) gold(20) silver(30)")]
        [TestCase("create resource bronze(40) silver(30) gold(20)")]
        public void ReturnNewResourceWith40Bronze30Silver20GoldCoins_WhenPassedParametersAreInAllDifferentOrdersButStillValidAsInput(string input)
        {
            // arrange
            var factory = new ResourcesFactory();

            int expectedBonzeCoins = 40;
            int expectedSilverCoins = 30;
            int expectedGoldCoins = 20;

            // act
            var returnedObj = factory.GetResources(input);

            // assert
            Assert.IsInstanceOf<Resources>(returnedObj);
            Assert.AreEqual(expectedBonzeCoins, returnedObj.BronzeCoins);
            Assert.AreEqual(expectedSilverCoins, returnedObj.SilverCoins);
            Assert.AreEqual(expectedGoldCoins, returnedObj.GoldCoins);
        }

        [TestCase("totally invalid command")]
        [TestCase("create resource gold(20) bronze(40) silver(invalidNumber)")]
        [TestCase("create resources x y z")]
        public void ThrowInvalidOperationExceptionWhichContainsThreStringCommand_WhenInputStringIsInvalidCommand(string input)
        {
            // arrange
            var factory = new ResourcesFactory();

            // act and assert
            Assert.Throws<InvalidOperationException>(() => factory.GetResources(input));
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        public void ThrowOverfloweException_WhenInputStringIsValidButAnyREsourceAmountIsBIggerThanTheUintMaxSize(string input)
        {
            // arrange
            var factory = new ResourcesFactory();

            // act and assert
            Assert.Throws<OverflowException>(() => factory.GetResources(input));
        }
    }
}
