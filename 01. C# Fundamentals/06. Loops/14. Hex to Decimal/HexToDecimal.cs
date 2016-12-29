using System;

class HexToDecimal
{
	static void Main()
	{
		string hex = Console.ReadLine();

		long value = 0;

		for (int i = 0; i < hex.Length; i++)
		{
			if (hex[i] >= '0' && hex[i] <= '9')
				value += (hex[i] - '0') * (long)Math.Pow(16, hex.Length - i - 1);
			else
				value += (hex[i] - 'A' + 10) * (long)Math.Pow(16, hex.Length - i - 1);
		}
		Console.WriteLine(value);
	}
}