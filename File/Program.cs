using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Employee Nadya = new Employee("Надя");
            Employee Dana = new Employee("Дана");
            Employee Misha = new Employee("Миша");
            Employee Fedya = new Employee("Федя");
            Employee Lilo = new Employee("Лило");
            Employee Anna = new Employee("Анна");
            Employee Kostya = new Employee("Костя");
            Employee Ulyana = new Employee("Ульяна");
            Employee Vika = new Employee("Вика");
            Employee Kyte = new Employee("Кейт");
            Employee Kris = new Employee("Крис");
            Employee Bonya = new Employee("Боня");

            Project site = new Project("создание сайта", DateTime.Now.AddDays(100), Misha, Dana);

            Task1 task1 = new Task1("выбрать движок", DateTime.Now.AddDays(10), site.TeamLead, Nadya);
            Task1 task2 = new Task1("создать дизайн", DateTime.Now.AddDays(12), site.TeamLead, Fedya);
            Task1 task3 = new Task1("создать логотип", DateTime.Now.AddDays(12), site.TeamLead, Lilo);
            Task1 task4 = new Task1("пить много кофе", DateTime.Now.AddDays(12), site.TeamLead, Anna);
            Task1 task5 = new Task1("поддерживать моральных дух", DateTime.Now.AddDays(12), site.TeamLead, Kostya);
            Task1 task6 = new Task1("ничего не делать", DateTime.Now.AddDays(12), site.TeamLead, Ulyana);
            Task1 task7 = new Task1("приходить вовремя", DateTime.Now.AddDays(12), site.TeamLead, Vika);
            Task1 task8 = new Task1("сделать все за всех", DateTime.Now.AddDays(12), site.TeamLead, Kyte);
            Task1 task9 = new Task1("подходить ко всем и гладить по головке", DateTime.Now.AddDays(12), site.TeamLead, Kris);
            Task1 task10 = new Task1("кайфует", DateTime.Now.AddDays(12), site.TeamLead, Bonya);
            task10.Print();

            Dana.AddTask(site, task1);
            Dana.AddTask(site, task2);
            Dana.AddTask(site, task3);
            Dana.AddTask(site, task4);
            Dana.AddTask(site, task5);
            Dana.AddTask(site, task6);
            Dana.AddTask(site, task7);
            Dana.AddTask(site, task8);
            Dana.AddTask(site, task9);
            Dana.AddTask(site, task10);


            Bonya.PrintExecutorTasks();
            task10.Print();

            site.Start();

            //изменения при делегации другому работнику
            Bonya.DelegateTask(task5, Vika);
            Bonya.PrintExecutorTasks();
            task5.Print();
            Vika.TaskRejected(task5);
            task5.Print();
            Kris.RemoveTask(site, task5);
            site.PrintTasksInfo();

            //выполнение задач
            task1.TaskReport(new Report("выполнена", Nadya));
            task2.TaskReport(new Report("выполнена", Fedya));
            task3.TaskReport(new Report("выполнена", Lilo));
            task4.TaskReport(new Report("выполнена", Anna));
            task6.TaskReport(new Report("выполнена", Kostya));
            task7.TaskReport(new Report("выполнена", Ulyana));
            task8.TaskReport(new Report("выполнена", Kyte));
            task9.TaskReport(new Report("выполнена", Kris));
            task10.TaskReport(new Report("выполнена", Bonya));
            
        }
    }
}
