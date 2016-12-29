using System;

class DecimalToHex
{
	static void Main()
	{
		long num = long.Parse(Console.ReadLine());

		string hex = string.Empty;

		while (num > 0)
		{
			long remainder = num % 16;

			if (remainder < 10)
				hex = (char)('0' + remainder) + hex;
			else
				hex = (char)('A' + remainder - 10) + hex;

			num /= 16;
		}
		Console.WriteLine(hex);
	}
}