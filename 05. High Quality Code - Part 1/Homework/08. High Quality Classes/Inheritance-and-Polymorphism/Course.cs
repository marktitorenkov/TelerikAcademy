using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
	public class Course
	{
		public Course(string courseName, string teacherName)
		{
			this.Name = courseName;
			this.TeacherName = teacherName;
			this.Students = new List<string>();
		}

		public string Name { get; }

		public string TeacherName { get; }

		// List beacuse IList does't have AddRange method
		public List<string> Students { get; }

		private string GetStudentsAsString()
		{
			return "{ " + string.Join(", ", this.Students) + " }";
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();
			result.Append("LocalCourse { Name = ");
			result.Append(this.Name);
			if (this.TeacherName != null)
			{
				result.Append("; Teacher = ");
				result.Append(this.TeacherName);
			}
			result.Append("; Students = ");
			result.Append(this.GetStudentsAsString());
			return result.ToString();
		}
	}
}
