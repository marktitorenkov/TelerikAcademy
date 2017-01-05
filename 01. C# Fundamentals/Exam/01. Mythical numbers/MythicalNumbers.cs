using System;

class MythicalNumbers
{
	static void Main()
	{
		string num = Console.ReadLine();
		int a = num[0] - '0';
		int b = num[1] - '0';
		int c = num[2] - '0';

		if (c == 0)
		{
			Console.WriteLine("{0:F2}", a * b);
		}
		else if (c > 0 && c <= 5)
		{
			Console.WriteLine("{0:F2}", (a * b) / (float)c);
		}
		else if (c > 5)
		{
			Console.WriteLine("{0:F2}", (a + b) * c);
		}
	}
}