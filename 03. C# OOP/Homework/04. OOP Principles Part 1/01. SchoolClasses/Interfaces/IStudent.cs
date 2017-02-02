namespace SchoolClasses.Interfaces
{
	interface IStudent : IComentable
	{
		string Name { get; }
		int ClassNumber { get; }
	}
}
