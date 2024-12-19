using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    public enum accountType
    {
        cберегательный,
        текущий
    }

    internal class Bank
    {
        private uint id;
        private double balance;
        private accountType isaccType;
        private static uint idgen = 0;

        private Queue<BankTransaction> transaction;
        private bool disposed = false;
        public StreamWriter text;

        //9.1
        public Bank() { this.id = IdForGen(); }

        public Bank(double balance)
        {
            this.balance = balance;
            this.id = IdForGen();
        }
        public Bank(accountType acc)
        {
            isaccType = acc;
            this.id = IdForGen();
        }
        public Bank(double balance, accountType accType1)
        {
            this.id = IdForGen();
            this.balance = balance;
            this.isaccType = accType1;
        }
        //

        private uint IdForGen()
        {
            idgen++;
            return idgen;
        }
        
        //9.2
        public void InputMoney(double summa)
        {
            if (transaction == null)
            {
                transaction = new Queue<BankTransaction>();
            }
            if (summa>0) 
            {
                balance += summa;
                BankTransaction operate = new BankTransaction(summa);
                this.transaction.Enqueue(operate);
            }

        }

        public void OutputMoney(double summa)
        {
            if (transaction == null)
            {
                transaction = new Queue<BankTransaction>();
            }
            if (summa<balance && summa>0)
            {
                balance -= summa;
                BankTransaction operate = new BankTransaction(summa);
                this.transaction.Enqueue(operate);
            }

        }
        //

        //9.3
        public void Dispose() //используется для освобождения ресурсов, занимаемых объектом; нужно освободить как управляемые, так и неуправляемые ресурсы
        {
            Dispose(true);
            GC.SuppressFinalize(this); //предотвращает вызов финализатора для текущего объекта
        }

        //запись информации о переводах в файл
        public void Write() 
        {
            using (StreamWriter writer = new StreamWriter("file.txt", true))
            {
                if (transaction == null)
                {
                    transaction = new Queue<BankTransaction>();
                }
                while (transaction.Count > 0)
                {
                    var trans = transaction.Dequeue();
                    writer.WriteLine($"{trans.date}: {trans.summa}");
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return; //флаг, который указывает, были ли ресурсы уже освобождены, чтобы избежать повторного освобождения ресурсов
            if (disposing)
            {
                Write();
            }
            disposed = true;
        }
        //

        // метод, который переводит деньги с одного счета на другой
        public void Transfer(Bank targetAcc, double amount) 
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть положительной");
                return;
            }

            if (amount > this.balance)
            {
                Console.WriteLine("Недостаточно средств для перевода");
                return;
            }

            this.InputMoney(amount); //снимаем деньги с текущего счёта
            targetAcc.OutputMoney(amount); //переводим средства на целевой счёт
            Console.WriteLine($"Переведено {amount} на счёт {targetAcc.id}");
        }

        public void Print()
        {
            Console.WriteLine($"Номер счета: {id}\nБаланс: {balance}\nТип банковского счета: {isaccType}");
        }
    }
}
