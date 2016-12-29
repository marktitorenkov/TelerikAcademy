using System;

class ThirdBit
{
	static void Main()
	{
		uint n = uint.Parse(Console.ReadLine());
		byte mask = 1;
		n = n >> 3;

		Console.WriteLine(n & mask);
	}
}
