namespace Dealership.Models
{
	using System.Collections.Generic;
	using System.Text;
	using Common;
	using Common.Enums;
	using Contracts;

	public abstract class Vehicle: IVehicle, ICommentable, IPriceable
	{
		private int wheels;
		private string make;
		private string model;
		private decimal price;

		protected Vehicle(int wheels, VehicleType type, string make, string model, decimal price)
		{
			this.Wheels = wheels;
			this.Type = type;
			this.Make = make;
			this.Model = model;
			this.Price = price;
			this.Comments = new List<IComment>();
		}

		public int Wheels
		{
			get { return this.wheels; }
			private set
			{
				Validator.ValidateIntRange(value, Constants.MinWheels, Constants.MaxWheels,
					string.Format(Constants.NumberMustBeBetweenMinAndMax, "Wheels", Constants.MinWheels, Constants.MaxWheels));
				this.wheels = value;
			}
		}

		public VehicleType Type { get; }

		public string Make
		{
			get { return this.make; }
			private set
			{
				Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength,
					string.Format(Constants.StringMustBeBetweenMinAndMax, "Make", Constants.MinMakeLength, Constants.MaxMakeLength));
				this.make = value;
			}
		}

		public string Model
		{
			get { return this.model; }
			private set
			{
				Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength,
					string.Format(Constants.StringMustBeBetweenMinAndMax, "Model", Constants.MinModelLength, Constants.MaxModelLength));
				this.model = value;
			}
		}

		public decimal Price
		{
			get { return this.price; }
			private set
			{
				Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice,
					string.Format(Constants.NumberMustBeBetweenMinAndMax, "Price", Constants.MinPrice, Constants.MaxPrice));
				this.price = value;
			}
		}

		public IList<IComment> Comments { get; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append($"{this.Type}:");
			sb.Append($"\n  Make: {this.Make}");
			sb.Append($"\n  Model: {this.Model}");
			sb.Append($"\n  Wheels: {this.Wheels}");
			sb.Append($"\n  Price: ${this.Price}");
			return sb.ToString();
		}
	}
}