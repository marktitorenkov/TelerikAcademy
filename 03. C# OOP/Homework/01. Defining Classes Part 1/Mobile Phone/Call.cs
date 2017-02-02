using System;

public class Call
{
	public Call(DateTime time, string number, int duration, decimal pricePerMinute)
	{
		Time = time;
		Number = number;
		Duration = duration;
		Cost = (duration / 60 + 1) * pricePerMinute;
	}

	public DateTime Time { get; private set; }
	public string Number { get; private set; }
	public int Duration { get; private set; }
	public decimal Cost { get; private set; }

	public override string ToString()
	{
		return string.Format("Time: {0} Number: {1} Duration: {2}s Cost: {3:F2} BGN", Time, Number, Duration, Cost);
	}
}