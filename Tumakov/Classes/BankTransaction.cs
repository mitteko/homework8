using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    internal class BankTransaction
    {
        public DateTime date { get; }
        public double summa { get; }

        public BankTransaction() { }
        public BankTransaction(double money)
        {
            this.summa = money;
            this.date = DateTime.Now;
        }
        public void Print()
        {
            Console.WriteLine($"Сумма снятия/пополнения:{summa} \n Время:{date}");
        }
    }
}
