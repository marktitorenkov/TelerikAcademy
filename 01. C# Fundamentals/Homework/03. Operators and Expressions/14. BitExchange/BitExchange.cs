using System;

class BitExchange
{
	static void Main()
	{
		uint num = uint.Parse(Console.ReadLine());

		// 0b111 = 7
		uint mask = 7;
		
		// store original values
		uint b3 = num & (mask << 3);
		uint b24 = num & (mask << 24);

		// clear old values
		num = num & ~(mask << 3 | mask << 24);

		// replace
		num = num | (b3 << 21 | b24 >> 21);

		Console.WriteLine(num);
	}
}