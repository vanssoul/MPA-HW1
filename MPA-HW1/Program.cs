using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPA_HW1
{
    class Program
    {
        static private Human[] ScanHumanList(string filePath)
        {
            int countHuman = Convert.ToInt32(File.ReadLines(filePath));
            Human[] humans = new Human[countHuman];

            foreach (string line in File.ReadLines(filePath))
            {
                for (int i = 0; i < countHuman; i++)
                {
                    string[] lines = File.ReadLines(filePath).ToString().Split(' ');
                    humans[i] = new Human(lines[1], lines[0], Convert.ToInt32(lines[2]));
                }
            }
            return humans;
        }
        static void Main(string[] args)
        {
            ScanHumanList("C:/Users/igor3/source/repos/NewRepo/MPA-HW1/MPA-HW1/Humans.txt");
            int[] arr = { 10, 64, 7, 99, 32, 18 };

            HeapSort hs = new HeapSort();
            hs.PerformHeapSort(arr);

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
    class Human
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
    }
    class HeapSort
    {
        private int heapSize;

        public void PerformHeapSort(int[] arr)
        {
            BuildHeap(arr);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                heapSize--;
                Heapify(arr, 0);
            }
            DisplayArray(arr);
        }

        private void BuildHeap(int[] arr)
        {
            heapSize = arr.Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }
        private void Swap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        private void Heapify(int[] arr, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;
            if (left <= heapSize && arr[left] > arr[index])
            {
                largest = left;
            }

            if (right <= heapSize && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                Swap(arr, index, largest);
                Heapify(arr, largest);
            }
        }
        private void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("[{0}]", arr[i]);
            }
        }
    }
}
