using System.Collections.Generic;
using System.Text;

public class GSM
{
	public static GSM iPhone4s = new GSM("Apple", "iPhone 4s", 300, "Pesho", "NonRemovable", 200, 8, BatteryType.LiIon, 3.5f, 16);

	public GSM(string manufacturer, string model, decimal? price = null, string owner = null, string batteryModel = null, int? batteryHoursIdle = null, int? batteryHoursTalk = null, BatteryType? batteryType = null, float? displaySize = null, int? displayNumberOfColors = null)
	{
		Manufacturer = manufacturer;
		Model = model;
		Price = price;
		Owner = owner;
		Battery = new Battery(batteryModel, batteryHoursIdle, batteryHoursTalk);
		Display = new Display(displaySize, displayNumberOfColors);
		CallHistory = new List<Call>();
	}

	public string Manufacturer { get; private set; }
	public string Model { get; private set; }
	public decimal? Price { get; private set; }
	public string Owner { get; private set; }
	public Battery Battery { get; private set; }
	public Display Display { get; private set; }
	public List<Call> CallHistory { get; private set; }

	public void AddCall(Call call)
	{
		CallHistory.Add(call);
	}
	public void RemoveCall(int index)
	{
		CallHistory.RemoveAt(index);
	}
	public void ClearCallHistory()
	{
		CallHistory = new List<Call>();
	}

	public override string ToString()
	{
		StringBuilder callsStr = new StringBuilder();
		foreach (var call in CallHistory)
		{
			callsStr.Append("\n\t\t");
			callsStr.Append(call);
		}

		StringBuilder GSMStr = new StringBuilder();
		GSMStr.Append(string.Format("Manufacturer: {0}", Manufacturer));
		GSMStr.Append(string.Format("\nModel: {0}", Model));
		GSMStr.Append(string.Format("\nPrice: {0} BGN", Price));
		GSMStr.Append(string.Format("\nOwner: {0}", Owner));
		GSMStr.Append(string.Format("\nBattery: "));
		GSMStr.Append(string.Format("\n\tModel: {0}", Battery.Model));
		GSMStr.Append(string.Format("\n\tHoursIdle: {0}h", Battery.HoursIdle));
		GSMStr.Append(string.Format("\n\tHoursTalk: {0}h", Battery.HoursTalk));
		GSMStr.Append(string.Format("\nDisplay: "));
		GSMStr.Append(string.Format("\n\tSize: {0}\"", Display.Size));
		GSMStr.Append(string.Format("\n\tNumberOfColors: {0} million", Display.NumberOfColors));
		GSMStr.Append(string.Format("\nCall History: "));
		GSMStr.Append(string.Format(callsStr.ToString()));

		return GSMStr.ToString();
	}
}