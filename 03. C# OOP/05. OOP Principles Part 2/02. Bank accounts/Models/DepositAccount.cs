namespace BankAccounts.Models
{
	using Contracts;

	public class DepositAccount: Account, IAccount, IWithdrawable
	{
		public DepositAccount(Customer customer, decimal balance, decimal interestRate)
			: base(customer, balance, interestRate)
		{
		}

		public void Withdraw(decimal amount)
		{
			this.Balance -= amount;
		}

		public override decimal CalculateInterestAmount(int numberOfMonths)
		{
			if (this.Balance > 0 && this.Balance < 1000)
			{
				return 0M;
			}
			return base.CalculateInterestAmount(numberOfMonths);
		}
	}
}