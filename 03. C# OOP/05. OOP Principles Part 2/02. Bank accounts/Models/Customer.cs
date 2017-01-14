namespace BankAccounts.Models
{
	using Contracts;

	public class Customer: ICustomer
	{
		public Customer(string name, CustomerType type)
		{
			this.Name = name;
			this.Type = type;
		}

		public string Name { get; }
		public CustomerType Type { get; }
	}
}