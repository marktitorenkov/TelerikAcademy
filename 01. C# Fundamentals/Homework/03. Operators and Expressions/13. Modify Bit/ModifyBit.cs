using System;

class ModifyBit
{
	static void Main()
	{
		ulong n = ulong.Parse(Console.ReadLine());
		byte p = byte.Parse(Console.ReadLine());
		ulong v = ulong.Parse(Console.ReadLine());

		ulong mask = 1;
		if (v == 0)
		{
			v = ~(mask << p);
			Console.WriteLine(n & v);
		}
		else
		{
			v = (mask << p);
			Console.WriteLine(n | v);
		}
	}
}
