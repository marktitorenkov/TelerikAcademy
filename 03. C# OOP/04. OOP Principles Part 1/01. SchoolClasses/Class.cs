namespace SchoolClasses
{
	using System.Collections.Generic;

	class Class: IComentable
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

		public IList<Teacher> Teachers { get; }
		public string Identifier { get; }

		public string Comment { get; set; }
	}
}