namespace StudentGroups
{
	using System.Collections.Generic;

	public class Student
	{
		public Student(string firstName, string lastName, string fn, string tel, string email, List<byte> marks, int groupNumber)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.FN = fn;
			this.Tel = tel;
			this.Email = email;
			this.Marks = marks;
			this.GroupNumber = groupNumber;
		}

		public string FirstName { get; }
		public string LastName { get; }
		public string FN { get; }
		public string Tel { get; }
		public string Email { get; }
		public List<byte> Marks { get; }
		public int GroupNumber { get; }

		public override string ToString()
		{
			return $"{this.FirstName} {this.LastName}";
		}
	}
}