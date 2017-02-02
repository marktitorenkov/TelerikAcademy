using System;
using System.Numerics;

class CalculateAgain
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		int K = int.Parse(Console.ReadLine());

		BigInteger factN = 1;
		BigInteger factK = 1;
		for (int i = 2; i <= N; i++)
		{
			factN *= i;
			if (i == K)
				factK = factN;
		}
		Console.WriteLine(factN / factK);
	}
}