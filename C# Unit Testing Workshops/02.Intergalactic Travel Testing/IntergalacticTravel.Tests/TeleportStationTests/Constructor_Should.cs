namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using System;

    using NUnit.Framework;
    using Contracts;
    using Moq;
    using System.Collections.Generic;
    using ResourcesFactoryTests.Fakes;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetUpOwnerCorrectly_WhenObjectIsConstructed()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();

            // act
            var station = new FakeTeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            // assert
            Assert.AreSame(ownerStub.Object, station.Owner);
        }

        [Test]
        public void SetUpGalacticMapCorrectly_WhenObjectIsConstructed()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();

            // act
            var station = new FakeTeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            // assert
            Assert.AreSame(galacticMapStub, station.GalacticMap);
        }

        [Test]
        public void SetUpLocationCorrectly_WhenObjectIsConstructed()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();

            // act
            var station = new FakeTeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            // assert
            Assert.AreSame(locationStub.Object, station.Location);
        }
        
        [Test]
        public void SetUpResourcesToNewResourcesInstanceCorrectly_WhenObjectIsConstructed()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();

            // act
            var station = new FakeTeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            // assert
            Assert.IsInstanceOf<Resources>(station.Resources);
        }
    }
}
