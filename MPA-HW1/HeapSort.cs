using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPA_HW1
{
    public class HeapSort
    {
        private int heapSize;
        private Compare compareDelegate;

        public void Sort(List<Human> arr, Compare compareDelegate)
        {
            this.compareDelegate = compareDelegate;
            BuildHeap(arr);
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                heapSize--;
                Heapify(arr, 0);
            }
        }

        private void BuildHeap(List<Human> arr)
        {
            heapSize = arr.Count - 1;
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
