using System;

class Program
{
	static string DecimalToBinary(long num)
	{
		string binary = string.Empty;

		do
		{
			binary = num % 2 + binary;
			num /= 2;
		} while (num > 0);

		return binary;
	}

	static void Main()
	{
		long num = long.Parse(Console.ReadLine());

		Console.WriteLine(DecimalToBinary(num));
	}
}