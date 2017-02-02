namespace Shapes
{
	using System;
	using Models;

	class Startup
	{
		static void Main()
		{
			double w = 10d, h = 20d;

			var t = new Triangle(w, h);
			Console.WriteLine($"Triangle with width {w} and height {h}");
			Console.WriteLine($"Triangle surface: {t.CalculateSurface()}");

			var s = new Square(w);
			Console.WriteLine($"\nSquare with side {w}");
			Console.WriteLine($"Square surface: {s.CalculateSurface()}");
		}
	}
}