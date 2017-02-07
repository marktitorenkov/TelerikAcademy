namespace SchoolSystem
{
	using System;
	using System.Collections.Generic;

	public class Course
	{
		public Course(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("Name cannot be null");
			}
			if (name.Trim() == string.Empty)
			{
				throw new ArgumentException("Name cannot be empty");
			}
			this.Name = name;
			this.Students = new List<Student>();
		}

		public string Name { get; }
		public List<Student> Students { get; }

		public void AddStudent(Student student)
		{
			if (student == null)
			{
				throw new ArgumentNullException();
			}
			if (this.Students.Count == 30)
			{
				throw new Exception("Course limit reached");
			}
			this.Students.Add(student);
		}

		public void RemoveStudent(Student student)
		{
			if (student == null)
			{
				throw new ArgumentNullException();
			}
			if (!this.Students.Remove(student))
			{
				throw new Exception("Student is not in the course");
			}
		}
	}
}
