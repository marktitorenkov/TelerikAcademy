namespace BankAccounts.Contracts
{
	using Models;

	interface ICustomer
	{
		string Name { get; }
		CustomerType Type { get; }
	}
}