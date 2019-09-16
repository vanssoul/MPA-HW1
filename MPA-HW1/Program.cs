using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPA_HW1
{
    delegate int Compare(Human human1, Human human2);

    class Program
    {
        private static int CompareByName(Human human1, Human human2)
        {
            return human1.Name.CompareTo(human2.Name);
        }
        private static int CompareBySecondName(Human human1, Human human2)
        {
            return human1.SecondName.CompareTo(human2.SecondName);
        }
        private static int CompareByYearBirth(Human human1, Human human2)
        {
            return human1.BirthYear.CompareTo(human2.BirthYear);
        }

        static private List<Human> ScanHumanList(string fileName)
        {
            List<Human> humans = new List<Human>();

            foreach (string line in File.ReadLines(fileName))
            {
                string[] lines = line.Split(' ');
                humans.Add(new Human(lines[1], lines[0], Convert.ToInt32(lines[2])));
            }

            return humans;
        }
        static private void DisplayArray(List<Human> arr)
        {
            for (int i = 0; i < arr.Capacity; i++)
            {
                Console.WriteLine(arr[i].SecondName + " " + arr[i].Name + " " + arr[i].BirthYear);
            }
        }
        static void Main(string[] args)
        {
            List<Human> humans = ScanHumanList("Humans.txt");

            HeapSort hs = new HeapSort();

            hs.Sort(humans, CompareByName);
            DisplayArray(humans);
            Console.WriteLine();

            hs.Sort(humans, CompareBySecondName);
            DisplayArray(humans);
            Console.WriteLine();

            hs.Sort(humans, CompareByYearBirth);
            DisplayArray(humans);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
    class Donator : IComparable<Donator>
    {
        public string name { get; set; }
        public string comment { get; set; }
        public double amount { get; set; }

        public int CompareTo(Donator other)
        {
            return amount.CompareTo(other.amount);
        }
    }
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
    class HeapSort
    {
        private int heapSize;
        private Compare compareDelegate;

        public void Sort(List<Human> arr, Compare compareDelegate)
        {
            this.compareDelegate = compareDelegate;
            BuildHeap(arr);
            for (int i = arr.Capacity - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                heapSize--;
                Heapify(arr, 0);
            }
        }

        private void BuildHeap(List<Human> arr)
        {
            heapSize = arr.Capacity - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }
        private void Swap(List<Human> arr, int x, int y)
        {
            Human temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        private void Heapify(List<Human> arr, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;
            if (left <= heapSize && compareDelegate.Invoke(arr[left], arr[index]) > 0)
            {
                largest = left;
            }

            if (right <= heapSize && compareDelegate.Invoke(arr[right], arr[largest]) > 0)
            {
                largest = right;
            }

            if (largest != index)
            {
                Swap(arr, index, largest);
                Heapify(arr, largest);
            }
        }
    }
}
