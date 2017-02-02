using System;

class Program
{
	static void Main()
	{
		double a = double.Parse(Console.ReadLine());
		double b = double.Parse(Console.ReadLine());
		double c = double.Parse(Console.ReadLine());
		double p = (a + b + c) / 2.0;

		Console.WriteLine("{0:F2}", Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
	}
}