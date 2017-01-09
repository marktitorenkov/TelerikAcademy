namespace AnimalHierarchy.Interfaces
{
	using Models;

	interface IAnimal: ISound
	{
		string Name { get; }
		int Age { get; }
		Sex Sex { get; }
	}
}