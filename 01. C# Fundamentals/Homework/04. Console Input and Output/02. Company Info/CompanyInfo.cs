using System;

class CompanyInfo
{
	static void Main()
	{
		string companyName = Console.ReadLine();
		string address = Console.ReadLine();
		string phone = Console.ReadLine();
		string fax = Console.ReadLine();
		string website = Console.ReadLine();
		string managerName = Console.ReadLine();
		string managerLastName = Console.ReadLine();
		string managerAge = Console.ReadLine();
		string managerPhone = Console.ReadLine();

		Console.WriteLine(companyName);
		Console.WriteLine("Address: {0}", address);
		Console.WriteLine("Tel. {0}", phone);
		if (fax == "")
			Console.WriteLine("Fax: (no fax)");
		else
			Console.WriteLine("Fax: {0}", fax);
		Console.WriteLine("Web site: {0}", website);
		Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", managerName, managerLastName, managerAge, managerPhone);
	}
}
