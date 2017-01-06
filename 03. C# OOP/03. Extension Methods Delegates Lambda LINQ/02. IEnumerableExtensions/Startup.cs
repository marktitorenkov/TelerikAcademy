namespace IEnumerableExtensions
{
	using System;
	using System.Collections.Generic;

	class Startup
	{
		static void Main()
		{
			var test = new List<int>() { 1, 2, 3, 4, 5 };

			Console.WriteLine("Collection: {0}", test.ToStringCustom());
			Console.WriteLine("Sum: {0}", test.Sum());
			Console.WriteLine("Product: {0}", test.Product());
			Console.WriteLine("Min: {0}", test.Min());
			Console.WriteLine("Max: {0}", test.Max());
			Console.WriteLine("Average: {0}", test.Average());
		}
	}
}