using System;

class GCD
{
	static void Main()
	{
		string[] input = Console.ReadLine().Split(' ');
		int a = int.Parse(input[0]);
		int b = int.Parse(input[1]);

		while (a != b)
		{
			if (a > b)
				a = a - b;
			if (b > a)
				b = b - a;
		}
		Console.WriteLine(a);
	}
}