namespace Students
{
	using System;
	using System.Linq;

	class Startup
	{
		static Student[] firstBeforeLast(Student[] students)
		{
			var selected = from student in students
						 where student.FirstName.CompareTo(student.LastName) == -1
						 select student;
			return selected.ToArray();
		}
		static Student[] ageRange(Student[] students, byte min, byte max)
		{
			var selected = from student in students
						 where student.Age >= min && student.Age <= max
						 select student;
			return selected.ToArray();
		}
		static Student[] orderStudents(Student[] students)
		{
			return students.
				OrderByDescending(student => student.FirstName).
				ThenByDescending(student => student.LastName).
				ToArray();
		}
		static Student[] orderStudentsLinq(Student[] students)
		{
			var ordered = from student in students orderby 
						  student.FirstName descending, 
						  student.LastName descending
						  select student;
			return ordered.ToArray();
		}
		static void Main()
		{
			var students = new Student[]
			{
				new Student("Ivan", "Ivanov", 27),
				new Student("Petar", "Dimitrov", 32),
				new Student("Ioana", "Ruseva", 24),
				new Student("Ivan", "Dimitrov", 26),
				new Student("Georgi", "Atanasov", 19),
				new Student("Hristo", "Georgiev", 20)
			};

			Console.WriteLine("Students with first name before last name:");
			foreach (var student in firstBeforeLast(students))
			{
				Console.WriteLine($"{student}");
			}

			Console.WriteLine("\nStudents aged 18-24:");
			foreach (var student in ageRange(students, 18, 24))
			{
				Console.WriteLine($"{student}");
			}

			Console.WriteLine("\nStudents ordered by frist and last name (Lambda):");
			foreach (var student in orderStudents(students))
			{
				Console.WriteLine($"{student}");
			}

			Console.WriteLine("\nStudents ordered by frist and last name (Linq):");
			foreach (var student in orderStudentsLinq(students))
			{
				Console.WriteLine($"{student}");
			}
		}
	}
}