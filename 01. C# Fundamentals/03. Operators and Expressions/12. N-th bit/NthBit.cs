using System;

class NthBit
{
	static void Main()
	{
		ulong p = ulong.Parse(Console.ReadLine());
		byte n = byte.Parse(Console.ReadLine());
		byte mask = 1;
		p = p >> n;

		Console.WriteLine(p & mask);
	}
}
