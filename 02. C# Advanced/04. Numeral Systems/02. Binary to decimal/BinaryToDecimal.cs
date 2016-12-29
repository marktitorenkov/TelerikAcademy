using System;

class Program
{
	static long BinaryToDecimal(string binary)
	{
		long num = 0;

		foreach (char bit in binary)
		{
			num = num * 2 + (bit - '0');
		}

		return num;
	}

	static void Main()
	{
		string binary = Console.ReadLine();

		Console.WriteLine(BinaryToDecimal(binary));
	}
}