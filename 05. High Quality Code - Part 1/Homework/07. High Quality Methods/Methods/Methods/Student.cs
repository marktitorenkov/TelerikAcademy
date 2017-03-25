using System;

namespace Methods
{
	public class Student
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string OtherInfo { get; set; }

		public bool IsOlderThan(Student other)
		{
			int numberOfCharsFromTheEnd = 10;

			var thisDate = DateTime.Parse(
				this.OtherInfo.Substring(this.OtherInfo.Length - numberOfCharsFromTheEnd));
			var otherDate = DateTime.Parse(
				other.OtherInfo.Substring(other.OtherInfo.Length - numberOfCharsFromTheEnd));

			return thisDate > otherDate;
		}
	}
}
