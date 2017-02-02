using System;

class Program
{
	static void Main()
	{
		double a = double.Parse(Console.ReadLine());
		double b = double.Parse(Console.ReadLine());
		double degrees = double.Parse(Console.ReadLine());

		Console.WriteLine("{0:F2}", a * b * Math.Sin(degrees * Math.PI / 180) / 2.0);
	}
}