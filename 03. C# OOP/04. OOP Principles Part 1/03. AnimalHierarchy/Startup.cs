namespace AnimalHierarchy
{
	using System;
	using System.Linq;
	using Models;

	class Startup
	{
		static void Main()
		{
			#region Samples
			var cats = new Cat[]
			{
				new Cat("Meredith Grey", 6, Sex.Female),
				new Cat("Olivia Benson", 7, Sex.Female),
				new Cat("Lilo", 8, Sex.Male),
				new Cat("Bernie", 7, Sex.Male)
			};
			var kittens = new Kitten[]
			{
				new Kitten("Pixie", 4),
				new Kitten("Sierra", 7),
				new Kitten("Isabelle", 4),
				new Kitten("Pickle", 5)
			};
			var tomcats = new Tomcat[]
			{
				new Tomcat("Thomas", 8),
				new Tomcat("Yogurt", 9),
				new Tomcat("Wrinkle", 6),
				new Tomcat("Azure", 5)
			};
			var dogs = new Dog[]
			{
				new Dog("Lucky", 7, Sex.Female),
				new Dog("Zeus", 8, Sex.Male),
				new Dog("Robbie", 2, Sex.Male),
				new Dog("Sportaflop", 5, Sex.Male)
			};
			var forgs = new Frog[]
			{
				new Frog("Trevor", 1, Sex.Male),
				new Frog("Jabba the Hutt", 100, Sex.Female)
			};
			#endregion;


		}
	}
}