using System;
using System.Collections.Generic;
using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;

namespace Academy.Tests.Models.CourseTests
{
	[TestFixture]
	public class CourseConstructor_Should
	{
		[Test]
		public void CorrectlyAssignName()
		{
			// Arrange & Act
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Assert
			Assert.AreEqual("Name", course.Name);
		}

		[Test]
		public void CorrectlyAssignLecturesPerWeek()
		{
			// Arrange & Act
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Assert
			Assert.AreEqual(5, course.LecturesPerWeek);
		}

		[Test]
		public void CorrectlyAssignStartingDate()
		{
			// Arrange & Act
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Assert
			Assert.AreEqual(new DateTime(2017, 1, 1), course.StartingDate);
		}

		[Test]
		public void CorrectlyAssignEndingDate()
		{
			// Arrange & Act
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Assert
			Assert.AreEqual(new DateTime(2017, 2, 1), course.EndingDate);
		}

		[Test]
		public void CorrectlyInitilizeOnsiteStudentsCollection()
		{
			// Arrange & Act
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Assert
			Assert.IsInstanceOf(typeof(IList<IStudent>), course.OnsiteStudents);
		}

		[Test]
		public void CorrectlyInitilizeOnlineStudentsCollection()
		{
			// Arrange & Act
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Assert
			Assert.IsInstanceOf(typeof(IList<IStudent>), course.OnlineStudents);
		}

		[Test]
		public void CorrectlyInitilizeLecturesCollection()
		{
			// Arrange & Act
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Assert
			Assert.IsInstanceOf(typeof(IList<ILecture>), course.Lectures);
		}
	}
}
