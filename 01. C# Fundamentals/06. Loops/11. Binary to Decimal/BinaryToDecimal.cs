using System;

class BinaryToDecimal
{
	static void Main()
	{
		string binary = Console.ReadLine();

		int value = 0;

		for (int i = 0; i < binary.Length; i++)
		{
			if (binary[i] == '1')
				value |= 1 << (binary.Length - i - 1);
				//value += (int)Math.Pow(2, binary.Length - i - 1);
		}
		Console.WriteLine(value);
	}
}