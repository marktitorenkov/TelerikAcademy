namespace BankAccounts.Models
{
	using Contracts;

	public abstract class Account: IAccount
	{
		public Account(Customer customer, decimal balance, decimal interestRate)
		{
			this.Customer = customer;
			this.Balance = balance;
			this.InterestRate = interestRate;
		}

		public Customer Customer { get; }
		public decimal Balance { get; protected set; }
		public decimal InterestRate { get; }

		public void Deposit(decimal amount)
		{
			this.Balance += amount;
		}

		public virtual decimal CalculateInterestAmount(int numberOfMonths)
		{
			return numberOfMonths * this.InterestRate;
		}

		public override string ToString()
		{
			var str = string.Empty;
			str += new string('=', 20);
			str += $"\nAccount holder: {this.Customer.Name} ({this.Customer.Type})\nAccount type: {this.GetType().Name}\nAccount ballance: ${this.Balance}\nAccount interest rate: {this.InterestRate}%";
			return str;
		}
	}
}