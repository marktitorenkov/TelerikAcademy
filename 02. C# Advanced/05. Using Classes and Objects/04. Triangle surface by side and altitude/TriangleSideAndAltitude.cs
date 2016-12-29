using System;

class Program
{
	static void Main()
	{
		double side = double.Parse(Console.ReadLine());
		double height = double.Parse(Console.ReadLine());

		Console.WriteLine("{0:F2}", side * height / 2.0);
	}
}