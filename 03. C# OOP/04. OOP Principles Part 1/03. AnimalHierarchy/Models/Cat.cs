namespace AnimalHierarchy.Models
{
	using System;

	public class Cat: Animal, ISound
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