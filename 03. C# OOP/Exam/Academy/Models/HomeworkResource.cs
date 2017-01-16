namespace Academy.Models
{
	using System;
	using Contracts;
	using Enums;

	public class HomeworkResource: LectureResource, ILectureResouce
	{
		public HomeworkResource(string name, string url, DateTime now)
			: base(name, url, ResourceType.Homework)
		{
			this.DueDate = now.AddDays(7);
		}

		public DateTime DueDate { get; }

		public override string ToString()
		{
			return base.ToString() + $"     - Due date: {this.DueDate}";
        }
	}
}