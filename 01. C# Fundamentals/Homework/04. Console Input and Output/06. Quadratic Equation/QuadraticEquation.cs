using System;

class Program
{
	static void Main()
	{
		double a = double.Parse(Console.ReadLine());
		double b = double.Parse(Console.ReadLine());
		double c = double.Parse(Console.ReadLine());

		double D = b * b - 4 * a * c;

		if (D > 0)
		{
			double x1 = (-b + Math.Sqrt(D)) / (2 * a);
			double x2 = (-b - Math.Sqrt(D)) / (2 * a);

			Console.WriteLine("{0:F2}", Math.Min(x1, x2));
			Console.WriteLine("{0:F2}", Math.Max(x1, x2));
		}
		else if (D == 0)
		{
			Console.WriteLine("{0:F2}", -b / (2 * a));
		}
		else
		{
			Console.WriteLine("no real roots");
		}

	}
}
