namespace SchoolSystem.Contracts
{
	using System.Collections.Generic;

	public interface ICourse
	{
		string Name { get; }
		ICollection<IStudent> Students { get; }

		void AddStudent(IStudent student);
		void RemoveStudent(IStudent student);
	}
}
