namespace StudentsAndWorkers.Models
{
	using System;
	using Interfaces;

	public class Student: Human, IHuman, IStudent
	{
		private float grade;

		public Student(string firstName, string lastName, float grade)
			: base(firstName, lastName)
		{
			this.Grade = grade;
		}

		public float Grade
		{
			get
			{
				return grade;
			}
			private set
			{
				if (value < 2f || value > 6f)
				{
					throw new ArgumentException();
				}
				this.grade = value;
			}
		}
		public string GradeWithWords
		{
			get
			{
				switch ((int)Math.Round(this.Grade))
				{
					case 2: return "Poor";
					case 3: return "Satisfactory";
					case 4: return "Good";
					case 5: return "Very Good";
					case 6: return "Excellent";
					default: throw new Exception();
				}
			}
		}
	}
}