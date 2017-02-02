namespace Timer
{
	using System;
	using System.Threading;

	class Timer
	{
		public Timer(Action action, int period)
		{
			while (true)
			{
				action();
				Thread.Sleep(period);
			}
		}
	}
}