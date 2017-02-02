using System;

class Calculate
{
	static void Main()
	{
		byte n = byte.Parse(Console.ReadLine());
		double x = double.Parse(Console.ReadLine());

		double S = 1;

		long fact = 1;
		for (int i = 1; i <= n; i++)
		{
			fact *= i;
			S += fact / Math.Pow(x, i);
		}
		Console.WriteLine("{0:F5}", S);
	}
}