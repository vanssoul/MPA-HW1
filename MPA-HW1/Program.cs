using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

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
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        static private List<Human> GenerateHumansListFromGitHub(int count)
        {
            string myBotNewVersionURL = "https://github.com/georgy-schukin/mpiaa/blob/master/common/names.txt";

            WebClient myBotNewVersionClient = new WebClient();
            Stream stream = myBotNewVersionClient.OpenRead(myBotNewVersionURL);
            StreamReader reader = new StreamReader(stream);
            String contentName = reader.ReadToEnd();



            myBotNewVersionURL = "https://github.com/georgy-schukin/mpiaa/blob/master/common/surnames.txt";

            myBotNewVersionClient = new WebClient();
            stream = myBotNewVersionClient.OpenRead(myBotNewVersionURL);
            reader = new StreamReader(stream);
            String contentSecondName = reader.ReadToEnd();



            Random random = new Random();

            List<Human> randomHumans = new List<Human>(count);
            int randomNumber;
            string randomName, randomSecondName;
            for (int i = 0; i < count; i++)
            {
                randomNumber = random.Next(5490);
                randomName = getBetween(contentName, randomNumber.ToString() + "\" class=\"blob-code blob-code-inner js-file-line\">", "<");
                randomSecondName = getBetween(contentSecondName, randomNumber.ToString() + "\" class=\"blob-code blob-code-inner js-file-line\">", "<");
                randomHumans.Add(new Human(randomName, randomSecondName, random.Next(1930, 2019)));
            }

            return randomHumans;
        }
        static private List<Human> GenerateHumansList(int count)
        {
            string[] names = File.ReadAllLines("names.txt");
            string[] secondNames = File.ReadAllLines("secondnames.txt");

            Random random = new Random();

            List<Human> randomHumans = new List<Human>(count);
            int randomNumber;
            string randomName, randomSecondName;
            for (int i = 0; i < count; i++)
            {
                randomNumber = random.Next(5490);
                randomName = names[random.Next(names.Length)];
                randomSecondName = secondNames[random.Next(secondNames.Length)];
                randomHumans.Add(new Human(randomName, randomSecondName, random.Next(1930, 2019)));
            }

            return randomHumans;
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

            //Time measurement
            Stopwatch stopwatch = new Stopwatch();

            humans = GenerateHumansList(10000);

            stopwatch.Start();

            hs.Sort(humans, CompareByName);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Reset();

            humans = GenerateHumansList(10000);
            stopwatch.Start();

            humans.Sort(CompareByName);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Reset();
        }
    }    
}
