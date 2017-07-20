using System;

namespace Train_OnePassanger
{
	class Program
	{
		static void Main(string[] args)
		{
			var strs = Console.ReadLine().Split(' ');
			int passengerCount = int.Parse(strs[0]);
			int trainCapacity = int.Parse(strs[1]);
			int stopsCount = int.Parse(strs[2]);

			var passengers = new Tuple<int, int>[passengerCount];

			for (int i = 0; i < passengerCount; i++)
			{
				strs = Console.ReadLine().Split(' ');
				passengers[i] = new Tuple<int, int>
				(
					int.Parse(strs[0]),
					int.Parse(strs[1])
				);
			}

			Array.Sort(passengers, (x, y) => x.Item2.CompareTo(y.Item2));

			int count = 1;
			int currentEnd = passengers[0].Item2;
			foreach (var passenger in passengers)
			{
				if (passenger.Item1 >= currentEnd)
				{
					currentEnd = passenger.Item2;
					count++;
				}
			}

			Console.WriteLine(count);
		}
	}
}
