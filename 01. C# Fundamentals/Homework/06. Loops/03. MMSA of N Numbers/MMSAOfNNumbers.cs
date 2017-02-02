using System;

class MMSAOfNNumbers
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		double min = double.MaxValue;
		double max = double.MinValue;
		double sum = 0;

		for (int i = 0; i < N; i++)
		{
			double num = double.Parse(Console.ReadLine());

			sum += num;
			if (num < min)
				min = num;
			if (num > max)
				max = num;
		}

		Console.WriteLine("min={0:F2}", min);
		Console.WriteLine("max={0:F2}", max);
		Console.WriteLine("sum={0:F2}", sum);
		Console.WriteLine("avg={0:F2}", sum / N);
	}
}