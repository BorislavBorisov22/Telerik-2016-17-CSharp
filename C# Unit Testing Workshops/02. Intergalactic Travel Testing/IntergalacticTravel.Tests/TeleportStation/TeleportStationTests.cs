namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;
    using System.Collections;
    using System.Collections.Generic;
    using Fakes;
    using Exceptions;
    using System.Linq;

    [TestFixture]
    public class TeleportStationTests
    {
        [Test]
        public void Constructor_WhenANewTeleportStationIsCreated_ShouldSetUpAllProvidedFields()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            //var pathStub = new Mock<IPath>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();

            // act
            var station = new MockedTeleportStation(
                ownerStub.Object,
                galacticMapStub.Object,
                locationStub.Object
                );

            // assert
            Assert.AreSame(ownerStub.Object, station.Owner);
            Assert.AreSame(galacticMapStub.Object, station.GalacticMap);
            Assert.AreSame(locationStub.Object, station.Location);
            Assert.IsNotNull(station.Resources);
        }

        [Test]
        public void TeleportUnit_WhenUnitToTeleportIsNull_ShouldThrowArgumentNullExceptionThatConatinsUnitToTeleportString()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub.Object,
                locationStub.Object
                );

            var exception = Assert.Throws<ArgumentNullException>(
                () => station.TeleportUnit(null, locationStub.Object)
                );

            Assert.IsTrue(exception.Message.Contains("unitToTeleport"));
        }

        [Test]
        public void TeleportUnit_WhenTargetLocationIsNull_ShouldThrowArgumentNullExceptionThatContainsDestinationString()
        {
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();
            var unitStub = new Mock<IUnit>();

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub.Object,
                locationStub.Object
                );

            var exception = Assert.Throws<ArgumentNullException>(() =>
                station.TeleportUnit(unitStub.Object, null)
            );

            Assert.IsTrue(exception.Message.Contains("destination"));
        }

        [Test]
        public void TeleportUnit_WhenAUnitIsTryingToUseTeleportStationFromADistantLocation_ShouldThrowTeleportOutOfRangeExceptionThatContainsunitToTeleportCurrentLocation()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();
            var unitStub = new Mock<IUnit>();

            unitStub.Setup(x => x.CurrentLocation.Planet.Name).Returns("Pluto");
            unitStub.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Milky way");

            locationStub.Setup(x => x.Planet.Name).Returns("Earth");
            locationStub.Setup(x => x.Planet.Galaxy.Name).Returns("Milky way");

            var targetLocationStub = new Mock<ILocation>();

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub.Object,
                locationStub.Object
                );

            string expectedMessage = "unitToTeleport.CurrentLocation";
            // act
            var ex = Assert.Throws<TeleportOutOfRangeException>(
                 () => station.TeleportUnit(unitStub.Object, targetLocationStub.Object)
                );

            // assert
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenTryingToTeleportAUnitToATakenLocation_ShouldThrowInvalidTeleportationLocationExceptionWithAMessageThatContainsUnitsWillOverlap()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("PlanetName");

            var teleportingUnitStub = new Mock<IUnit>();
            teleportingUnitStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetPlanet");
            targetLocationStub.Setup(x => x.Coordinates.Latitude).Returns(1.00);
            targetLocationStub.Setup(x => x.Coordinates.Longtitude).Returns(2.00);

            var unitAtTargetLocationStub = new Mock<IUnit>();
            unitAtTargetLocationStub.Setup(x => x.CurrentLocation).Returns(targetLocationStub.Object);
            targetLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { unitAtTargetLocationStub.Object });


            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation).Returns(targetLocationStub.Object);

            var station = new TeleportStation(
                ownerStub.Object,
                new List<IPath>() { pathStub.Object },
                currentLocationStub.Object
                );

            // act
            var ex = Assert.Throws<InvalidTeleportationLocationException>(
                () => station.TeleportUnit(teleportingUnitStub.Object, targetLocationStub.Object)
                );

            StringAssert.Contains("units will overlap", ex.Message);
        }


        [Test]
        public void TeleportUnit_WhenTryingToTeleportUnitToAGalaxyThatIsNotPresentInTeleportStationLocations_ShouldThrowLocationNotFoundExceptionWithGalaxyString()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("PlanetName");

            var mapStub = new List<IPath>();

            var unitStub = new Mock<IUnit>();
            unitStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);

            var station = new TeleportStation(
                ownerStub.Object,
                mapStub,
                currentLocationStub.Object
                );

            // act
            var exception = Assert.Throws<LocationNotFoundException>(
                () => station.TeleportUnit(unitStub.Object, currentLocationStub.Object)
                );

            // assert
            StringAssert.Contains("Galaxy", exception.Message);
        }

        [Test]
        public void TeleportUnit_WhenTeleportingUnitToAPlanetThatIsNotPresentInStation_ShouldThrowLocationNotFoundExceptionWithGalaxyString()
        {
            var ownerStub = new Mock<IBusinessOwner>();

            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("PlanetName");

            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyName");
            pathStub.Setup(x => x.TargetLocation.Planet.Name).Returns("Earth");
            var mapStub = new List<IPath>() { pathStub.Object };

            var unitStub = new Mock<IUnit>();
            unitStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);

            var station = new TeleportStation(
                ownerStub.Object,
                mapStub,
                currentLocationStub.Object
                );

            // act
            var exception = Assert.Throws<LocationNotFoundException>(
                () => station.TeleportUnit(unitStub.Object, currentLocationStub.Object)
                );

            // assert
            StringAssert.Contains("Planet", exception.Message);
        }

        [Test]
        public void TeleportUnit_WhenTeleportingUnitWithLessThanRequiredResources_ShouldThrowInsufficientResourcesExceptionWithFreeLunchString()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("PlanetName");

            var teleportingUnitStub = new Mock<IUnit>();
            teleportingUnitStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);
            teleportingUnitStub.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(false);

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetPlanet");

            targetLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>());

            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation).Returns(targetLocationStub.Object);

            var station = new TeleportStation(
                ownerStub.Object,
                new List<IPath>() { pathStub.Object },
                currentLocationStub.Object
                );

            // act
            var ex = Assert.Throws<InsufficientResourcesException>(
                () => station.TeleportUnit(teleportingUnitStub.Object, targetLocationStub.Object)
                );

            StringAssert.Contains("FREE LUNCH", ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenAllValidationsPass_UnitShouldRequirePayment()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("PlanetName");

            var resourcesStub = new Mock<IResources>();
            resourcesStub.Setup(x => x.BronzeCoins).Returns(1);
            resourcesStub.Setup(x => x.SilverCoins).Returns(1);
            resourcesStub.Setup(x => x.GoldCoins).Returns(1);

            var teleportingUnitMock = new Mock<IUnit>();
            teleportingUnitMock.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);
            teleportingUnitMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            teleportingUnitMock.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(resourcesStub.Object).Verifiable();

            currentLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { teleportingUnitMock.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetPlanet");

            targetLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>());

            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation).Returns(targetLocationStub.Object);

            var station = new TeleportStation(
                ownerStub.Object,
                new List<IPath>() { pathStub.Object },
                currentLocationStub.Object
                );


            // act
            station.TeleportUnit(teleportingUnitMock.Object, targetLocationStub.Object);

            // assert
            teleportingUnitMock.Verify();
        }

        [Test]
        public void TeleportUnit_WhenAllValidationsPassSuccessfully_ShouldAddCostForTeleportingToStationResources()
        {
            var ownerStub = new Mock<IBusinessOwner>();
            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("PlanetName");

            var resourcesStub = new Mock<IResources>();
            resourcesStub.Setup(x => x.BronzeCoins).Returns(1);
            resourcesStub.Setup(x => x.SilverCoins).Returns(1);
            resourcesStub.Setup(x => x.GoldCoins).Returns(1);

            var teleportingUnitStub = new Mock<IUnit>();
            teleportingUnitStub.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);
            teleportingUnitStub.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            teleportingUnitStub.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(resourcesStub.Object);

            currentLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { teleportingUnitStub.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetPlanet");

            targetLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>());

            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation).Returns(targetLocationStub.Object);

            var station = new MockedTeleportStation(
                ownerStub.Object,
                new List<IPath>() { pathStub.Object },
                currentLocationStub.Object
                );


            // act
            station.TeleportUnit(teleportingUnitStub.Object, targetLocationStub.Object);

            // assert
            Assert.AreEqual(1, station.Resources.BronzeCoins);
            Assert.AreEqual(1, station.Resources.SilverCoins);
            Assert.AreEqual(1, station.Resources.GoldCoins);
        }

        [Test]
        public void TeleportUnit_WhenAllValidationsPasssUccessfully_ShouldSetUnitsPreviuosLocationToHisCurrent()
        {

            var ownerStub = new Mock<IBusinessOwner>();
            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("PlanetName");

            var resourcesStub = new Mock<IResources>();
            resourcesStub.Setup(x => x.BronzeCoins).Returns(1);
            resourcesStub.Setup(x => x.SilverCoins).Returns(1);
            resourcesStub.Setup(x => x.GoldCoins).Returns(1);

            var teleportingUnitMock = new Mock<IUnit>();
            teleportingUnitMock.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);
            teleportingUnitMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            teleportingUnitMock.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(resourcesStub.Object);
            teleportingUnitMock.SetupSet(x => x.PreviousLocation = It.IsAny<ILocation>());
            teleportingUnitMock.SetupGet(x => x.PreviousLocation).Returns(teleportingUnitMock.Object.PreviousLocation);
            currentLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { teleportingUnitMock.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetPlanet");

            targetLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>());

            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation).Returns(targetLocationStub.Object);

            var station = new MockedTeleportStation(
                ownerStub.Object,
                new List<IPath>() { pathStub.Object },
                currentLocationStub.Object
                );

            // act
            station.TeleportUnit(teleportingUnitMock.Object, targetLocationStub.Object);

            // assert
            teleportingUnitMock.VerifySet(x => x.PreviousLocation = currentLocationStub.Object, Times.Once);
        }

        [Test]
        public void TeleportUnit_WhenAllValidationsPassSuccessfully_ShouldSetUnitsCUrrentLocationToTheTargetLocation()
        {
            var ownerStub = new Mock<IBusinessOwner>();
            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("PlanetName");

            var resourcesStub = new Mock<IResources>();
            resourcesStub.Setup(x => x.BronzeCoins).Returns(1);
            resourcesStub.Setup(x => x.SilverCoins).Returns(1);
            resourcesStub.Setup(x => x.GoldCoins).Returns(1);

            var teleportingUnitMock = new Mock<IUnit>();
            teleportingUnitMock.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);
            teleportingUnitMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            teleportingUnitMock.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(resourcesStub.Object);
            teleportingUnitMock.SetupSet(x => x.PreviousLocation = It.IsAny<ILocation>());
            teleportingUnitMock.SetupGet(x => x.PreviousLocation).Returns(teleportingUnitMock.Object.PreviousLocation);
            currentLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { teleportingUnitMock.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetPlanet");

            targetLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>());

            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation).Returns(targetLocationStub.Object);

            var station = new MockedTeleportStation(
                ownerStub.Object,
                new List<IPath>() { pathStub.Object },
                currentLocationStub.Object
                );

            // act
            station.TeleportUnit(teleportingUnitMock.Object, targetLocationStub.Object);
            // assert
            teleportingUnitMock.VerifySet(x => x.CurrentLocation = targetLocationStub.Object, Times.Once);
        }

        [Test]
        public void TelportUnit_WhenAllVAlidationsPassSuccessfully_ShouldAddUnitToTargetLocationPlanetUnits()
        {
            var ownerStub = new Mock<IBusinessOwner>();
            var currentLocationStub = new Mock<ILocation>();
            currentLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationStub.Setup(x => x.Planet.Name).Returns("PlanetName");

            var resourcesStub = new Mock<IResources>();
            resourcesStub.Setup(x => x.BronzeCoins).Returns(1);
            resourcesStub.Setup(x => x.SilverCoins).Returns(1);
            resourcesStub.Setup(x => x.GoldCoins).Returns(1);

            var teleportingUnitMock = new Mock<IUnit>();
            teleportingUnitMock.Setup(x => x.CurrentLocation).Returns(currentLocationStub.Object);
            teleportingUnitMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            teleportingUnitMock.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(resourcesStub.Object);
            teleportingUnitMock.SetupSet(x => x.PreviousLocation = It.IsAny<ILocation>());
            teleportingUnitMock.SetupGet(x => x.PreviousLocation).Returns(teleportingUnitMock.Object.PreviousLocation);
            currentLocationStub.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { teleportingUnitMock.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetPlanet");

            var targetLocationPlanetUnits = new List<IUnit>();
            targetLocationStub.Setup(x => x.Planet.Units).Returns(targetLocationPlanetUnits);

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(targetLocationStub.Object.Planet.Name);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(targetLocationStub.Object.Planet.Galaxy.Name);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(targetLocationPlanetUnits);
            var galacticMapStub = new List<IPath>() { pathMock.Object };
            var station = new MockedTeleportStation(
                ownerStub.Object,
                galacticMapStub,
                currentLocationStub.Object
                );

            // act
            station.TeleportUnit(teleportingUnitMock.Object, targetLocationStub.Object);

            // assert
            Assert.AreEqual(1, pathMock.Object.TargetLocation.Planet.Units.Count);
            Assert.AreSame(teleportingUnitMock.Object, pathMock.Object.TargetLocation.Planet.Units.First());
        }

        [Test]
        public void TeleportUnit_WhenAllValidationsPassSuccesfully_ShouldRemoveUnitFromStationsCurrentLocationPlanetUnits()
        {

            var ownerStub = new Mock<IBusinessOwner>();
            var currentLocationMock = new Mock<ILocation>();
            currentLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("GalaxyName");
            currentLocationMock.Setup(x => x.Planet.Name).Returns("PlanetName");

            var resourcesStub = new Mock<IResources>();
            resourcesStub.Setup(x => x.BronzeCoins).Returns(1);
            resourcesStub.Setup(x => x.SilverCoins).Returns(1);
            resourcesStub.Setup(x => x.GoldCoins).Returns(1);

            var teleportingUnitMock = new Mock<IUnit>();
            teleportingUnitMock.Setup(x => x.CurrentLocation).Returns(currentLocationMock.Object);
            teleportingUnitMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            teleportingUnitMock.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(resourcesStub.Object);
            teleportingUnitMock.SetupSet(x => x.PreviousLocation = It.IsAny<ILocation>());
            teleportingUnitMock.SetupGet(x => x.PreviousLocation).Returns(teleportingUnitMock.Object.PreviousLocation);
            currentLocationMock.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { teleportingUnitMock.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name).Returns("TargetPlanet");

            var targetLocationPlanetUnits = new List<IUnit>();
            targetLocationStub.Setup(x => x.Planet.Units).Returns(targetLocationPlanetUnits);

            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation.Planet.Name).Returns(targetLocationStub.Object.Planet.Name);
            pathStub.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(targetLocationStub.Object.Planet.Galaxy.Name);
            pathStub.Setup(x => x.TargetLocation.Planet.Units).Returns(targetLocationPlanetUnits);
            var galacticMapStub = new List<IPath>() { pathStub.Object };
            var station = new MockedTeleportStation(
                ownerStub.Object,
                galacticMapStub,
                currentLocationMock.Object
                );
            // act
            station.TeleportUnit(teleportingUnitMock.Object, targetLocationStub.Object);

            // assert
            Assert.AreEqual(0, currentLocationMock.Object.Planet.Units.Count);
        }

        [Test]
        public void PayProfits_WhenInputParameterIsTheActualOwner_ShoudREturnTotalAmountOfResourcesGeneratedByTeleportStation()
        {
            // arrange
            uint allCoinsValues = 10;

            var ownerStub = new Mock<IBusinessOwner>();
            var locationStub = new Mock<ILocation>();
            var mapStub = new List<IPath>();

            var stationMock = new MockedTeleportStation(
                ownerStub.Object,
                mapStub,
                locationStub.Object
                );

            stationMock.Resources.BronzeCoins = allCoinsValues;
            stationMock.Resources.GoldCoins = allCoinsValues;
            stationMock.Resources.SilverCoins = allCoinsValues;

            // act
            var returnedObj = stationMock.PayProfits(ownerStub.Object);

            // assert
            Assert.AreEqual(allCoinsValues, returnedObj.GoldCoins);
            Assert.AreEqual(allCoinsValues, returnedObj.BronzeCoins);
            Assert.AreEqual(allCoinsValues, returnedObj.SilverCoins);
        }
    }
}
