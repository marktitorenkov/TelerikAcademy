namespace SchoolClasses.Interfaces
{
	using System.Collections.Generic;

	interface IClass : IComentable
	{
		IEnumerable<Teacher> Teachers { get; }
		IEnumerable<Student> Students { get; }
	}
}