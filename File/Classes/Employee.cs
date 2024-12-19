using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    internal class Employee
    {
        public string Name { get; set; } //имя
        public List<Task1> AssignedTasks { get; set; } //задачи

        public Employee() { }
        public Employee(string name)
        {
            this.Name = name;
            AssignedTasks = new List<Task1>();
        }

        //взять задачу в работу
        public void TakeTask(Task1 task)
        {
            AssignedTasks.Add(task);
            task.ChangeStatus(TaskStatus.proccesing);
        }

        //делигировать задачу
        public void DelegateTask(Task1 task, Employee employee)
        {
            if (this.AssignedTasks.Contains(task))
            {
                task.Delegate(employee);
                this.AssignedTasks.Remove(task);
                task.ChangeStatus(TaskStatus.assigned);
            }
        }

        //отклонить задачу
        public void TaskRejected(Task1 task)
        {
            try
            {
                task.Executor = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ошибка: {ex}");
            }
        }

        //назначение задачи
        public void AddTask(Project project, Task1 task)
        {
            if (project.TeamLead.Equals(this) && project.Status == ProjectStatus.project)
            {
                project.AddTask(task);
                task.Executor.TakeTask(task);
                Console.WriteLine("задача взята");
            }
            else
            {
                Console.WriteLine($"{this.Name} не тимлид!!!!1");
            }
        }

        //удалить задачу
        public void RemoveTask(Project project, Task1 task)
        {
            if (project.TeamLead.Equals(this) && task.Executor == null)
            {
                project.TaskRemover(task);
                Console.WriteLine("задача удалена!!!");
                if (project.Tasks.Count() == 0)
                {
                    project.Finish();
                    Console.WriteLine("проект завершен!!!");
                }
            }
            else
            {
                Console.WriteLine($"{this.Name} не тимлид!!!!!!");
            }
        }

        //отчет на проверке у инициатора
        //а что именно проверять эээ

        public void PrintExecutorTasks()
        {
            Console.Write($"имя: {Name}, задачи: ");
            foreach (Task1 task in AssignedTasks)
            {
                Console.Write($"{task.Discribtion} ");
            }
            Console.WriteLine();
        }
    }
}
