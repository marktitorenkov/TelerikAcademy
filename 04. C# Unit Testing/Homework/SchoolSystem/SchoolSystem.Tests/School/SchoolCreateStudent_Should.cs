namespace SchoolSystem.Tests.School
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SchoolSystem;

	[TestClass]
	public class SchoolCreateStudent_Should
	{
		[TestMethod]
		public void SchoolCreateStudent_Should_ThrowAnException_WhenIDLimitExceded()
		{
			var school = new School();
				
			Assert.ThrowsException<Exception>(delegate()
			{
				for (int i = 0; i <= 90000; i++)
				{
					school.CreateStudent("Valid", "Name");
				}
			});
		}

		[TestMethod]
		public void SchoolCreateStudent_Should_ReturnCorrectStudent_WhenValidNameGiven()
		{
			var school = new School();
			var validStudent = new Student("Valid", "Name", 10000);
			var testStudent = school.CreateStudent("Valid", "Name");

			Assert.IsTrue(
				validStudent.FirstName == testStudent.FirstName &&
				validStudent.LastName == testStudent.LastName &&
				validStudent.Id == testStudent.Id
			);
		}

		[TestMethod]
		public void SchoolCreateStudent_Should_CreateStudents_With_ConsecutiveIds()
		{
			bool validID = true;
			var school = new School();

			for (int i = 0; i < 4; i++)
			{
				var student = school.CreateStudent("Valid", "Name");
				if (student.Id != 10000 + i)
				{
					validID = false;
				}
			}
			Assert.IsTrue(validID);
		}
	}
}
