using System;
using System.Collections.Generic;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.Fakes;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
	[TestFixture]
	public class TeleportStationTests
	{
		[Test]
		public void Constructor_ShouldSetupAllProvidedValidParameters()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();
			var galacticMapMock = new Mock<IEnumerable<IPath>>();
			var locationMock = new Mock<ILocation>();

			// Act
			var station = new TeleportStationFake(ownerMock.Object, galacticMapMock.Object, locationMock.Object);

			// Assert
			Assert.AreSame(station.Owner, ownerMock.Object);
			Assert.AreSame(station.GalacticMap, galacticMapMock.Object);
			Assert.AreSame(station.Location, locationMock.Object);
		}

		[Test]
		public void TeleportUnit_ShouldThrowArgumentNullException_WhenUnitToTeleportIsNull()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();
			var galacticMapMock = new Mock<IEnumerable<IPath>>();
			var locationMock = new Mock<ILocation>();

			var station = new TeleportStation(ownerMock.Object, galacticMapMock.Object, locationMock.Object);

			// Act & Assert
			var ex = Assert.Throws<ArgumentNullException>(() => station.TeleportUnit(null, locationMock.Object));
			StringAssert.Contains("unitToTeleport", ex.Message);
		}

		[Test]
		public void TeleportUnit_ShouldThrowArgumentNullException_WhenTargetLocationIsNull()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();
			var galacticMapMock = new Mock<IEnumerable<IPath>>();
			var locationMock = new Mock<ILocation>();
			var unitMock = new Mock<IUnit>();

			var station = new TeleportStation(ownerMock.Object, galacticMapMock.Object, locationMock.Object);

			// Act & Assert
			var ex = Assert.Throws<ArgumentNullException>(
				() => station.TeleportUnit(unitMock.Object, null)
			);
			StringAssert.Contains("destination", ex.Message);
		}

		[Test]
		public void TeleportUnit_ShouldThrowTeleportOutOfRangeException_WhenUnitIsTryingToUseTheStationFromADistantLocation()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();
			var galacticMapMock = new Mock<IEnumerable<IPath>>();
			var targetLocationMock = new Mock<ILocation>();

			var stationLocationMock = new Mock<ILocation>();
			stationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("Galaxy1");
			stationLocationMock.Setup(x => x.Planet.Name).Returns("Planet1");

			var unitMock = new Mock<IUnit>();
			unitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Galaxy1");
			unitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("Planet2");

			var station = new TeleportStation(ownerMock.Object, galacticMapMock.Object, stationLocationMock.Object);

			// Act & Assert
			var ex = Assert.Throws<TeleportOutOfRangeException>(
				() => station.TeleportUnit(unitMock.Object, targetLocationMock.Object)
			);
			StringAssert.Contains("unitToTeleport.CurrentLocation", ex.Message);
		}

		[Test]
		public void TeleportUnit_ShouldThrowInvalidTeleportationLocationException_WhenTargetLocationIsTakenByAntherUnit()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();

			var stationLocationMock = new Mock<ILocation>();
			stationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("StartGalaxy");
			stationLocationMock.Setup(x => x.Planet.Name).Returns("StartPlanet");

			var unitToTeleportMock = new Mock<IUnit>();
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("StartGalaxy");
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("StartPlanet");

			var unitAtTargetLocationMock = new Mock<IUnit>();
			unitAtTargetLocationMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("TargetGalaxy");
			unitAtTargetLocationMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("TargetPlanet");
			unitAtTargetLocationMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(0d);
			unitAtTargetLocationMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(0d);

			var targetLocationMock = new Mock<ILocation>();
			targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
			targetLocationMock.Setup(x => x.Planet.Name).Returns("TargetPlanet");
			targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(0d);
			targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(0d);
			targetLocationMock.Setup(x => x.Planet.Units).Returns(new List<IUnit>() { unitAtTargetLocationMock.Object });

			var pathToTargetLocationMock = new Mock<IPath>();
			pathToTargetLocationMock.Setup(x => x.TargetLocation).Returns(targetLocationMock.Object);

			var galacticMap = new List<IPath>() { pathToTargetLocationMock.Object };

			var station = new TeleportStation(ownerMock.Object, galacticMap, stationLocationMock.Object);

			// Act & Assert
			var ex = Assert.Throws<InvalidTeleportationLocationException>(
				() => station.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object)
			);
			StringAssert.Contains("units will overlap", ex.Message);
		}

		[Test]
		public void TelePortUnit_ShouldThrowLocationNotFoundException_WhenTeleportingToAGalaxyNotInTheList()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();

			var stationLocationMock = new Mock<ILocation>();
			stationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("StartGalaxy");
			stationLocationMock.Setup(x => x.Planet.Name).Returns("StartPlanet");

			var unitToTeleportMock = new Mock<IUnit>();
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("StartGalaxy");
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("StartPlanet");

			var targetLocationMock = new Mock<ILocation>();
			targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
			targetLocationMock.Setup(x => x.Planet.Name).Returns("TargetPlanet");

			// Galaxy and planet are different
			var locationInMapMock = new Mock<ILocation>();
			locationInMapMock.Setup(x => x.Planet.Galaxy.Name).Returns("NotTargetGalaxy");
			locationInMapMock.Setup(x => x.Planet.Name).Returns("NotTargetPlanet");

			var pathInMapMock = new Mock<IPath>();
			pathInMapMock.Setup(x => x.TargetLocation).Returns(locationInMapMock.Object);

			var galacticMap = new List<IPath>() { pathInMapMock.Object };

			var station = new TeleportStation(ownerMock.Object, galacticMap, stationLocationMock.Object);

			// Act & Assert
			var ex = Assert.Throws<LocationNotFoundException>(
				() => station.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object)
			);
			StringAssert.Contains("Galaxy", ex.Message);
		}

		[Test]
		public void TelePortUnit_ShouldThrowLocationNotFoundException_WhenTeleportingToAPlanetNotInTheList()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();

			var stationLocationMock = new Mock<ILocation>();
			stationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("StartGalaxy");
			stationLocationMock.Setup(x => x.Planet.Name).Returns("StartPlanet");

			var unitToTeleportMock = new Mock<IUnit>();
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("StartGalaxy");
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("StartPlanet");

			var targetLocationMock = new Mock<ILocation>();
			targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
			targetLocationMock.Setup(x => x.Planet.Name).Returns("TargetPlanet");

			// Galaxy is the same, planet is not
			var locationInMapMock = new Mock<ILocation>();
			locationInMapMock.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
			locationInMapMock.Setup(x => x.Planet.Name).Returns("NotTargetPlanet");

			var pathInMapMock = new Mock<IPath>();
			pathInMapMock.Setup(x => x.TargetLocation).Returns(locationInMapMock.Object);

			var galacticMap = new List<IPath>() { pathInMapMock.Object };

			var station = new TeleportStation(ownerMock.Object, galacticMap, stationLocationMock.Object);

			// Act & Assert
			var ex = Assert.Throws<LocationNotFoundException>(
				() => station.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object)
			);
			StringAssert.Contains("Planet", ex.Message);
		}

		[Test]
		public void TeleportUnit_ShouldThrowInsufficientResourcesException_WhenTheUnitDoesntHaveEnoughResources()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();

			var stationLocationMock = new Mock<ILocation>();
			stationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("StartGalaxy");
			stationLocationMock.Setup(x => x.Planet.Name).Returns("StartPlanet");

			var unitToTeleportMock = new Mock<IUnit>();
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("StartGalaxy");
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("StartPlanet");
			unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(false);

			var targetLocationMock = new Mock<ILocation>();
			targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
			targetLocationMock.Setup(x => x.Planet.Name).Returns("TargetPlanet");
			targetLocationMock.Setup(x => x.Planet.Units).Returns(new List<IUnit>());

			var targetPathMock = new Mock<IPath>();
			targetPathMock.Setup(x => x.TargetLocation).Returns(targetLocationMock.Object);

			var galacticMap = new List<IPath>() { targetPathMock.Object };

			var station = new TeleportStation(ownerMock.Object, galacticMap, stationLocationMock.Object);

			// Act & Assert
			var ex = Assert.Throws<InsufficientResourcesException>(
				() => station.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object)
			);
			StringAssert.Contains("FREE LUNCH", ex.Message);
		}

		[Test]
		public void TeleportUnit_ShouldRequireAPaymentFromTheUnit_WhenAllValidationsPassSuccessfully()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();

			var stationLocationMock = new Mock<ILocation>();
			stationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("StartGalaxy");
			stationLocationMock.Setup(x => x.Planet.Name).Returns("StartPlanet");

			var unitToTeleportMock = new Mock<IUnit>();
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("StartGalaxy");
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("StartPlanet");
			unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

			var unitResources = new Mock<IResources>();
			unitResources.Setup(x => x.GoldCoins).Returns(40);
			unitResources.Setup(x => x.SilverCoins).Returns(30);
			unitResources.Setup(x => x.BronzeCoins).Returns(20);
			unitToTeleportMock.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(unitResources.Object);

			var targetLocationMock = new Mock<ILocation>();
			targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
			targetLocationMock.Setup(x => x.Planet.Name).Returns("TargetPlanet");
			targetLocationMock.Setup(x => x.Planet.Units).Returns(new List<IUnit>());

			var pathCostMock = new Mock<IResources>();

			var targetPathMock = new Mock<IPath>();
			targetPathMock.Setup(x => x.TargetLocation).Returns(targetLocationMock.Object);
			targetPathMock.Setup(x => x.Cost).Returns(pathCostMock.Object);

			var galacticMap = new List<IPath>() { targetPathMock.Object };

			var station = new TeleportStation(ownerMock.Object, galacticMap, stationLocationMock.Object);

			// Act & Assert
			Assert.Catch( // Exception from teleporting after payment
				() => station.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object)
			);
			unitToTeleportMock.Verify(x => x.Pay(It.IsAny<IResources>()), Times.Once);
		}

		[Test]
		public void TeleportUnit_ShouldObtainPaymentFromTheUnit_WhenAllValidationsPassSuccessfully()
		{
			// Arrange
			var ownerMock = new Mock<IBusinessOwner>();

			var stationLocationMock = new Mock<ILocation>();
			stationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("StartGalaxy");
			stationLocationMock.Setup(x => x.Planet.Name).Returns("StartPlanet");

			var unitToTeleportMock = new Mock<IUnit>();
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("StartGalaxy");
			unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("StartPlanet");
			unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

			var unitResources = new Mock<IResources>();
			unitResources.Setup(x => x.GoldCoins).Returns(40);
			unitResources.Setup(x => x.SilverCoins).Returns(30);
			unitResources.Setup(x => x.BronzeCoins).Returns(20);
			unitToTeleportMock.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(unitResources.Object);

			var targetLocationMock = new Mock<ILocation>();
			targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("TargetGalaxy");
			targetLocationMock.Setup(x => x.Planet.Name).Returns("TargetPlanet");
			targetLocationMock.Setup(x => x.Planet.Units).Returns(new List<IUnit>());

			var pathCostMock = new Mock<IResources>();

			var targetPathMock = new Mock<IPath>();
			targetPathMock.Setup(x => x.TargetLocation).Returns(targetLocationMock.Object);
			targetPathMock.Setup(x => x.Cost).Returns(pathCostMock.Object);

			var galacticMap = new List<IPath>() { targetPathMock.Object };

			var station = new TeleportStationFake(ownerMock.Object, galacticMap, stationLocationMock.Object);

			// Act & Assert
			Assert.Catch( // Exception from teleporting after payment
				() => station.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object)
			);
			Assert.AreEqual(station.Resources.GoldCoins, 40);
			Assert.AreEqual(station.Resources.SilverCoins, 30);
			Assert.AreEqual(station.Resources.BronzeCoins, 20);
		}
	}
}
