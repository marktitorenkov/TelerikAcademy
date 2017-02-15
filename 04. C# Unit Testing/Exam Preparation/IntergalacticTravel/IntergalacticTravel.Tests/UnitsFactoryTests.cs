using IntergalacticTravel;
using IntergalacticTravel.Exceptions;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
	[TestFixture]
	public class UnitsFactoryTests
	{
		[Test]
		public void GetUnitShould_ReturnNewProcyonUnit_WhenAValidCorrespondingCommandIsPassed()
		{
			// Arrange
			var factory = new UnitsFactory();

			// Act
			var unit = factory.GetUnit("create unit Procyon Gosho 1");

			// Assert
			Assert.IsInstanceOf(typeof(Procyon), unit);
		}

		[Test]
		public void GetUnitShould_ReturnNewLuytenUnit_WhenAValidCorrespondingCommandIsPassed()
		{
			// Arrange
			var factory = new UnitsFactory();

			// Act
			var unit = factory.GetUnit("create unit Luyten Pesho 2");

			// Assert
			Assert.IsInstanceOf(typeof(Luyten), unit);
		}

		[Test]
		public void GetUnitShould_ReturnNewLacailleUnit_WhenAValidCorrespondingCommandIsPassed()
		{
			// Arrange
			var factory = new UnitsFactory();

			// Act
			var unit = factory.GetUnit("create unit Lacaille Pesho 2");

			// Assert
			Assert.IsInstanceOf(typeof(Lacaille), unit);
		}

		[TestCase("")]
		[TestCase("unit Lacaille Pesho 2")]
		[TestCase("create unit Pesho 2")]
		public void GetunitShould_ThrowInvalidUnitCreationCommandException_WhenTheCommandIsNotInTheValidFormat(string command)
		{
			// Arrange
			var factory = new UnitsFactory();

			// Act & Assert
			Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(command));
		}
	}
}
