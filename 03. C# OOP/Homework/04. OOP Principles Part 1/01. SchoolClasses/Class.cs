namespace SchoolClasses
{
	using System.Collections.Generic;
	using Interfaces;

	class Class: IClass, IComentable
	{
		public Class(string identifier, IList<Teacher> teachers)
		{
			this.Identifier = identifier;
			this.Teachers = teachers;
		}
		public Class(string identifier, IList<Teacher> teachers, string comment)
			: this(identifier, teachers)
		{
			this.Comment = comment;
		}

		public IEnumerable<Teacher> Teachers { get; }
		public IEnumerable<Student> Students { get; }
		public string Identifier { get; }
		public string Comment { get; }
	}
}