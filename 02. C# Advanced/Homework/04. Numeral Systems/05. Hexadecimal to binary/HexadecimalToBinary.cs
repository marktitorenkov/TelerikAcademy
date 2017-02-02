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
		string hex = Console.ReadLine();

		string binary = DecimalToBinary(HexadecimalToDecimal(hex));

		Console.WriteLine(binary);
	}
}
