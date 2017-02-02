namespace SchoolClasses
{
	using System.Collections.Generic;
	using Interfaces;

	class Teacher: Person, ITeacher, IComentable
	{
		public Teacher(string name, IList<Discipline> collection)
			: base(name)
		{
			this.Disciplines = collection;
		}
		public Teacher(string name, IList<Discipline> collection, string comment)
			: this(name, collection)
		{
			base.Comment = comment;
		}

		public IEnumerable<Discipline> Disciplines { get; }
	}
}