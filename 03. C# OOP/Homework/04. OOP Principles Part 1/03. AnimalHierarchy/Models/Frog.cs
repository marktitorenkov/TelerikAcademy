namespace AnimalHierarchy.Models
{
	using System;
	using Interfaces;

	public class Frog: Animal, IAnimal, ISound
	{
		public Frog(string name, int age, Sex sex)
			: base(name, age, sex)
		{
		}

		public override void ProduceSound()
		{
			Console.WriteLine($"{this.Name} the frog says: Croak!");
		}
	}
}