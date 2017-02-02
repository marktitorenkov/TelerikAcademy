using System;

class MoonGravity
{
	static void Main()
	{
		float weight = float.Parse(Console.ReadLine());

		Console.WriteLine("{0:F3}", (weight * 17) / 100);
	}
}
