namespace StudentsAndWorkers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Models;

	public class Startup
	{
		static void Main()
		{
			#region Samples
			var students = new List<Student>()
			{
				new Student("James", "Clinton", 5f),
				new Student("Mark", "Harrison", 5.8f),
				new Student("Patrice", "Hobson", 4.2f),
				new Student("Leyla", "Foss", 6.0f),
				new Student("Darin", "Cokes", 5.5f),
				new Student("Jason", "Greene", 4.0f),
				new Student("Brendan", "Wallace", 4.5f),
				new Student("Nia", "Barlow", 5.2f),
				new Student("Tobin", "Fletcher", 6.0f),
				new Student("Hubert", "Breckenridge", 4.0f)
			};
			var workers = new List<Worker>()
			{
				new Worker("Anthonny", "Everill", 250, 8),
				new Worker("Rica", "Day", 400, 8),
				new Worker("Petunia", "Davis", 150, 5),
				new Worker("Divina", "Barnet", 500, 7),
				new Worker("Yvette", "Thorn", 100, 4),
				new Worker("James", "Britton", 120, 8),
				new Worker("Melany", "Knaggs", 80, 3),
				new Worker("Dean", "Massey", 900, 8),
				new Worker("Colin", "Earl", 800, 8),
				new Worker("Jody", "Arthur", 200, 7)
			};
			#endregion

			var studentsByGrade = from s in students
								  orderby s.Grade, s.FirstName, s.LastName 
								  select s;
			Console.WriteLine("Students by grade in ascending order:");
			foreach (var student in studentsByGrade)
			{
				Console.WriteLine($"{student} - {student.GradeWithWords} ({student.Grade:F2})");
			}

			var workersByMoneyPerHour = from w in workers
								  orderby w.MoneyPerHour() descending, w.FirstName, w.LastName 
								  select w;
			Console.WriteLine("\nWorkers by money per hour in descending order:");
			foreach (var worker in workersByMoneyPerHour)
			{
				Console.WriteLine($"{worker} - {worker.MoneyPerHour():F2}lv");
			}

			var humans = new List<Human>();
			humans.AddRange(students);
			humans.AddRange(workers);
			var sortedHumans = from h in humans orderby h.FirstName, h.LastName select h;
			Console.WriteLine("\nHumans by first and last name:");
			foreach (var human in sortedHumans)
			{
				Console.WriteLine(human);
			}
		}
	}
}