namespace SchoolSystem.Tests.Student
{
	using System;
	using NUnit.Framework;
	using SchoolSystem;

	[TestFixture]
	public class Student_Should
	{
		[Test]
		public void SetCorrectFirstName_WhenValidValuesArePassed()
		{
			// Arrange & Act
			var student = new Student("First", "Name", 0);

			// Assert
			Assert.AreEqual("First", student.FirstName);
		}

		[Test]
		public void SetCorrectLastName_WhenValidValuesArePassed()
		{
			// Arrange & Act
			var student = new Student("First", "Name", 0);

			// Assert
			Assert.AreEqual("Name", student.LastName);
		}

		[Test]
		public void SetCorrectId_WhenValidValuesArePassed()
		{
			// Arrange & Act 
			var student = new Student("First", "Name", 0);

			// Assert
			Assert.AreEqual(0, student.Id);
		}

		[Test]
		public void ThrowArgumentException_WhenInvalidFirstNameIsPassed()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Student("first", "Name", 0));
		}

		[Test]
		public void ThrowArgumentException_WhenInvalidLastNameIsPassed()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Student("First", "name", 0));
		}

		[Test]
		public void ThrowArgumentException_WhenNullFirstNameIsPassed()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new Student(null, "Name", 0));
		}

		[Test]
		public void ThrowArgumentException_WhenNullLastNameIsPassed()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new Student("First", null, 0));
		}
	}
}
