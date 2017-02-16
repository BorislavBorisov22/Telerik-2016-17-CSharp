namespace IntergalacticTravel.Tests.BusinessOwnerTests
{
    using System;

    using NUnit.Framework;
    using Contracts;
    using Moq;
    using System.Collections.Generic;

    [TestFixture]
    public class CollectProfits_Should
    {
        [Test]
        public void IncreaseTheOwnersResourcesByTheTotalREsourcesAmount_WhenCalled()
        {
            // arrange
            var stationStub = new Mock<ITeleportStation>();
            uint allCoins = 10;
            var resourcesStub = new Mock<IResources>();

            resourcesStub.Setup(x => x.BronzeCoins).Returns(allCoins);
            resourcesStub.Setup(x => x.SilverCoins).Returns(allCoins);
            resourcesStub.Setup(x => x.GoldCoins).Returns(allCoins);

            stationStub.Setup(x => x.PayProfits(It.IsAny<IBusinessOwner>()))
                .Returns(resourcesStub.Object);

            var ownerStations = new List<ITeleportStation>() { stationStub.Object };

            int id = 1;
            string nickname = "TheBoss";
            var owner = new BusinessOwner(id, nickname, ownerStations);

            // act
            owner.CollectProfits();

            // assert
            Assert.AreEqual(owner.Resources.BronzeCoins, 10);
            Assert.AreEqual(owner.Resources.SilverCoins, 10);
            Assert.AreEqual(owner.Resources.GoldCoins, 10);
        }
    }
}
