using System;
using System.IO;
using System.Collections.Generic;

namespace MPA_HW1
{
    public delegate int Compare(Human human1, Human human2);

    public class Program
    {
        public static int CompareByName(Human human1, Human human2)
        {
            return human1.Name.CompareTo(human2.Name);
        }
        public static int CompareBySecondName(Human human1, Human human2)
        {
            return human1.SecondName.CompareTo(human2.SecondName);
        }
        public static int CompareByYearBirth(Human human1, Human human2)
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
        static private void WriteArray(StreamWriter streamWriter, List<Human> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                streamWriter.WriteLine(arr[i].SecondName + " " + arr[i].Name + " " + arr[i].BirthYear);
            }
            streamWriter.WriteLine();
        }
        static void Main(string[] args)
        {
            List<Human> humans = ScanHumanList("Humans.txt");

            HeapSort hs = new HeapSort();

            FileStream fileStream = new FileStream("SortedHumans.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            fileStream.Seek(0, SeekOrigin.End);

            hs.Sort(humans, CompareByName);
            streamWriter.WriteLine("Sorted by name:");
            WriteArray(streamWriter, humans);

            hs.Sort(humans, CompareBySecondName);
            streamWriter.WriteLine("Sorted by secondname:");
            WriteArray(streamWriter, humans);

            hs.Sort(humans, CompareByYearBirth);
            streamWriter.WriteLine("Sorted by year birth:");
            WriteArray(streamWriter, humans);

            streamWriter.Close();
        }
    }    
}
