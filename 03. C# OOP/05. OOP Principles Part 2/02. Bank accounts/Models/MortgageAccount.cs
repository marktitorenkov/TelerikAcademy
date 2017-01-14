namespace BankAccounts.Models
{
	using Contracts;

	public class MortgageAccount: Account, IAccount
	{
		public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
			: base(customer, balance, interestRate)
		{
		}

		public override decimal CalculateInterestAmount(int numberOfMonths)
		{
			if (this.Customer.Type == CustomerType.Company)
			{
				if (numberOfMonths <= 12)
				{
					return (this.InterestRate * numberOfMonths) / 2;
				}
				return base.CalculateInterestAmount(numberOfMonths);
			}
			else if (this.Customer.Type == CustomerType.Individual)
			{
				if (numberOfMonths <= 6)
				{
					return 0;
				}
				return base.CalculateInterestAmount(numberOfMonths);
			}
			else
			{
				return base.CalculateInterestAmount(numberOfMonths);
			}
		}
	}
}