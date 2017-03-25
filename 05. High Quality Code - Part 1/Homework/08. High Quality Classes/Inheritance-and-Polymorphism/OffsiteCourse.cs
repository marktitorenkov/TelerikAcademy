using System.Text;

namespace InheritanceAndPolymorphism
{
	public class OffsiteCourse: Course
	{
		public OffsiteCourse(string courseName, string teacherName, string town)
			:base(courseName, teacherName)
		{
			this.Town = town;
		}

		public string Town { get; set; }

		public override string ToString()
		{
			var result = new StringBuilder();
			result.Append(base.ToString());
			result.Append("; Town = ");
			result.Append(this.Town);
			result.Append(" }");
			return result.ToString();
		}
	}
}
