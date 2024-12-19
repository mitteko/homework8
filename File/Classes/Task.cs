using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    enum TaskStatus { assigned, proccesing, checking, complete } //Назначена, В работе, На проверке, Выполнена.

    //Сущность Задача
    internal class Task1
    {
        public string Discribtion { get; } //описание задачи,
        public DateTime Deadline { get; } //сроки задачи,
        public Employee Originator { get; } //инициатор задачи.
        public Employee Executor { get; set; } //исполнитель,
        public TaskStatus TaskStatus { get; private set; } //статус задачи
        public Report Report { get; set; } //отчет(ы) по задаче

        public Task1() { }
        public Task1(string discribtion, DateTime deadline, Employee originator, Employee executor)
        {
            Discribtion = discribtion;
            Deadline = deadline;
            Originator = originator;
            Executor = executor;
            TaskStatus = TaskStatus.assigned;
        }

        //изменить статус
        public void ChangeStatus(TaskStatus taskStatus)
        {
            TaskStatus = taskStatus;
        }

        //делегировать задачу
        public void Delegate(Employee executor)
        {
            Executor = executor;
        }

        //отчет по выполненной работе
        public void TaskReport(Report report) 
        {
            Report = report;
        } 

        public void Print()
        {
            string name = Executor != null ? Executor.Name : "нет";
            Console.WriteLine($"Описание: {Discribtion}, Исполнитель: {name}, Статус: {TaskStatus}");
        }

    }
}
