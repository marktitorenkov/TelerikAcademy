using System;

class PrimeNumbers
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine()) + 1;

		bool[] prime = new bool[n];
		for (int i = 0; i < n; i++)
			prime[i] = true;

		for (int i = 2; i < Math.Sqrt(n); i++)
		{
			if (prime[i] == true)
			{
				for (int j = i * 2; j < n; j += i)
					prime[j] = false;
			}
		}

		for (int i = n - 1; i > 1; i--)
		{
			if (prime[i] == true)
			{
				Console.WriteLine(i);
				break;
			}
		}
	}
}