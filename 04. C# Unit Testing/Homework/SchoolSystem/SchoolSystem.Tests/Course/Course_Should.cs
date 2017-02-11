namespace SchoolSystem.Tests.Course
{
	using System;
	using NUnit.Framework;
	using SchoolSystem;

	[TestFixture]
	public class Course_Should
	{
		[Test]
		public void SetName_WhenValidNamePassed()
		{
			// Arrange & Act
			var course = new Course("Valid name");

			// Assert
			Assert.AreEqual("Valid name", course.Name);
		}

		[Test]
		public void InitilizeStudentsCollection_WhenValidNamePassed()
		{
			// Arrange & Act
			var course = new Course("Valid name");

			// Assert
			Assert.IsNotNull(course.Students);
		}

		[Test]
		public void ThrowArgumentException_WhenEmptyStringNameIsPassed()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Course(""));
		}

		[Test]
		public void ThrowArgumentException_WhenOnlyWhiteSpaceNameIsPassed()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Course("      "));
		}

		[Test]
		public void ThrowArgumentException_WhenNullNameIsPassed()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Course(null));
		}
	}
}
