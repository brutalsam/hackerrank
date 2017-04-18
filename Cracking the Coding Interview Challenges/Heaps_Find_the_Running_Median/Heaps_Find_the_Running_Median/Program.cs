using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Find_the_Running_Median
{
	class Program
	{
		static void Main(string[] args)
		{ 
			int n = Convert.ToInt32(Console.ReadLine());
			int[] a = new int[n];
            var minHeap = new SimpleHeap(n, (x, y) => x > y);
            var maxHeap = new SimpleHeap(n, (x, y) => x < y);
            for (var a_i = 0; a_i<n; a_i++)
            {
			    a[a_i] = Convert.ToInt32(Console.ReadLine());   
                
                if (minHeap.Count() == 0)
                {
                    minHeap.Add(a[a_i]);
                }

                else if (a[a_i] < minHeap.Peek())
                {
                    minHeap.Add(a[a_i]);
                    if (minHeap.Count() > maxHeap.Count() + 1)
                    {
                        maxHeap.Add(minHeap.Pop());
                    }
                }
                else
                {
                    maxHeap.Add(a[a_i]);
                    if (maxHeap.Count() > minHeap.Count() + 1)
                    {
                        minHeap.Add(maxHeap.Pop());
                    }
                }

		        decimal median;
                if (minHeap.Count() == maxHeap.Count())
                {
                    median = (decimal)(minHeap.Peek() + maxHeap.Peek()) / 2;
                }
                else if (minHeap.Count() > maxHeap.Count())
                {
                    median = minHeap.Peek();
                }
                else
                {
                    median = maxHeap.Peek();
                }

                Console.WriteLine("{0:f1}", median);
            }

		    Console.ReadKey();
		}
	}

    public class SimpleHeap
    {
        private int[] heap;
        private int size;

        private readonly Func<int, int, bool> _compare;

        public SimpleHeap(int capacity, Func<int, int, bool> compare)
        {
            heap = new int[capacity];
            size = 0;
            _compare = compare;
        }
        public void Add(int element)
        {
            heap[size] = element;
            size++;
            FixUp();
        }

        public int Count()
        {
            return size;
        }

        private void FixUp()
        {
            int i = size - 1;
            while ((i > 0) && (_compare(heap[i], heap[getParent(i)])))
            {
                Swap(i, getParent(i));
                i = getParent(i);
            }
        }

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        private int getParent(int i)
        {
            return (i - 1) / 2;
        }

        public int Peek()
        {
            return heap[0];
        }

        public int Pop()
        {
            var pop = heap[0];
            heap[0] = heap[size - 1];
            size--;
            FixDown();
            return pop;
        }

        private int getLeftChildIndex(int i)
        {
            return 2 * i + 1;
        }

        private int getRightChildIndex(int i)
        {
            return 2 * i + 2;
        }

        private bool hasLeftChild(int i)
        {
            return getLeftChildIndex(i) < size;
        }

        private bool hasRightChild(int i)
        {
            return getRightChildIndex(i) < size;
        }

        private void FixDown()
        {
            var i = 0;
            while (hasLeftChild(i))
            {
                int smallerChildIndex = getLeftChildIndex(i);
                if (hasRightChild(i) && _compare(heap[getRightChildIndex(i)], heap[smallerChildIndex])) { smallerChildIndex = getRightChildIndex(i); }
                if (_compare(heap[i], heap[smallerChildIndex])) break;
                Swap(i, smallerChildIndex);
                i = smallerChildIndex;
            }
        }
    }

}
