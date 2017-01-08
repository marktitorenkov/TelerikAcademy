namespace AnimalHierarchy.Models
{
	using System;

	public abstract class Animal: ISound
	{
		public Animal(string name, int age, Sex sex)
		{
			this.Name = name;
			this.Age = age;
			this.Sex = sex;
		}

		public string Name { get; }
		public int Age { get; }
		public Sex Sex { get; }

		public abstract void ProduceSound();
	}
}