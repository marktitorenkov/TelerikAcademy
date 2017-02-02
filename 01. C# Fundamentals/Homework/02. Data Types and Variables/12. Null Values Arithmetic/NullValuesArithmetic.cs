using System;

class NullValuesArithmetic
{
	static void Main()
	{
		int? a = 1;
		int? b = null;

		Console.WriteLine(a);
		Console.WriteLine(b);

		Console.WriteLine(a + 1);
		Console.WriteLine(b + 1);
	}
}