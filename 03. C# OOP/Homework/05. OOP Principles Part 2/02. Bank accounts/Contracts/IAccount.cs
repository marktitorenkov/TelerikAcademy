namespace BankAccounts.Contracts
{
	using Models;

	public interface IAccount
	{
		Customer Customer { get; }
		decimal Balance { get; }
		decimal InterestRate { get; }

		void Deposit(decimal amount);

		decimal CalculateInterestAmount(int numberOfMonths);
	}
}