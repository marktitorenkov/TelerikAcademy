namespace Dealership.Models
{
	using Common;
	using Common.Enums;
	using Contracts;

	public class Motorcycle: Vehicle, IVehicle, IMotorcycle, ICommentable, IPriceable
	{
		private const int WheelsCount = 2;

		private string category;

		public Motorcycle(string make, string model, decimal price, string category)
			: base(WheelsCount, VehicleType.Motorcycle, make, model, price)
		{
			this.Category = category;
		}

		public string Category
		{
			get { return this.category; }
			private set
			{
				Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength,
					string.Format(Constants.StringMustBeBetweenMinAndMax, "Category", Constants.MinCategoryLength, Constants.MaxCategoryLength));
				this.category = value;
			}
		}

		public override string ToString()
		{
			return base.ToString() + $"\n  Category: {this.Category}";
		}
	}
}