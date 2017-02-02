using System;

class Program
{
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
		long num = long.Parse(Console.ReadLine());

		Console.WriteLine(DecimalToHexadecimal(num));
	}
}