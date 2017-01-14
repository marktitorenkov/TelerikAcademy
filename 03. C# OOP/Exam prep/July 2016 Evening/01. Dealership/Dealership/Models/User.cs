namespace Dealership.Models
{
	using System;
	using System.Collections.Generic;
	using Contracts;
	using Common.Enums;
	using Common;
	using System.Text;
	using System.Linq;

	class User: IUser
	{
		private string firstName;
		private string lastName;
		private string password;
		private string username;

		public User(string username, string firstName, string lastName, string password, string role)
		{
			this.Username = username;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Password = password;
			this.Role = (Role)Enum.Parse(typeof(Role), role, true);
			this.Vehicles = new List<IVehicle>();
		}

		public string FirstName
		{
			get
			{
				return firstName;
			}
			private set
			{
				Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
					string.Format(Constants.StringMustBeBetweenMinAndMax, "Firstname", Constants.MinNameLength, Constants.MaxNameLength));
				this.firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return lastName;
			}
			private set
			{
				Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
					string.Format(Constants.StringMustBeBetweenMinAndMax, "Lastname", Constants.MinNameLength, Constants.MaxNameLength));
				this.lastName = value;
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
			private set
			{
				Validator.ValidateIntRange(value.Length, Constants.MinPasswordLength, Constants.MaxPasswordLength,
					string.Format(Constants.StringMustBeBetweenMinAndMax, "Password", Constants.MinPasswordLength, Constants.MaxPasswordLength));

				Validator.ValidateSymbols(value, Constants.PasswordPattern, string.Format(Constants.InvalidSymbols, "Password"));
				this.password = value;
			}
		}

		public Role Role { get; }

		public string Username
		{
			get
			{
				return username;
			}
			private set
			{
				Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
					string.Format(Constants.StringMustBeBetweenMinAndMax, "Username", Constants.MinNameLength, Constants.MaxNameLength));

				Validator.ValidateSymbols(value, Constants.UsernamePattern, string.Format(Constants.InvalidSymbols, "Username"));
				this.username = value;
			}
		}

		public IList<IVehicle> Vehicles { get; }

		public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
		{
			vehicleToAddComment.Comments.Add(commentToAdd);
		}

		public void AddVehicle(IVehicle vehicle)
		{
			if (this.Role == Role.Admin)
			{
				throw new ArgumentException(Constants.AdminCannotAddVehicles);
			}
			else if (this.Role != Role.VIP && this.Vehicles.Count >= 5)
			{
				throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd, Constants.MaxVehiclesToAdd));
			}
			else
			{
				this.Vehicles.Add(vehicle);
			}
		}

		public string PrintVehicles()
		{
			var sb = new StringBuilder();
			sb.Append($"--USER {this.Username}--");
			if (this.Vehicles.Count != 0)
			{
				for (int i = 0; i < this.Vehicles.Count; i++)
				{
					var v = this.Vehicles[i];
					sb.Append("\n" + (i + 1) + ". " + v.ToString());
					if (v.Comments.Count == 0)
					{
						sb.Append("\n    --NO COMMENTS--");
					}
					else
					{
						sb.Append("\n    --COMMENTS--");
						foreach (var c in v.Comments)
						{
							sb.Append(c);
						}
						sb.Append("\n    --COMMENTS--");
					}
				}
			}
			else
			{
				sb.Append("\n--NO VEHICLES--");
			}
			return sb.ToString();
		}

		public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
		{
			if (commentToRemove.Author == this.Username)
			{
				vehicleToRemoveComment.Comments.Remove(commentToRemove);
			}
			else
			{
				throw new ArgumentException(Constants.YouAreNotTheAuthor);
			}
		}

		public void RemoveVehicle(IVehicle vehicle)
		{
			this.Vehicles.Remove(vehicle);
		}

		public override string ToString()
		{
			return $"Username: {this.Username}, FullName: {this.FirstName} {this.LastName}, Role: {this.Role}";
		}
	}
}