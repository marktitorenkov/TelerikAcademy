namespace Students
{
	class Student
	{
		public Student(string firstName, string lastName, byte age)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
		}

		public string FirstName { get; }
		public string LastName { get; }
		public byte Age { get; set; }

		public override string ToString()
		{
			return $"{this.FirstName} {this.LastName}, {this.Age}";
		}
	}
}
