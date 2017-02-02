using System;

class DecimalToBinary
{
	static void Main()
	{
		long num = long.Parse(Console.ReadLine());

		string binary = string.Empty;

		while (num > 0)
		{
			binary = (num % 2).ToString() + binary;
			num /= 2;
		}
		Console.WriteLine(binary);
	}
}