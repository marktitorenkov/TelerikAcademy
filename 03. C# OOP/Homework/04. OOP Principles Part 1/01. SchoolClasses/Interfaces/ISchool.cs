namespace SchoolClasses.Interfaces
{
	using System.Collections.Generic;

	interface ISchool
	{
		IEnumerable<Class> Classes { get; }
	}
}