namespace SchoolSystem
{
	using System;
	using System.Collections.Generic;
	using Contracts;

	public class Course : ICourse
	{
		private ICollection<IStudent> students;

		public Course(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Name cannot be empty.");
			}
			this.Name = name;
			this.students = new List<IStudent>();
		}

		public string Name { get; }
		public ICollection<IStudent> Students
		{
			get
			{
				return new List<IStudent>(this.students);
			}
		}

		public void AddStudent(IStudent student)
		{
			if (student == null)
			{
				throw new ArgumentNullException();
			}
			if (this.students.Count == 30)
			{
				throw new Exception("Course limit reached.");
			}
			this.students.Add(student);
		}

		public void RemoveStudent(IStudent student)
		{
			if (student == null)
			{
				throw new ArgumentNullException();
			}
			if (!this.students.Remove(student))
			{
				throw new Exception("Student is not in the course.");
			}
		}
	}
}
