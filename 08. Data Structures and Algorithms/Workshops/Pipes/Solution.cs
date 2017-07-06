using System;

namespace Pipes
{
	class Program
	{
		static void Main()
		{
			int pipesCount = int.Parse(Console.ReadLine());
			int peopleCount = int.Parse(Console.ReadLine());

			int maxPipeSize = 0;
			int[] pipeSizes = new int[pipesCount];
			for (int i = 0; i < pipesCount; i++)
			{
				int size = int.Parse(Console.ReadLine());
				pipeSizes[i] = size;
				if (size > maxPipeSize)
				{
					maxPipeSize = size;
				}
			}

			int result = FindBestSize(1, maxPipeSize + 1, pipeSizes, peopleCount);
			Console.WriteLine(result);
		}

		static bool CheckSize(int size, int[] pipeSizes, int peopleCount)
		{
			int pipeCount = 0;
			foreach (int pipeSize in pipeSizes)
			{
				pipeCount += pipeSize / size;
			}

			return pipeCount >= peopleCount;
		}

		static int FindBestSize(int left, int right,
			int[] pipeSizes, int peopleCount)
		{
			while (left < right)
			{
				int mid = (left + right) / 2;

				if (CheckSize(mid, pipeSizes, peopleCount))
				{
					left = mid + 1;
				}
				else
				{
					right = mid;
				}
			}

			return left - 1;
		}
	}
}