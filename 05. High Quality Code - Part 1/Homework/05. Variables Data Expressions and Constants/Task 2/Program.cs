using System;

namespace Task1
{
	public class Program
	{
		public void PrintStatistics(double[] numbers, int count)
		{
			double max = 0;
			for (int i = 0; i < count; i++)
			{
				if (numbers[i] > max)
				{
					max = numbers[i];
				}
			}
			Console.WriteLine(max);

			double min = 0;
			for (int i = 0; i < count; i++)
			{
				if (numbers[i] < min)
				{
					min = numbers[i];
				}
			}
			Console.WriteLine(max);

			double sum = 0;
			for (int i = 0; i < count; i++)
			{
				sum += numbers[i];
			}
			Console.WriteLine(sum / count);
		}
	}
}
