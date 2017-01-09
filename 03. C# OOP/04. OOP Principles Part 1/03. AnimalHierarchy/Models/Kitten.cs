namespace AnimalHierarchy.Models
{
	using System;
	using Interfaces;

	public class Kitten: Cat, IAnimal, ISound
	{
		public Kitten(string name, int age)
			: base(name, age, Sex.Female)
		{
		}

		public override void ProduceSound()
		{
			Console.WriteLine($"{this.Name} the kitten says: Mew");
		}
	}
}