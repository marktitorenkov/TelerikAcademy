using System;
using NUnit.Framework;

namespace Academy.Tests.Models.Abstractions.UserTests
{
	[TestFixture]
	public class UserUsername_Should
	{
		[Test]
		public void CorrectlyAssignValidValue()
		{
			// Arrange
			var userfake = new UserFake("old name");

			// Act
			userfake.Username = "new name";

			Assert.AreEqual("new name", userfake.Username);
		}

		[Test]
		public void ThrowArguemntException_WhenPassedValueIsTooShort()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new UserFake("aa"));
		}

		[Test]
		public void ThrowArguemntException_WhenPassedValueIsTooLong()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new UserFake(new string('a', 17)));
		}
	}
}
