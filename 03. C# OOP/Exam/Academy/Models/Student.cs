namespace Academy.Models
{
	using System.Collections.Generic;
	using Utils.Contracts;
	using Contracts;
	using System.Text;

	class Student: User, IUser, IStudent
	{
		public Student(string username, Track track)
			: base(username)
		{
			this.Track = track;
			this.CourseResults = new List<ICourseResult>();
		}

		public Track Track { get; set; }

		public IList<ICourseResult> CourseResults { get; set; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("* Student:");
			sb.AppendLine($" - Username: {this.Username}");
			sb.AppendLine($" - Track: {this.Track}");
			sb.AppendLine($" - Course results:");
			if (this.CourseResults.Count == 0)
			{
				sb.AppendLine("  * User has no course results!");
			}
			else
			{
				foreach (var result in this.CourseResults)
				{
					sb.Append(result.ToString());
				}
			}
			return sb.ToString();
		}
	}
}