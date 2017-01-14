namespace Dealership.Models
{
	using Common;
	using Common.Enums;
	using Contracts;

	public class Car: Vehicle, IVehicle, ICar, ICommentable, IPriceable
	{
		private const int WheelsCount = 4;

		private int seats;

		public Car(string make, string model, decimal price, int seats)
			: base(WheelsCount, VehicleType.Car, make, model, price)
		{
			this.Seats = seats;
		}

		public int Seats
		{
			get { return this.seats; }
			private set
			{
				Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats,
					string.Format(Constants.NumberMustBeBetweenMinAndMax, "Seats", Constants.MinSeats, Constants.MaxSeats));
				this.seats = value;
			}
		}

		public override string ToString()
		{
			return base.ToString() + $"\n  Seats: {this.Seats}";
		}
	}
}