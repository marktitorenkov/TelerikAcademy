namespace AnimalHierarchy.Models
{
	using System;
	using Interfaces;

	public class Cat: Animal, IAnimal, ISound
	{
		public Cat(string name, int age, Sex sex)
			: base(name, age, sex)
		{
		}

		public override void ProduceSound()
		{
			Console.WriteLine($"{this.Name} the cat says: Meeow");
		}
	}
}