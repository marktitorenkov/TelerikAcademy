namespace SchoolClasses
{
	using System.Collections.Generic;

	class Teacher: Person, IComentable
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

		IList<Discipline> Disciplines { get; }
	}
}