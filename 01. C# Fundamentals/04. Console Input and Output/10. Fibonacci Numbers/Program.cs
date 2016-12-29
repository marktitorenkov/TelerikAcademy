using System;

class Program
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		ulong a = 0;
		ulong b = 1;
		ulong c;

		for (int i = 1; i <= n; i++)
		{
			if (i == 1)
			{
				Console.Write(a);
			}
			else if (i == 2)
			{
				Console.Write(b);
			}
			else
			{
				c = a + b;
				a = b;
				b = c;
				Console.Write(c);
			}
			if (i != n)
				Console.Write(", ");
		}
		Console.WriteLine();
	}
}
