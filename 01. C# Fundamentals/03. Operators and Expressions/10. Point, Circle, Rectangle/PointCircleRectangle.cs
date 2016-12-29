using System;

class PointCircleRectangle
{
	static void Main()
	{
		double x = double.Parse(Console.ReadLine());
		double y = double.Parse(Console.ReadLine());

		if (Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1)) <= 1.5)
			Console.Write("inside circle");
		else
			Console.Write("outside circle");

		Console.Write(" ");

		if (x >= -1 && x <= 5 && y >= -1 && y <= 1)
			Console.Write("inside rectangle");
		else
			Console.Write("outside rectangle");
	}
}