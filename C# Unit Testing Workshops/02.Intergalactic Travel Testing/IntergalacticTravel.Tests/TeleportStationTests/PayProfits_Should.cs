namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using System;

    using NUnit.Framework;
    using Contracts;
    using Moq;
    using System.Collections.Generic;
    using ResourcesFactoryTests.Fakes;

    [TestFixture]
    public class PayProfits_Should
    {
        [Test]
        public void ReturnTheTotalAmountOfProfits_WhenTheArgumentPassedIsTheActualOwnerOfTheStation()
        {
            // arrange
            int id = 1;
            var ownerStub = new Mock<IBusinessOwner>();
            ownerStub.Setup(x => x.IdentificationNumber).Returns(id);

            var locationStub = new Mock<ILocation>();
            var map = new List<IPath>();

            var station = new FakeTeleportStation(
                ownerStub.Object,
                map,
                locationStub.Object
                );

            var resourcesBeforeCollecting = station.Resources;

            // act
            var returnedObj = station.PayProfits(ownerStub.Object);

            // assert
            Assert.AreEqual(returnedObj.BronzeCoins, resourcesBeforeCollecting.BronzeCoins);
            Assert.AreEqual(returnedObj.GoldCoins, resourcesBeforeCollecting.GoldCoins);
            Assert.AreEqual(returnedObj.SilverCoins, resourcesBeforeCollecting.SilverCoins);
        }
    }
}
