using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用类和对象探索面向对象的编程
{
    public class Transaction
    {
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal Amount { get; }
        public DateTime date { get; }
        public string Notes { get; }
        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.date = date;
            this.Notes = note;
        }
    }
}
