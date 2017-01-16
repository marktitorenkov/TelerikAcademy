namespace Academy.Models
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Contracts;

	public class Course: ICourse
	{
		private string name;
		private int lecturesPerWeek;

		public Course(string name, int lecturesPerWeek, DateTime startingDate)
		{
			this.Name = name;
			this.LecturesPerWeek = lecturesPerWeek;
			this.StartingDate = startingDate;
			this.EndingDate = startingDate.AddDays(30);
			this.OnsiteStudents = new List<IStudent>();
			this.OnlineStudents = new List<IStudent>();
			this.Lectures = new List<ILecture>();
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				if (value.Length < 3 || value.Length > 45)
				{
					throw new ArgumentException("The name of the course must be between 3 and 45 symbols!");
				}
				this.name = value;
			}
		}

		public int LecturesPerWeek
		{
			get { return this.lecturesPerWeek; }
			set
			{
				if (value < 1 || value > 7)
				{
					throw new ArgumentException("The number of lectures per week must be between 1 and 7!");
				}
				this.lecturesPerWeek = value;
			}
		}

		public DateTime StartingDate { get; set; }

		public DateTime EndingDate { get; set; }

		public IList<IStudent> OnsiteStudents { get; }

		public IList<IStudent> OnlineStudents { get; }

		public IList<ILecture> Lectures { get; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("* Course:");
			sb.AppendLine($" - Name: {this.Name}");
			sb.AppendLine($" - Lectures per week: {this.LecturesPerWeek}");
			sb.AppendLine($" - Starting date: {this.StartingDate}");
			sb.AppendLine($" - Ending date: {this.EndingDate}");
			sb.AppendLine($" - Onsite students: {this.OnsiteStudents.Count}");
			sb.AppendLine($" - Online students: {this.OnlineStudents.Count}");
			sb.AppendLine($" - Lectures:");
			if (this.Lectures.Count == 0)
			{
				sb.AppendLine("  * There are no lectures in this course!");
			}
			else
			{
				foreach (var lecture in this.Lectures)
				{
					sb.Append(lecture.ToString());
				}
			}
			return sb.ToString();
		}
	}
}