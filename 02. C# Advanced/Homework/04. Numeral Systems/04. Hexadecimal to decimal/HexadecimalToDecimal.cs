using System;

class Program
{
	static long HexadecimalToDecimal(string hex)
	{
		long num = 0;

		foreach (char hexvalue in hex)
		{
			int value;
			if (char.IsDigit(hexvalue))
				value = hexvalue - '0';
			else
				value = hexvalue - 'A' + 10;

			num = num * 16 + value;
		}

		return num;
	}

	static void Main()
	{
		string hex = Console.ReadLine();

		Console.WriteLine(HexadecimalToDecimal(hex));
	}
}