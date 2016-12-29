using System;

class SortThreeNumbers
{
	static void Main()
	{
		float a = float.Parse(Console.ReadLine());
		float b = float.Parse(Console.ReadLine());
		float c = float.Parse(Console.ReadLine());

		if (a >= b && a >= c)
		{
			if (b > c)
			{
				Console.WriteLine("{0} {1} {2}", a, b, c);
			}
			else
				Console.WriteLine("{0} {1} {2}", a, c, b);
		}
		if (b > a && b > c)
		{
			if (a > c)
			{
				Console.WriteLine("{0} {1} {2}", b, a, c);
			}
			else
			{
				Console.WriteLine("{0} {1} {2}", b, c, a);
			}
		}
		if (c > a && c > b)
		{
			if (a > b)
			{
				Console.WriteLine("{0} {1} {2}", c, a, b);
			}
			else
			{
				Console.WriteLine("{0} {1} {2}", c, b, a);
			}
		}
	}
}