using System;
using System.Numerics;

class CalculateThree
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		int K = int.Parse(Console.ReadLine());
		int NminusK = N - K;

		BigInteger factN = 1;
		BigInteger factK = 1;
		for (int i = 2; i <= N; i++)
		{
			factN *= i;
			if (i == K)
				factK = factN;
		}

		BigInteger factNminusK = 1;
		for (int i = 2; i <= NminusK; i++)
		{
			factNminusK *= i;
		}

		Console.WriteLine(factN / (factK * factNminusK));
	}
}