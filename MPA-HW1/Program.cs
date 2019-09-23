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
}
