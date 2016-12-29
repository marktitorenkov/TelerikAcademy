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

	static string DecimalToHexadecimal(long num)
	{
		string hexvalues = "0123456789ABCDEF";
		string hex = string.Empty;

		do
		{
			hex = hexvalues[(int)(num % 16)] + hex;
			num /= 16;
		} while (num > 0);

		return hex;
	}

	static void Main()
	{
		string binary = Console.ReadLine();

		string hex = DecimalToHexadecimal(BinaryToDecimal(binary));

		Console.WriteLine(hex);
	}
}