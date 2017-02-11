namespace SchoolSystem
{
	using System;
	using System.Text.RegularExpressions;
	using Contracts;

	public class Student : IStudent
	{
		public Student(string firstName, string lastName, int id)
		{
			if (firstName == null || lastName == null)
			{
				throw new ArgumentNullException("Name cannot be null.");
			}
			string validNamePattern = "^[A-Z][a-z]*$";
			if (!Regex.IsMatch(firstName, validNamePattern) || 
			    !Regex.IsMatch(lastName, validNamePattern))
			{
				throw new ArgumentException("Invalid name passed.");
			}
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Id = id;
		}

		public string FirstName { get; }
		public string LastName { get; }
		public int Id { get; }
	}
}