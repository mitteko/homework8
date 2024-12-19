using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov.Classes
{
    internal class Songs
    {
        string name; //название песни
        string author; //автор песни
        public Songs prev; //связь с предыдущей песней в списке


        public Songs() { }
        public Songs(string name, string author)
        {
            this.name = name;
            this.author = author;
            this.prev = null; //9.1
        }
        public Songs(Songs prev, string name, string author)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }

        public void GiveName(string name)
        {
            this.name = name;
        }

        public void GiveAuthor(string author)
        {
            this.author = author;
        }

        public void GivePrev(Songs prev) //метод для заполнения поля prev
        {
            this.prev = prev;
        }

        public string Title() //метод для печати названия песни и ее исполнителя
        {
            return $"название:{name} автор:{author}";
        }

        //метод, который сравнивает между собой два объекта-песни:
        public bool Equals(object d)
        {
            if (d is Songs newsong)
            {
                return (this.name == newsong.name && this.author == newsong.author);
            }
            return false;
        }
    }
}
