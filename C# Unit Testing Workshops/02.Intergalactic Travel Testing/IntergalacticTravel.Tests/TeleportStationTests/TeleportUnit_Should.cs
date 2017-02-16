namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;
    using System.Collections.Generic;
    using Exceptions;
    using Fakes;
    using System.Linq;

    [TestFixture]
    public class TeleportUnit_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithMessageContainingStringUnitToTeleport_WhenPassedUnitToTeleportIsNull()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();

            var station = new TeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            var targetLocationStub = new Mock<ILocation>();

            string expectedContainingMessage = "unitToTeleport";
            // act and assert
            var ex = Assert.Throws<ArgumentNullException>(
                () => station.TeleportUnit(null, targetLocationStub.Object)
                );

            StringAssert.Contains(expectedContainingMessage, ex.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithMessageContainingStringDestination_WhenPassedTargetLocationIsNull()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();
            var locationStub = new Mock<ILocation>();

            var station = new TeleportStation(ownerStub.Object, galacticMapStub, locationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();

            string expectedContainingMessage = "destination";
            // act and assert
            var ex = Assert.Throws<ArgumentNullException>(
                () => station.TeleportUnit(unitToTeleportStub.Object, null)
                );

            StringAssert.Contains(expectedContainingMessage, ex.Message);
        }

        [Test]
        public void ThrowTeleportOutOfRangeExceptionWithStringUnitToTeleportCurrentLocation_WhenUnitIsTryingToTeleportFromADistantLocation()
        {
            // arrange
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new List<IPath>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up units to teleport current location
            var unitCurrentLocationStub = new Mock<ILocation>();
            string unitCurrentLocationPlanetName = "Venus";
            string unitCurrentLocationGalaxyName = "Milky Way";
            unitCurrentLocationStub.Setup(x => x.Planet.Name)
                .Returns(unitCurrentLocationPlanetName);
            unitCurrentLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(unitCurrentLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(x => x.CurrentLocation)
                .Returns(unitCurrentLocationStub.Object);

            var targetLocationStub = new Mock<ILocation>();

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            string expectedMessageEx = "unitToTeleport.CurrentLocation";

            // act and assert
            var ex = Assert.Throws<TeleportOutOfRangeException>(
                () => station.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));

            StringAssert.Contains(expectedMessageEx, ex.Message);
        }

        [Test]
        public void ThrowInvalidTeleportationLocationExceptionWithStringUnitsWillOverlap_WhenUnitIsTryingToTeleportUnitToATakenLocation()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);

            // setting up target location
            string targetLocationPlanetName = "Earth";
            string targetLocationGalaxyName = "SomeGalaxy";
            double latitude = 10;
            double longtitude = 10;
            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            targetLocationStub.Setup(x => x.Coordinates.Latitude)
                .Returns(latitude);
            targetLocationStub.Setup(x => x.Coordinates.Longtitude)
                .Returns(longtitude);

            // You were up to here brat ;)
            var planetUnit = new Mock<IUnit>();
            planetUnit.Setup(x => x.CurrentLocation)
                .Returns(targetLocationStub.Object);
            var planetUnits = new List<IUnit>() { planetUnit.Object };

            var pathTargetLocation = new Mock<ILocation>();
            pathTargetLocation.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            pathTargetLocation.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            pathTargetLocation.Setup(x => x.Planet.Units)
                .Returns(planetUnits);

            // setting up target path
            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation)
                .Returns(pathTargetLocation.Object);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            string expectedMessageEx = "units will overlap";

            // act and assert
            var ex = Assert.Throws<InvalidTeleportationLocationException>(
                () => station.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));

            StringAssert.Contains(expectedMessageEx, ex.Message);
        }

        [Test]
        public void ThrowLocationNotFoundExceptionWithMessageWithStringGalaxy_WhenTryingToTeleportUnitToGalaxtWhichIsNotFoundInCurrentStation()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);

            // setting up target location
            var targetLocationStub = new Mock<ILocation>();
            string targetLocationGalaxyName = "SomeGalaxy";
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);

            // setting up path for the galactic map
            var pathStub = new Mock<IPath>();
            string targetGalaxyName = "OtherGalaxy";
            pathStub.Setup(x => x.TargetLocation.Planet.Galaxy.Name)
                .Returns(targetGalaxyName);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            string expectedMessageEx = "Galaxy";

            // act and assert
            var ex = Assert.Throws<LocationNotFoundException>(
                () => station.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));

            StringAssert.Contains(expectedMessageEx, ex.Message);
        }

        [Test]
        public void ThrowLocationNotFoundExceptionWithMessageWithStringPlanet_WhenTryingToTeleportUnitToPlanetWhichIsNotFoundInCurrentStation()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);

            // setting up target location
            var targetLocationStub = new Mock<ILocation>();
            string targetLocationGalaxyName = "SomeGalaxy";
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            string targetLocationPlanetName = "SomePlanet";
            targetLocationStub.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);

            // setting up path for the galactic map
            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            string pathTargetPlanet = "SomeOtherPlanet";
            pathStub.Setup(x => x.TargetLocation.Planet.Name)
                .Returns(pathTargetPlanet);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            string expectedMessageEx = "Planet";

            // act and assert
            var ex = Assert.Throws<LocationNotFoundException>(
                () => station.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));

            StringAssert.Contains(expectedMessageEx, ex.Message);
        }

        [Test]
        public void ThrowInsufficientResourcesExceptionWithMessageContainingFreeLunchString_WhenTryingToTeleportUnitWithLessThanRequieredResources()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);
            unitToTeleportStub.Setup(x => x.CanPay(It.IsAny<IResources>()))
                .Returns(false);

            // setting up target location
            string targetLocationPlanetName = "Earth";
            string targetLocationGalaxyName = "SomeGalaxy";
            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            // You were up to here brat ;)

            var pathTargetLocation = new Mock<ILocation>();
            pathTargetLocation.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            pathTargetLocation.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);

            var planetUnits = new List<IUnit>();
            pathTargetLocation.Setup(x => x.Planet.Units)
                .Returns(planetUnits);

            // setting up target path
            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation)
                .Returns(pathTargetLocation.Object);

            var pathCostStub = new Mock<IResources>();
            pathStub.Setup(x => x.Cost).Returns(pathCostStub.Object);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            string expectedMessageEx = "FREE LUNCH";

            // act and assert
            var ex = Assert.Throws<InsufficientResourcesException>(
                () => station.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));

            StringAssert.Contains(expectedMessageEx, ex.Message);
        }

        [Test]
        public void RequirePaymentFromTeleportingUnit_WhenAllValidationsPassSuccessfullyAndUnitIsReadyForTeleportation()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>()))
                .Returns(true);
            var payResources = new Mock<IResources>();
            uint coinsValues = 10;
            payResources.Setup(x => x.BronzeCoins).Returns(coinsValues);
            payResources.Setup(x => x.SilverCoins).Returns(coinsValues);
            payResources.Setup(x => x.GoldCoins).Returns(coinsValues);
            unitToTeleportMock.Setup(x => x.Pay(It.IsAny<IResources>()))
                .Returns(payResources.Object);

            var currentLocationUnits = new List<IUnit>() { unitToTeleportMock.Object };
            stationLocationStub.Setup(x => x.Planet.Units)
                .Returns(currentLocationUnits);

            // setting up target location
            string targetLocationPlanetName = "Earth";
            string targetLocationGalaxyName = "SomeGalaxy";
            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            // You were up to here brat ;)

            var pathTargetLocation = new Mock<ILocation>();
            pathTargetLocation.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            pathTargetLocation.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);

            var planetUnits = new List<IUnit>();
            pathTargetLocation.Setup(x => x.Planet.Units)
                .Returns(planetUnits);

            // setting up target path
            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation)
                .Returns(pathTargetLocation.Object);

            var pathCostStub = new Mock<IResources>();
            pathStub.Setup(x => x.Cost).Returns(pathCostStub.Object);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            // act
            station.TeleportUnit(unitToTeleportMock.Object, targetLocationStub.Object);

            // assert
            unitToTeleportMock.Verify(x => x.Pay(It.IsAny<IResources>()), Times.Once);
        }

        [Test]
        public void ObtainPaymentFromTheUnitToTeleport_WhenAllValidationsPassAndUnitIsReadyToTeleport()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>()))
                .Returns(true);
            var payResources = new Mock<IResources>();
            uint coinsValues = 10;
            payResources.Setup(x => x.BronzeCoins).Returns(coinsValues);
            payResources.Setup(x => x.SilverCoins).Returns(coinsValues);
            payResources.Setup(x => x.GoldCoins).Returns(coinsValues);
            unitToTeleportMock.Setup(x => x.Pay(It.IsAny<IResources>()))
                .Returns(payResources.Object);

            var currentLocationUnits = new List<IUnit>() { unitToTeleportMock.Object };
            stationLocationStub.Setup(x => x.Planet.Units)
                .Returns(currentLocationUnits);

            // setting up target location
            string targetLocationPlanetName = "Earth";
            string targetLocationGalaxyName = "SomeGalaxy";
            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            // You were up to here brat ;)

            var pathTargetLocation = new Mock<ILocation>();
            pathTargetLocation.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            pathTargetLocation.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);

            var planetUnits = new List<IUnit>();
            pathTargetLocation.Setup(x => x.Planet.Units)
                .Returns(planetUnits);

            // setting up target path
            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation)
                .Returns(pathTargetLocation.Object);

            var pathCostStub = new Mock<IResources>();
            pathStub.Setup(x => x.Cost).Returns(pathCostStub.Object);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new FakeTeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            // act
            station.TeleportUnit(unitToTeleportMock.Object, targetLocationStub.Object);

            // assert
            Assert.AreEqual(10, station.Resources.BronzeCoins);
            Assert.AreEqual(10, station.Resources.SilverCoins);
            Assert.AreEqual(10, station.Resources.GoldCoins);
        }

        [Test]
        public void SetUnitToTeleportPreviousLocationToTheCurrentLocation_WhenUnitIsSuccesfullyTeleported()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>()))
                .Returns(true);
            var payResources = new Mock<IResources>();
            uint coinsValues = 10;
            payResources.Setup(x => x.BronzeCoins).Returns(coinsValues);
            payResources.Setup(x => x.SilverCoins).Returns(coinsValues);
            payResources.Setup(x => x.GoldCoins).Returns(coinsValues);
            unitToTeleportMock.Setup(x => x.Pay(It.IsAny<IResources>()))
                .Returns(payResources.Object);
            unitToTeleportMock.SetupSet(
                x => x.PreviousLocation = It.Is<ILocation>(y => x == stationLocationStub.Object));
             
            var currentLocationUnits = new List<IUnit>() { unitToTeleportMock.Object };
            stationLocationStub.Setup(x => x.Planet.Units)
                .Returns(currentLocationUnits);

            // setting up target location
            string targetLocationPlanetName = "Earth";
            string targetLocationGalaxyName = "SomeGalaxy";
            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            // You were up to here brat ;)

            var pathTargetLocation = new Mock<ILocation>();
            pathTargetLocation.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            pathTargetLocation.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);

            var planetUnits = new List<IUnit>();
            pathTargetLocation.Setup(x => x.Planet.Units)
                .Returns(planetUnits);

            // setting up target path
            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation)
                .Returns(pathTargetLocation.Object);

            var pathCostStub = new Mock<IResources>();
            pathStub.Setup(x => x.Cost).Returns(pathCostStub.Object);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            // act
            station.TeleportUnit(unitToTeleportMock.Object, targetLocationStub.Object);

            // assert
            unitToTeleportMock.VerifySet(
                x => x.PreviousLocation = It.Is<ILocation>(y => y == stationLocationStub.Object), Times.Once);
        }

        [Test]
        public void SetUnitToTeleportCurrentLocationToTargetLocation_WhenUnitIsSuccesfullyTeleported()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportMock = new Mock<IUnit>();
            unitToTeleportMock.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>()))
                .Returns(true);
            var payResources = new Mock<IResources>();
            uint coinsValues = 10;
            payResources.Setup(x => x.BronzeCoins).Returns(coinsValues);
            payResources.Setup(x => x.SilverCoins).Returns(coinsValues);
            payResources.Setup(x => x.GoldCoins).Returns(coinsValues);
            unitToTeleportMock.Setup(x => x.Pay(It.IsAny<IResources>()))
                .Returns(payResources.Object);

            var currentLocationUnits = new List<IUnit>() { unitToTeleportMock.Object };
            stationLocationStub.Setup(x => x.Planet.Units)
                .Returns(currentLocationUnits);

            // setting up target location
            string targetLocationPlanetName = "Earth";
            string targetLocationGalaxyName = "SomeGalaxy";
            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            // You were up to here brat ;)

            unitToTeleportMock.SetupSet(
            x => x.CurrentLocation = It.Is<ILocation>(y => y == targetLocationStub.Object));

            var pathTargetLocation = new Mock<ILocation>();
            pathTargetLocation.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            pathTargetLocation.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);

            var planetUnits = new List<IUnit>();
            pathTargetLocation.Setup(x => x.Planet.Units)
                .Returns(planetUnits);

            // setting up target path
            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation)
                .Returns(pathTargetLocation.Object);

            var pathCostStub = new Mock<IResources>();
            pathStub.Setup(x => x.Cost).Returns(pathCostStub.Object);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new TeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            // act
            station.TeleportUnit(unitToTeleportMock.Object, targetLocationStub.Object);

            // assert
            unitToTeleportMock.VerifySet(
            x => x.CurrentLocation = It.Is<ILocation>(y => y == targetLocationStub.Object),
            Times.Once);
        }

        [Test]
        public void AddUnitToTeleportToTargetLocationPlanetUnits_WhenUnitIsTeleportedSuccessully()
        {
            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);
            unitToTeleportStub.Setup(x => x.CanPay(It.IsAny<IResources>()))
                .Returns(true);
            var payResources = new Mock<IResources>();
            uint coinsValues = 10;
            payResources.Setup(x => x.BronzeCoins).Returns(coinsValues);
            payResources.Setup(x => x.SilverCoins).Returns(coinsValues);
            payResources.Setup(x => x.GoldCoins).Returns(coinsValues);
            unitToTeleportStub.Setup(x => x.Pay(It.IsAny<IResources>()))
                .Returns(payResources.Object);

            var currentLocationUnits = new List<IUnit>() { unitToTeleportStub.Object };
            stationLocationStub.Setup(x => x.Planet.Units)
                .Returns(currentLocationUnits);

            // setting up target location
            string targetLocationPlanetName = "Earth";
            string targetLocationGalaxyName = "SomeGalaxy";
            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            // You were up to here brat ;)

            var pathTargetLocation = new Mock<ILocation>();
            pathTargetLocation.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            pathTargetLocation.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);

            var planetUnits = new List<IUnit>();
            pathTargetLocation.Setup(x => x.Planet.Units)
                .Returns(planetUnits);

            // setting up target path
            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation)
                .Returns(pathTargetLocation.Object);

            var pathCostStub = new Mock<IResources>();
            pathStub.Setup(x => x.Cost).Returns(pathCostStub.Object);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new FakeTeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            // act
            station.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);

            // assert
            Assert.AreSame(unitToTeleportStub.Object, planetUnits.First());
            Assert.AreEqual(1, pathStub.Object.TargetLocation.Planet.Units.Count);
        }

        [Test]
        public void RemoveUnitToTeleportFromCurrentLocationUnits_WhenUnitIsTeleportedSuccesfully()
        {

            // arrange
            var ownerStub = new Mock<IBusinessOwner>();

            // setting up stations current location
            var stationLocationStub = new Mock<ILocation>();
            string stationLocationPlanetName = "Mars";
            string stationLocationGalaxyName = "Milky Way";
            stationLocationStub.Setup(x => x.Planet.Name)
                .Returns(stationLocationPlanetName);
            stationLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(stationLocationGalaxyName);

            // setting up unit to teleport
            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(x => x.CurrentLocation)
                .Returns(stationLocationStub.Object);
            unitToTeleportStub.Setup(x => x.CanPay(It.IsAny<IResources>()))
                .Returns(true);
            var payResources = new Mock<IResources>();
            uint coinsValues = 10;
            payResources.Setup(x => x.BronzeCoins).Returns(coinsValues);
            payResources.Setup(x => x.SilverCoins).Returns(coinsValues);
            payResources.Setup(x => x.GoldCoins).Returns(coinsValues);
            unitToTeleportStub.Setup(x => x.Pay(It.IsAny<IResources>()))
                .Returns(payResources.Object);

            var currentLocationUnits = new List<IUnit>() { unitToTeleportStub.Object };
            stationLocationStub.Setup(x => x.Planet.Units)
                .Returns(currentLocationUnits);

            // setting up target location
            string targetLocationPlanetName = "Earth";
            string targetLocationGalaxyName = "SomeGalaxy";
            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            targetLocationStub.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);
            // You were up to here brat ;)

            var pathTargetLocation = new Mock<ILocation>();
            pathTargetLocation.Setup(x => x.Planet.Name)
                .Returns(targetLocationPlanetName);
            pathTargetLocation.Setup(x => x.Planet.Galaxy.Name)
                .Returns(targetLocationGalaxyName);

            var planetUnits = new List<IUnit>();
            pathTargetLocation.Setup(x => x.Planet.Units)
                .Returns(planetUnits);

            // setting up target path
            var pathStub = new Mock<IPath>();
            pathStub.Setup(x => x.TargetLocation)
                .Returns(pathTargetLocation.Object);

            var pathCostStub = new Mock<IResources>();
            pathStub.Setup(x => x.Cost).Returns(pathCostStub.Object);

            // setting up galactic map
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            var station = new FakeTeleportStation(
                ownerStub.Object,
                galacticMapStub,
                stationLocationStub.Object);

            // act
            station.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);

            // assert
            Assert.AreEqual(0, station.Location.Planet.Units.Count);
        }
    }
}
