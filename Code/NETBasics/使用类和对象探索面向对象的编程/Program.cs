using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用类和对象探索面向对象的编程
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------教程地址: ------------------------"); 
            Console.WriteLine("https://docs.microsoft.com/zh-cn/dotnet/csharp/tutorials/intro-to-csharp/introduction-to-classes");
            Console.WriteLine("--------------------------------------------------------------");
            var account = new BankAccount("杜文龙", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} $ initial balance.");
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message.ToString()}");
            }
            try
            {
                account.MakeWithdrawal(33, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
