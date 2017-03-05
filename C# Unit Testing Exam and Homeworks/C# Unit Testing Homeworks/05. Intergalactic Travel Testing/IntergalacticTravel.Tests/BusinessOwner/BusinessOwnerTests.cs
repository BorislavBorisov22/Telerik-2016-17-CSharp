namespace IntergalacticTravel.Tests.BusinessOwner
{
    using System;

    using NUnit.Framework;
    using IntergalacticTravel;
    using Moq;
    using Contracts;
    using System.Collections.Generic;

    [TestFixture]
    public class BusinessOwnerTests
    {
        [Test]
        public void CollectProfits_WhenInvoked_ShouldIncreaseProfitsByTheTotalAmountOfResourcesGeneratedByOwnersTeleportStation()
        {
            // arrange
            int id = 0;
            string nickName = "TheBoss";
            uint allCoinsValues = 5;

            var resourcesStub = new Mock<IResources>();
            resourcesStub.Setup(x => x.BronzeCoins).Returns(allCoinsValues);
            resourcesStub.Setup(x => x.SilverCoins).Returns(allCoinsValues);
            resourcesStub.Setup(x => x.GoldCoins).Returns(allCoinsValues);

            var teleportStationStub = new Mock<ITeleportStation>();
            teleportStationStub.Setup(x => x.PayProfits(It.IsAny<IBusinessOwner>()))
                .Returns(resourcesStub.Object);

            var listStations = new List<ITeleportStation>() { teleportStationStub.Object };

            var owner = new BusinessOwner(id, nickName, listStations);

            // act
            owner.CollectProfits();

            // assert
            Assert.AreEqual(allCoinsValues, owner.Resources.BronzeCoins);
            Assert.AreEqual(allCoinsValues, owner.Resources.GoldCoins);
            Assert.AreEqual(allCoinsValues, owner.Resources.SilverCoins);
        }
    }
}
