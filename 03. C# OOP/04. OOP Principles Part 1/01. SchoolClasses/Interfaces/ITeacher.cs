namespace SchoolClasses.Interfaces
{
	using System.Collections.Generic;

	interface ITeacher : IComentable
	{
		IEnumerable<Discipline> Disciplines { get; }
	}
}