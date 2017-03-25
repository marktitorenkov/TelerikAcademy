using System.Text;
using InheritanceAndPolymorphism.Common;

namespace InheritanceAndPolymorphism
{
	public class LocalCourse : Course
	{
		private const Lab DefaultLab = Lab.Ultimate;

		public LocalCourse(string courseName, string teacherName, Lab lab)
			:base(courseName, teacherName)
		{
			this.Lab = lab;
		}

		public LocalCourse(string courseName, string teacherName)
			:this(courseName, teacherName, DefaultLab)
		{
		}

		public Lab Lab { get; set; }

		public override string ToString()
		{
			var result = new StringBuilder();
			result.Append(base.ToString());
			result.Append("; Lab = ");
			result.Append(this.Lab.ToString());
			result.Append(" }");
			return result.ToString();
		}
	}
}
