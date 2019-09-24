using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPA_HW1
{
    public class Human : IComparer<Human>
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

        public override bool Equals(object obj)
        {
            if (obj is Human)
            {
                Human equatableObject = obj as Human;
                return this.Name == equatableObject.Name &&
                    this.SecondName == equatableObject.SecondName &&
                    this.BirthYear == equatableObject.BirthYear;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            int hashCode = 1;
            foreach (char letter in this.Name)
            {
                hashCode += letter;
            }
            foreach (char letter in this.SecondName)
            {
                hashCode += letter;
            }
            hashCode *= this.BirthYear;
            return hashCode;
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
