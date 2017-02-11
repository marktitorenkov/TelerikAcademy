namespace SchoolSystem.Contracts
{
	using System.Collections.Generic;

	public interface ISchool
	{
		ICollection<ICourse> Courses { get; }
		ICollection<IStudent> Students { get; }

		IStudent CreateStudent(string firstName, string lastName);
		ICourse CreateCourse(string name);
	}
}
