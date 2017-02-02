namespace SchoolClasses.Interfaces
{
	interface IDiscipline : IComentable
	{
		string Name { get; }
		int LectureCount { get; }
		int ExerciseCount { get; }
	}
}