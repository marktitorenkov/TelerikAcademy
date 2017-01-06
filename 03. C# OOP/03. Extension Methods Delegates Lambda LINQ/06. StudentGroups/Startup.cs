namespace StudentGroups
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	class Startup
	{
		static void Main()
		{
			#region SampleStudents
			var students = new List<Student>()
			{
				new Student("Georgi", "Dimitrov", "120005", "012/1243567", "g.dimitrova@abv.bg", new List<byte> { 3, 4, 4 }, 1),
				new Student("Antoan", "Antonov", "130006", "043/1234567", "antoan.a@abv.bg", new List<byte> { 6, 6, 6 }, 2),
				new Student("Gosho", "Peshov", "180005", "056/550002", "meme@abv.bg", new List<byte> { 6, 6, 4 }, 2),
				new Student("Plamena", "Lakova", "190006", "02/9550503", "plamena_l@gmail.com", new List<byte> { 5, 6, 5 }, 2),
				new Student("Fikret", "Stoqnov", "010005", "02/8550603", "fiki_s@gmail.com", new List<byte> { 4, 4, 3 }, 3),
				new Student("Lora", "Stoqnova", "050006", "02/9544003", "lora_s@hotmail.com", new List<byte> { 2, 2, 3 }, 2)
			};
			#endregion

			var group2Linq = from student in students
							 where student.GroupNumber == 2 orderby student.FirstName
							 select student;
			Console.WriteLine("Students in group 2 (Linq):");
			foreach (var student in group2Linq)
			{
				Console.WriteLine(student + ", Group: " + student.GroupNumber);
			}

			var group2Lambda = students.Where(student => student.GroupNumber == 2);
			Console.WriteLine("\nStudents in group 2 (Lambda):");
			foreach (var student in group2Lambda)
			{
				Console.WriteLine(student + ", Group: " + student.GroupNumber);
			}

			var abvMail = from student in students
						  where student.Email.Contains("abv.bg")
						  select student;
			Console.WriteLine("\nStudents that have email in abv.bg:");
			foreach (var student in abvMail)
			{
				Console.WriteLine(student + ", Email: " + student.Email);
			}

			var phoneInSofia = from student in students
							   where student.Tel.Split('/')[0] == "02"
							   select student;
			Console.WriteLine("\nStudents with phones in Sofia:");
			foreach (var student in phoneInSofia)
			{
				Console.WriteLine(student + ", Tel: " + student.Tel);
			}

			var hasExcellent = from student in students
							   where student.Marks.Contains(6)
							   select new
							   {
								   FullName = student.FirstName + " " + student.LastName,
								   Marks = string.Join(", ", student.Marks)
							   };
			Console.WriteLine("\nStudents that have at least one mark Excellent (6):");
			foreach (var student in hasExcellent)
			{
				Console.WriteLine(student);
			}

			var hasTwoMarks2 = students.Where(student => student.Marks.FindAll(mark => mark == 2).Count == 2);
			Console.WriteLine("\nStudents with exactly two marks 2:");
			foreach (var student in hasTwoMarks2)
			{
				Console.WriteLine(student + ", Marks: " + string.Join(", ", student.Marks));
			}

			var studentsIn2006 = students.Where(student => student.FN.Substring(4, 2) == "06");
			Console.WriteLine("\nStudents that enrolled in 2006:");
			foreach (var student in studentsIn2006)
			{
				Console.WriteLine(student + ", FN: " + student.FN);
			}
		}
	}
}