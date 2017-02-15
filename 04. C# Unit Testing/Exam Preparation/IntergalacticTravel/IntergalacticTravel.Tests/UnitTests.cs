using System;
using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
	[TestFixture]
	public class UnitTests
	{
		[Test]
		public void PayShould_ThrowNullReferenceException_IfTheObjectPassedIsNull()
		{
			// Arrange
			var unit = new Unit(0, "name");

			// Act & Assert
			Assert.Throws<NullReferenceException>(() => unit.Pay(null));
		}

		[Test]
		public void PayShould_DecreaseTheOwnersResources_ByTheAmountOfCost()
		{
			// Arrange
			var unit = new Unit(0, "name");
			unit.Resources.GoldCoins = 60;
			unit.Resources.SilverCoins = 50;
			unit.Resources.BronzeCoins = 40;

			var costMock = new Mock<IResources>();
			costMock.Setup(x => x.GoldCoins).Returns(30);
			costMock.Setup(x => x.SilverCoins).Returns(20);
			costMock.Setup(x => x.BronzeCoins).Returns(10);

			// Act
			unit.Pay(costMock.Object);

			// Assert
			Assert.AreEqual(unit.Resources.GoldCoins, 30);
			Assert.AreEqual(unit.Resources.SilverCoins, 30);
			Assert.AreEqual(unit.Resources.BronzeCoins, 30);
		}

		[Test]
		public void PayShould_ReturnResourceObject_WithTheAmountOfCost()
		{
			// Arrange
			var unit = new Unit(0, "name");
			unit.Resources.GoldCoins = 60;
			unit.Resources.SilverCoins = 50;
			unit.Resources.BronzeCoins = 40;

			var costMock = new Mock<IResources>();
			costMock.Setup(x => x.GoldCoins).Returns(30);
			costMock.Setup(x => x.SilverCoins).Returns(20);
			costMock.Setup(x => x.BronzeCoins).Returns(10);

			// Act
			var paid = unit.Pay(costMock.Object);

			// Assert
			Assert.AreEqual(costMock.Object.GoldCoins, paid.GoldCoins);
			Assert.AreEqual(costMock.Object.SilverCoins, paid.SilverCoins);
			Assert.AreEqual(costMock.Object.BronzeCoins, paid.BronzeCoins);
		}
	}
}
