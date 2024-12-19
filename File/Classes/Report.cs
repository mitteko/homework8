using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    //Сущность Отчёт:
    internal class Report
    {
        public string Text { get; } //текст отчета,
        public DateTime ExecutionDate { get; } //дата выполнения,
        public Employee Executor { get; } //исполнитель.

        public Report(string text, Employee Executor)
        {
            this.Text = text;
            this.Executor = Executor;
            this.ExecutionDate = DateTime.Now;
        }
    }
}
