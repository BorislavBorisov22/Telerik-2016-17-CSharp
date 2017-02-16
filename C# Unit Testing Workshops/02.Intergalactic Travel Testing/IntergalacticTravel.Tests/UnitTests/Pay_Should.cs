namespace IntergalacticTravel.Tests.UnitTests
{
    using System;

    using NUnit.Framework;
    using Castle.Core.Resource;
    using Moq;
    using Contracts;

    [TestFixture]
    public class Pay_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenObjectPassedIsNull()
        {
            // arrange
            int id = 1;
            string nickname = "someNick";

            var unit = new Unit(id, nickname);

            // act and assert
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void DecreaseOwnersAmountOfResourcesWithTHeAmountOfCost_WhenCalledWithValidObjextParameter()
        {
            // arrange
            int id = 1;
            string nickname = "someNick";
            var unit = new Unit(id, nickname);

            uint initialCoins = 100;
            unit.Resources.BronzeCoins = initialCoins;
            unit.Resources.SilverCoins = initialCoins;
            unit.Resources.GoldCoins = initialCoins;

            var resourcesStub = new Mock<IResources>();
            uint allCosts = 40;
            resourcesStub.Setup(x => x.BronzeCoins).Returns(allCosts);
            resourcesStub.Setup(x => x.SilverCoins).Returns(allCosts);
            resourcesStub.Setup(x => x.GoldCoins).Returns(allCosts);

            // act
            unit.Pay(resourcesStub.Object);

            // assert
            Assert.AreEqual(60, unit.Resources.BronzeCoins);
            Assert.AreEqual(60, unit.Resources.SilverCoins);
            Assert.AreEqual(60, unit.Resources.GoldCoins);
        }

        [Test]
        public void ReturnNewRsourcesObjectWithValuesOfTheCostResources_WhenCalledWithValidObjextParameter()
        {
            // arrange
            int id = 1;
            string nickname = "someNick";
            var unit = new Unit(id, nickname);

            uint initialCoins = 100;
            unit.Resources.BronzeCoins = initialCoins;
            unit.Resources.SilverCoins = initialCoins;
            unit.Resources.GoldCoins = initialCoins;

            var resourcesStub = new Mock<IResources>();
            uint allCosts = 40;
            resourcesStub.Setup(x => x.BronzeCoins).Returns(allCosts);
            resourcesStub.Setup(x => x.SilverCoins).Returns(allCosts);
            resourcesStub.Setup(x => x.GoldCoins).Returns(allCosts);

            // act
            var returnedObj = unit.Pay(resourcesStub.Object);

            // assert
            Assert.IsInstanceOf<Resources>(returnedObj);
            Assert.AreEqual(returnedObj.BronzeCoins, resourcesStub.Object.BronzeCoins);
            Assert.AreEqual(returnedObj.SilverCoins, resourcesStub.Object.SilverCoins);
            Assert.AreEqual(returnedObj.GoldCoins, resourcesStub.Object.GoldCoins);
        }
    }
}
