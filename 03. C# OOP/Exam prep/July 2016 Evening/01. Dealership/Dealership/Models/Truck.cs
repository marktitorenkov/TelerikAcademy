namespace Dealership.Models
{
	using Contracts;
	using Common.Enums;
	using Common;

	public class Truck: Vehicle, IVehicle, ITruck, ICommentable, IPriceable
	{
		private const int WheelsCount = 8;

		private int weightCapacity;

		public Truck(string make, string model, decimal price, int weightCapacity)
			: base(WheelsCount, VehicleType.Truck, make, model, price)
		{
			this.WeightCapacity = weightCapacity;
		}

		public int WeightCapacity
		{
			get { return weightCapacity; }
			private set
			{
				Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity,
					string.Format(Constants.NumberMustBeBetweenMinAndMax, "Weight capacity", Constants.MinCapacity, Constants.MaxCapacity));
				this.weightCapacity = value;
			}
		}

		public override string ToString()
		{
			return base.ToString() + $"\n  Weight Capacity: {this.WeightCapacity}t";
		}
	}
}