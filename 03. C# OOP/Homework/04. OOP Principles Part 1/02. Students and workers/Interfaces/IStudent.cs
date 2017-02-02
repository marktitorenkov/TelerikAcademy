namespace StudentsAndWorkers.Interfaces
{
	interface IStudent: IHuman
	{
		float Grade { get; }
		string GradeWithWords { get; }
	}
}