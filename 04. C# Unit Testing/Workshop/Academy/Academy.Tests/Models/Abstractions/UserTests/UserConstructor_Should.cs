using NUnit.Framework;

namespace Academy.Tests.Models.Abstractions.UserTests
{
	[TestFixture]
	public class UserConstructor_Should
	{
		[Test]
		public void CorrectlyAssignUsername()
		{
			// Arrange & Act
			var userFake = new UserFake("username");

			// Assert
			Assert.AreEqual("username", userFake.Username);
		}
	}
}
