using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPA_HW1
{
    class Human : IComparer<Human>
    {
        private string name;
        private string secondName;
        private int birthYear;

        public Human(string name, string secondName, int birthYear)
        {
            this.name = name;
            this.secondName = secondName;
            this.birthYear = birthYear;
        }

        public int Compare(Human x, Human y)
        {
            return (x.BirthYear).CompareTo(y.birthYear);
        }

        public string Name
        {
            get { return name; }
        }
        public string SecondName
        {
            get { return secondName; }
        }
        public int BirthYear
        {
            get { return birthYear; }
        }
    }
}
