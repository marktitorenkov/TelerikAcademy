using System;

class IndexOfLetters
{
	static void Main()
	{
		string word = Console.ReadLine();

		char[] alphabet = new char[26];
		for (int i = 0; i < 26; i++)
			alphabet[i] = (char)('a' + i);

		foreach (char letter in word)
			Console.WriteLine(BinarySearch(alphabet, letter));
	}

	static int BinarySearch(char[] arr, char x)
	{
		int n = arr.Length;
		int l = 0;
		int r = n - 1;

		while (l <= r)
		{
			int m = (l + r) / 2;
			if (x > arr[m])
				l = m + 1;
			else if (x < arr[m])
				r = m - 1;
			else if (x == arr[m])
				return m;
		}
		return -1;
	}
}