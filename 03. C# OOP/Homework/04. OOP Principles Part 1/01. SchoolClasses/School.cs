namespace SchoolClasses
{
	using System.Collections.Generic;
	using Interfaces;

	class School: ISchool
	{
		public School(IEnumerable<Class> classes)
		{
			this.Classes = classes;
		}

		public IEnumerable<Class> Classes { get; }
	}
}