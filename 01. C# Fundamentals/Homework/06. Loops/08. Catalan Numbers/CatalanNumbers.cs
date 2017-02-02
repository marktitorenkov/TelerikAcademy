using System;
using System.Numerics;

class CatalanNumbers
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		BigInteger factN = 1;
		BigInteger fact2N = 1;
		BigInteger factNplus1 = 1;
		for (int i = 2; i <= (2 * N); i++)
		{
			fact2N *= i;
			if (i == N)
				factN = fact2N;
			else if (i == N + 1)
				factNplus1 = fact2N;
		}
		Console.WriteLine(fact2N / (factNplus1 * factN));
	}
}