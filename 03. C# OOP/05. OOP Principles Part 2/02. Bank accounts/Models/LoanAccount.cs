namespace BankAccounts.Models
{
	using Contracts;

	public class LoanAccount: Account, IAccount
	{
		public LoanAccount(Customer customer, decimal balance, decimal interestRate)
			: base(customer, balance, interestRate)
		{
		}

		public override decimal CalculateInterestAmount(int numberOfMonths)
		{
			if (this.Customer.Type == CustomerType.Individual)
			{
				numberOfMonths -= 3;
			}
			else if (this.Customer.Type == CustomerType.Company)
			{
				numberOfMonths -= 2;
			}
			numberOfMonths = numberOfMonths < 0 ? 0 : numberOfMonths;
			return base.CalculateInterestAmount(numberOfMonths);
		}
	}
}