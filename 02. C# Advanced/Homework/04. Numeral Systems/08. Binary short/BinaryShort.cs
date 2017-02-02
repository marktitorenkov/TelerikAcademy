using System;

class Program
{
	static string BinaryRepresentation(short num)
	{
		string binary = string.Empty;

		for (int i = 0; i < 16; i++)
		{
			binary = ((num & (1 << i)) >> i) + binary;
		}

		return binary;
	}

	static void Main()
	{
		short number = short.Parse(Console.ReadLine());

		Console.WriteLine(BinaryRepresentation(number));
	}
}