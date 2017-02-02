namespace AnimalHierarchy.Models
{
	using System;
	using Interfaces;

	public class Dog: Animal, IAnimal, ISound
	{
		public Dog(string name, int age, Sex sex)
			: base(name, age, sex)
		{
		}

		public override void ProduceSound()
		{
			Console.WriteLine($"{this.Name} the dog says: Bark!");
		}
	}
}