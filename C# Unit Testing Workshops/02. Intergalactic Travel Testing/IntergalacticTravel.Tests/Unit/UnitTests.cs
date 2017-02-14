namespace IntergalacticTravel.Tests.Unit
{
    using System;

    using IntergalacticTravel;
    using NUnit.Framework;
    using Moq;
    using Contracts;

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_WhenInputResourcesIsNull_ShouldThrowArgumentNullException()
        {
            int id = 1;
            string nickName = "Gazarche";
            var unit = new Unit(id, nickName);

            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void Pay_WhenInputResourcesAreValid_ShouldDecreaseOwnersAmountOfResources()
        {
            // arrange
            int id = 1;
            string nickName = "Gazarche";
            uint allCoinsValues = 5;

            var unit = new Unit(id, nickName);
            unit.Resources.BronzeCoins = 10;
            unit.Resources.SilverCoins = 10;
            unit.Resources.GoldCoins = 10;

            var resourcesStub = new Mock<IResources>();
            resourcesStub.Setup(x => x.BronzeCoins).Returns(allCoinsValues);
            resourcesStub.Setup(x => x.SilverCoins).Returns(allCoinsValues);
            resourcesStub.Setup(x => x.GoldCoins).Returns(allCoinsValues);

            uint expectedValuesForAllCoins = 5;
            // act
            unit.Pay(resourcesStub.Object);

            // assert
            Assert.AreEqual(expectedValuesForAllCoins, unit.Resources.GoldCoins);
            Assert.AreEqual(expectedValuesForAllCoins, unit.Resources.SilverCoins);
            Assert.AreEqual(expectedValuesForAllCoins, unit.Resources.BronzeCoins);
        }

        [Test]
        public void Pay_WhenInputResourcesAreValid_ShouldReturnNewResourcesWithTheAMountOfResourcesInTheCostObject()
        {
            // arrange
            int id = 1;
            string nickName = "Gazarche";
            uint allCoinsValues = 5;

            var unit = new Unit(id, nickName);
            unit.Resources.BronzeCoins = 10;
            unit.Resources.SilverCoins = 10;
            unit.Resources.GoldCoins = 10;

            var resourcesStub = new Mock<IResources>();
            resourcesStub.Setup(x => x.BronzeCoins).Returns(allCoinsValues);
            resourcesStub.Setup(x => x.SilverCoins).Returns(allCoinsValues);
            resourcesStub.Setup(x => x.GoldCoins).Returns(allCoinsValues);

            // act
            var returnObj = unit.Pay(resourcesStub.Object);

            // assert
            Assert.IsInstanceOf<Resources>(returnObj);
            Assert.AreEqual(allCoinsValues, returnObj.BronzeCoins);
            Assert.AreEqual(allCoinsValues, returnObj.GoldCoins);
            Assert.AreEqual(allCoinsValues, returnObj.SilverCoins);
        }
    }
}
