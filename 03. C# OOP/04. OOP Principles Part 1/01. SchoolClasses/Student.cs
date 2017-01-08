namespace SchoolClasses
{
	class Student: Person, IComentable
	{
		public Student(string name, int classNumber)
			: base(name)
		{
			this.ClassNumber = classNumber;
		}
		public Student(string name, int classNumber, string comment)
			: this(name, classNumber)
		{
			base.Comment = comment;
		}

		public int ClassNumber { get; }
	}
}