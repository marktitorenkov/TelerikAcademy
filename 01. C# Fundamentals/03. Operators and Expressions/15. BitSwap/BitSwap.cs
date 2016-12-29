using System;

class BitExchange
{
	static void Main()
	{
		uint num = uint.Parse(Console.ReadLine());
		int p = int.Parse(Console.ReadLine());
		int q = int.Parse(Console.ReadLine());
		int k = int.Parse(Console.ReadLine());

		uint mask = (1u << k) - 1;
		
		// store original values
		uint pbits = num & (mask << p);
		uint qbits = num & (mask << q);

		// clear old values
		num = num & ~(mask << p | mask << q);

		// replace
		num = num | (pbits << (q - p) | qbits >> (q - p));

		Console.WriteLine(num);
	}
}