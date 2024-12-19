using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Tumakov.Classes;

namespace Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            List<Songs> songs = new List<Songs>()
            {
                new Songs("On My Own","Darci"),
                new Songs("Do I Wanna Know?","Arctic Monkeys"),
                new Songs("Brave","Riley Pearce"),
                new Songs("Я по уши в тебя влюблён","MyaGi"),
            };
            Task4(songs);
            Song mySong = new Song();
            Console.ReadKey();
        }

        /*Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить
    методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить
    конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
    для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
    банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
    счета.*/
        static void Task1()
        {
            Console.WriteLine("Упражнение 9.1");
            Bank bank = new Bank();
            Bank bank1 = new Bank(1000023.54);
            Bank bank2 = new Bank(accountType.текущий);
            Bank bank3 = new Bank(3123.2, accountType.текущий);

            bank.Print();
            bank1.Print();
            bank2.Print();
            bank3.Print();

            bank.InputMoney(3522);
        }

        /*Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию
о всех банковских операциях. При изменении баланса счета создается новый объект класса
BankTransaction, который содержит текущую дату и время, добавленную или снятую со
счета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса
передается один параметр – сумма. В классе банковский счет добавить закрытое поле типа
System.Collections.Queue, которое будет хранить объекты класса BankTransaction для
данного банковского счета; изменить методы снятия со счета и добавления на счет так,
чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в
переменную типа System.Collections.Queue.*/
        static void Task2()
        
        {
            Console.WriteLine("Упражнение 9.2");
            List<Bank> accounts = new List<Bank>()
            {
                new Bank(100300),
                new Bank(2240000, accountType.текущий),
                new Bank(234324, accountType.текущий)
            };
            foreach (Bank account in accounts)
            {
                account.InputMoney(1000);
                account.OutputMoney(1000);
                account.Print();
            }
        }

        /*Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные о
проводках из очереди запишет в файл. Не забудьте внутри метода Dispose вызвать метод
GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
завершения для указанного объекта. */
        static void Task3()
        {
            Console.WriteLine("Упражнение 9.3");
            using (Bank account = new Bank())
            {
                account.InputMoney(1000);
                account.OutputMoney(10);
                account.InputMoney(200);
                account.Print();
            }
        }

        /*Домашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие
конструкторы:
1) параметры конструктора – название и автор песни, указатель на предыдущую песню
инициализировать null.
2) параметры конструктора – название, автор песни, предыдущая песня. В методе Main
создать объект mySong. Возникнет ли ошибка при инициализации объекта mySong
следующим образом: Song mySong = new Song(); ?
Исправьте ошибку, создав необходимый конструктор. */
        static void Task4(List<Songs> list)
        {
            Console.WriteLine("Упражнение 9.1");
            
            foreach (var song in list)
            {
                Console.WriteLine(song.Title());
            }
            for (int i = 1; i < list.Count; i++)
            {
                list[i].GivePrev(list[i - 1]);
            }
            if (list[0].Equals(list[1]))
            {
                Console.WriteLine("это одна и та же песня");
            }
            else
            {
                Console.WriteLine("это разные песни");
            }
        }
    }
}
