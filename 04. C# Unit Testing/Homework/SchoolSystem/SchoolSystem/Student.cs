namespace SchoolSystem
{
	using System;
	using System.Text.RegularExpressions;

	public class Student
	{
		public Student(string firstName, string lastName, int id)
		{
			string validNamePattern = "^[A-Z][a-z]*$";
			if (!Regex.IsMatch(firstName, validNamePattern) || 
			    !Regex.IsMatch(lastName, validNamePattern))
			{
				throw new ArgumentException("Invalid name");
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