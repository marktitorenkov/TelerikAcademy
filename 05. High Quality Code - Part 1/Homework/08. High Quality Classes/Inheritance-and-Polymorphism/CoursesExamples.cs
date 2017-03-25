using System;
using InheritanceAndPolymorphism.Common;

namespace InheritanceAndPolymorphism
{
	class CoursesExamples
	{
		static void Main()
		{
			var localCourse = new LocalCourse("Databases", "Svetlin Nakov");
			Console.WriteLine(localCourse);

			localCourse.Lab = Lab.Ultimate;
			Console.WriteLine(localCourse);

			localCourse.Students.AddRange(new string[] { "Peter", "Maria" });

			Console.WriteLine(localCourse);

			localCourse.Students.Add("Milena");
			localCourse.Students.Add("Todor");
			Console.WriteLine(localCourse);

			var offsiteCourse = new OffsiteCourse("PHP and WordPress Development", "Mario Peshev", "Plovdiv");
			offsiteCourse.Students.AddRange(new string[] { "Thomas", "Ani", "Steve" });
			Console.WriteLine(offsiteCourse);
		}
	}
}
