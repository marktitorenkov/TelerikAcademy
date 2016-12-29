using System;

class SumOfNNumbers
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		double sum = 0;
		for (int i = 0; i < N; i++)
		{
			sum += double.Parse(Console.ReadLine());
		}

		Console.WriteLine(sum);
	}
}
