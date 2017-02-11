namespace SchoolSystem
{
	using System;
	using System.Collections.Generic;
	using Contracts;

	public class School : ISchool
	{
		private ICollection<ICourse> courses;
		private ICollection<IStudent> students;

		public School()
		{
			this.courses = new List<ICourse>();
			this.students = new List<IStudent>();
		}

		public ICollection<ICourse> Courses
		{
			get
			{
				return new List<ICourse>(this.courses);
			}
		}
		public ICollection<IStudent> Students
		{
			get
			{
				return new List<IStudent>(this.students);
			}
		}

		public IStudent CreateStudent(string firstName, string lastName)
		{
			int id = this.students.Count + 10000;
			if (id > 99999)
			{
				throw new Exception("Students limit reached.");
			}
			var student = new Student(firstName, lastName, id);
			this.students.Add(student);
			return student;
		}

		public ICourse CreateCourse(string name)
		{
			var course = new Course(name);
			this.courses.Add(course);
			return course;
		}
	}
}