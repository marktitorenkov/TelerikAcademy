using System.Collections.Generic;
using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
	[TestFixture]
	public class BusinessOwnerTests
	{
		[Test]
		public void CollectProfits_ShouldIncreaseTheOwnerResourcesByTheAmountGeneratedByHisStations()
		{
			// Arrange
			var stationsList = new List<ITeleportStation>();
			var owner = new BusinessOwner(0, "Ownername", stationsList);

			var station1ResourcesMock = new Mock<IResources>();
			station1ResourcesMock.Setup(x => x.GoldCoins).Returns(40);
			station1ResourcesMock.Setup(x => x.SilverCoins).Returns(30);
			station1ResourcesMock.Setup(x => x.BronzeCoins).Returns(20);

			var station1Mock = new Mock<ITeleportStation>();
			station1Mock.Setup(x => x.PayProfits(owner)).Returns(station1ResourcesMock.Object);

			var station2ResourcesMock = new Mock<IResources>();
			station2ResourcesMock.Setup(x => x.GoldCoins).Returns(50);
			station2ResourcesMock.Setup(x => x.SilverCoins).Returns(40);
			station2ResourcesMock.Setup(x => x.BronzeCoins).Returns(30);

			var station2Mock = new Mock<ITeleportStation>();
			station2Mock.Setup(x => x.PayProfits(owner)).Returns(station2ResourcesMock.Object);

			stationsList.Add(station1Mock.Object);
			stationsList.Add(station2Mock.Object);

			// Act
			owner.CollectProfits();

			// Assert
			Assert.AreEqual(owner.Resources.GoldCoins, 90);
			Assert.AreEqual(owner.Resources.SilverCoins, 70);
			Assert.AreEqual(owner.Resources.BronzeCoins, 50);
		}
	}
}
