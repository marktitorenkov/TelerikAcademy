using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
	public static void Main()
	{
		var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
		Console.WriteLine(substr);

		var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
		Console.WriteLine(String.Join(" ", subarr));

		var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
		Console.WriteLine(String.Join(" ", allarr));

		var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
		Console.WriteLine(String.Join(" ", emptyarr));

		Console.WriteLine(ExtractEnding("I love C#", 2));
		Console.WriteLine(ExtractEnding("Nakov", 4));
		Console.WriteLine(ExtractEnding("beer", 4));
		// Console.WriteLine(ExtractEnding("Hi", 100)); Invalid

		var testArr = new int[] { 23, 33 };
		foreach (var num in testArr)
		{
			if (CheckPrime(num))
			{
				Console.WriteLine($"{num} is prime.");
			}
			else
			{
				Console.WriteLine($"{num} is not prime.");
			}
		}

		List<Exam> peterExams = new List<Exam>()
		{
			new SimpleMathExam(2),
			new CSharpExam(55),
			new CSharpExam(100),
			new SimpleMathExam(1),
			new CSharpExam(0),
		};
		Student peter = new Student("Peter", "Petrov", peterExams);
		double peterAverageResult = peter.CalcAverageExamResultInPercents();
		Console.WriteLine("Average results = {0:p0}", peterAverageResult);
	}

	public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
	{
		if (arr == null)
		{
			throw new ArgumentNullException("Subsequence array cannot be null.");
		}

		if (startIndex < 0)
		{
			throw new ArgumentNullException("Subsequence startIndex cannot be less than 0.");
		}

		if (startIndex > arr.Length)
		{
			throw new ArgumentNullException("Subsequence startIndex must be less than the array length.");
		}

		if (count > arr.Length || count + startIndex > arr.Length)
		{
			throw new ArgumentException("The sum of startIndex and count cannot exceed the array length.");
		}

		List<T> result = new List<T>();
		for (int i = startIndex; i < startIndex + count; i++)
		{
			result.Add(arr[i]);
		}

		return result.ToArray();
	}

	public static string ExtractEnding(string str, int count)
	{
		if (string.IsNullOrEmpty(str))
		{
			throw new ArgumentNullException("The given string is either empty or null.");
		}

		if (count < 0 || count > str.Length)
		{
			throw new ArgumentOutOfRangeException("Count must be between 0 and the string length.");
		}

		StringBuilder result = new StringBuilder();
		for (int i = str.Length - count; i < str.Length; i++)
		{
			result.Append(str[i]);
		}

		return result.ToString();
	}

	public static bool CheckPrime(int number)
	{
		if (number < 1)
		{
			throw new ArgumentOutOfRangeException("The number must be equal or bigger than 1.");
		}

		for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
		{
			if (number % divisor == 0)
			{
				return false;
			}
		}

		return true;
	}
}
