namespace AnimalHierarchy.Models
{
	using System;
	using Interfaces;

	public class Tomcat: Cat, ISound
	{
		public Tomcat(string name, int age)
			: base(name, age, Sex.Male)
		{
		}

		public override void ProduceSound()
		{
			Console.WriteLine($"{this.Name} the tomcat says: Purrr");
		}
	}
}