using System;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
	[TestFixture]
	public class ResourcesFactoryTests
	{
		[TestCase("create resources gold(20) silver(30) bronze(40)")]
		[TestCase("create resources gold(20) bronze(40) silver(30)")]
		[TestCase("create resources silver(30) bronze(40) gold(20)")]
		[TestCase("create resources silver(30) gold(20) bronze(40)")]
		[TestCase("create resources bronze(40) gold(20) silver(30)")]
		[TestCase("create resources bronze(40) silver(30) gold(20)")]
		public void GetResources_ShouldReturnAResourcesObjectWithCorrectlySetUpProperties(string command)
		{
			// Arrange
			var factory = new ResourcesFactory();
			// Expected
			uint gold = 20;
			uint silver = 30;
			uint bronze = 40;

			// Act
			var resource = factory.GetResources(command);

			// Assert
			Assert.AreEqual(resource.GoldCoins, gold);
			Assert.AreEqual(resource.SilverCoins, silver);
			Assert.AreEqual(resource.BronzeCoins, bronze);
		}

		[TestCase("create resources 20 30 40")]
		[TestCase("tansta resources a b")]
		[TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
		public void GetResources_ShouldThrowInvalidOperationException_WhenTheCommandIsinvalid(string command)
		{
			// Arrange
			var factory = new ResourcesFactory();

			// Act & Arrange
			var ex = Assert.Throws<InvalidOperationException>(() => factory.GetResources(command));
			StringAssert.Contains("command", ex.Message.ToLower());
		}

		[TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
		[TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
		[TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
		public void GetResources_ShouldThrowOverflowException_WhenFormatIsCorrectButValuesOverflow(string command)
		{
			// Arrange
			var factory = new ResourcesFactory();

			// Act & Arrange
			Assert.Throws<OverflowException>(() => factory.GetResources(command));
		}
	}
}
