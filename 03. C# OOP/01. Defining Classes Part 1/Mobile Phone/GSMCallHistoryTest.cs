using System;
using System.Collections.Generic;

public class GSMCallHistoryTest
{
	public static void Start()
	{
		const decimal PRICE_PER_MINUTE = 0.37M;
		decimal totalPrice;
		int indexOfLongestCall;

		GSM S3Neo = new GSM("Samsung", "Galaxy S3 Neo", 300, "Pesho", "Removable", 210, 9, BatteryType.LiIon, 4f, 16);
		
		S3Neo.AddCall(new Call(DateTime.Parse("01.02.2015 10:30:20"), "0881234567", 120, PRICE_PER_MINUTE));
		S3Neo.AddCall(new Call(DateTime.Parse("05.06.2016 20:30:20"), "0887654321", 360, PRICE_PER_MINUTE));
		S3Neo.AddCall(new Call(DateTime.Parse("10.5.2016 12:00:20"), "131", 240, PRICE_PER_MINUTE));
		S3Neo.AddCall(new Call(DateTime.Now, "*88", 30, PRICE_PER_MINUTE));

		Console.WriteLine(new string('-', 30));
		Console.WriteLine(S3Neo);

		totalPrice = GetTotalPrice(S3Neo.CallHistory);

		Console.WriteLine();
		Console.WriteLine("Total price before remove: {0}", totalPrice);
		Console.WriteLine();

		indexOfLongestCall = GetLongestCall(S3Neo.CallHistory);

		S3Neo.RemoveCall(indexOfLongestCall);
		Console.WriteLine("Longest call is call number {0}", indexOfLongestCall + 1);

		totalPrice = GetTotalPrice(S3Neo.CallHistory);

		Console.WriteLine();
		Console.WriteLine("Total price after remove: {0}", totalPrice);
		Console.WriteLine();

		S3Neo.ClearCallHistory();

		Console.WriteLine(new string('-', 30));
		Console.WriteLine(S3Neo);
	}
	static int GetLongestCall(List<Call> callHistory)
	{
		int indexOfLongestCall = 0;
		int longestDuration = callHistory[0].Duration;
		for (int i = 0; i < callHistory.Count; i++)
		{
			if (callHistory[i].Duration > longestDuration)
			{
				indexOfLongestCall = i;
				longestDuration = callHistory[i].Duration;
			}
		}
		return indexOfLongestCall;
	}
	static decimal GetTotalPrice(List<Call> callHistory)
	{
		decimal totalPrice = 0;
		foreach (var call in callHistory)
		{
			totalPrice += call.Cost;
		}
		return totalPrice;
	}
}