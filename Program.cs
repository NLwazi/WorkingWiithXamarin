using System;
using Banking;

namespace Banks
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank stb = new Bank("Standard Bank", 5336, "Tygervalley");
            Customer myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
            stb.AddCustomer(myNewCustomer);

            var account = myNewCustomer.ApplyForBankAccount();
            account.DepositMoney(1500, DateTime.Now, "Stipend");

            try
            {
                account.WithdrawMoney(500, DateTime.Now, "Buy Whiskey");
                account.WithdrawMoney(500, DateTime.Now, "Buy Burger");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message + " go speak to Manager.");
            }

            Console.WriteLine("Your Balance is:" + account.Balance);

            var history = account.GetTransactionHistory();

            Console.WriteLine(history);
        }
    }
}
