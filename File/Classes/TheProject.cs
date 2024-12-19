using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    enum ProjectStatus { project, execution, closed } //Проект, Исполнение, Закрыт.

    //Сущность Проект
    internal class Project
    {
        public string Discribtion { get; }  //описание проекта,
        public DateTime Deadline { get; private set; } //сроки выполнения
        public Employee Client { get; } //инициатор проекта(заказчик)
        public Employee TeamLead { get; } //человек, ответственный за проект(тимлид)
        public List<Task1> Tasks { get; private set; } //задачи по проекту
        public ProjectStatus Status { get; private set; } //статус


        public Project() { }

        public Project(string discribtion, DateTime deadLine, Employee client, Employee teamLead)
        {
            Discribtion = discribtion;
            Client = client;
            Deadline = deadLine;
            TeamLead = teamLead;
            Tasks = new List<Task1>();
            Status = ProjectStatus.project;
        }

        //создать задачу
        public void AddTask(Task1 task)
        {
            Tasks.Add(task);
        }

        //удалить задачу
        public void TaskRemover(Task1 task)
        {
            Tasks.Remove(task);
        }
        
        //начало проекта
        public void Start()
        {
            Status = ProjectStatus.execution;
        }

        //конец
        public void Finish()
        {
            Status = ProjectStatus.closed;
        }

        //информация по проекту
        public void PrintInfo()
        {
            Console.WriteLine($"Описание: {Discribtion}, Тимлид: {TeamLead.Name}, Статус: {Status}");
        }

        //информация по каждой задаче проекта
        public void PrintTasksInfo()
        {
            foreach (Task1 task in Tasks)
            {
                task.Print();
            }
        }


    }
}
