using System;

class OddAndEvenProduct
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		string[] numbersString = Console.ReadLine().Split(' ');

		long oddproduct = 1;
		long evenproduct = 1;

		for (int i = 1; i <= n; i++)
		{
			long num = long.Parse(numbersString[i - 1]);
			if (i % 2 == 0)
				evenproduct *= num;
			else
				oddproduct *= num;
		}

		if (evenproduct == oddproduct)
			Console.WriteLine("yes {0}", oddproduct);
		else
			Console.WriteLine("no {0} {1}", oddproduct, evenproduct);
	}
}