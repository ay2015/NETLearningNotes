using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用类和对象探索面向对象的编程
{
    /// <summary>
    /// BankAccount 类表示银行帐户，账户支持以下行为：
    /// 用一个 10 位数唯一标识银行帐户。
    ///用字符串存储一个或多个所有者名称。
    ///可以检索余额。
    ///接受存款。
    ///接受取款。
    ///初始余额必须是正数。
    ///取款后的余额不能是负数。
    /// </summary>
    public class BankAccount
    {
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }
        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        /// <summary>
        /// 业主
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        /// <summary>
        /// 存款
        /// </summary>
        /// <param name="amount">数量</param>
        /// <param name="date">日期</param>
        /// <param name="note">记录</param>
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        /// <summary>
        /// 取款
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var widthdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(widthdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();
            report.AppendLine("Date\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            report.AppendLine($"Balance\t{Balance}");
            return report.ToString();
        }
    }
}
