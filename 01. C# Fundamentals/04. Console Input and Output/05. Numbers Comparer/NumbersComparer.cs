using System;

class NumbersComparer
{
	static void Main()
	{
		double a = double.Parse(Console.ReadLine());
		double b = double.Parse(Console.ReadLine());

		Console.WriteLine(Math.Max(a, b));
	}
}
