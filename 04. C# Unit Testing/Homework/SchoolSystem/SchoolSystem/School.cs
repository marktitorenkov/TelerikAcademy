namespace SchoolSystem
{
	using System;
	using System.Collections.Generic;

	public class School
	{
		public School()
		{
			this.Courses = new List<Course>();
			this.Students = new List<Student>();
		}

		public List<Course> Courses { get; }
		public List<Student> Students { get; }

		public Student CreateStudent(string firstName, string lastName)
		{
			int id = this.Students.Count + 10000;
			if (id > 99999)
			{
				throw new Exception("Students limit reached");
			}
			var student = new Student(firstName, lastName, id);
			this.Students.Add(student);
			return student;
		}

		public Course CreateCourse(string name)
		{
			var course = new Course(name);
			this.Courses.Add(course);
			return course;
		}
	}
}