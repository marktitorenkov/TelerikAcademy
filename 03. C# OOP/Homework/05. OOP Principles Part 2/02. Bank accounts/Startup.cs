namespace BankAccounts
{
	using System;
	using Models;

	class Startup
	{
		static void Main()
		{
			var accounts = new Account[]
			{
				new MortgageAccount(new Customer("Peshio Petrov", CustomerType.Individual), 4000.50M, 2M),
				new LoanAccount(new Customer("Ivan Ivanov", CustomerType.Individual), 500M, 3.5M),
				new DepositAccount(new Customer("Hristo Petrov", CustomerType.Individual), 1000M, 4M),
				new DepositAccount(new Customer("Firma za memeta OOD", CustomerType.Company), 100000M, 6M),
				new DepositAccount(new Customer("Facebook INC", CustomerType.Company), 200000000M, 7M)
			};

			foreach (var acc in accounts)
			{
				Console.WriteLine(acc);
			}
		}
	}
}