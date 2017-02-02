public class Battery
{
	public Battery(string model, int? hoursIdle = null, int? hoursTalk = null, BatteryType? batteryType = null)
	{
		Model = model;
		HoursIdle = hoursIdle;
		HoursTalk = hoursTalk;
		Type = batteryType;
	}

	public string Model { get; private set; }
	public int? HoursIdle { get; private set; }
	public int? HoursTalk { get; private set; }
	public BatteryType? Type { get; private set; }
}

public enum BatteryType
{
	LiIon, NiMH, NiCd
}