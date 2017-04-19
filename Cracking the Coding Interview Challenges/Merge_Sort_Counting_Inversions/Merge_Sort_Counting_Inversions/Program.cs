using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort_Counting_Inversions
{
	class Program
	{
		static void Main(String[] args)
		{
			int t = Convert.ToInt32(Console.ReadLine());
			for (int a0 = 0; a0 < t; a0++)
			{
				int n = Convert.ToInt32(Console.ReadLine());
				string[] arr_temp = Console.ReadLine().Split(' ');
				int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
				var inverions = MergeSort(arr);
				Console.WriteLine(inverions);
			}
			Console.ReadKey();

		}

		private static int MergeSort(int[] arr)
		{
			return MergeSort(arr, new int[arr.Length], 0, arr.Length - 1);
		}

		public static int MergeSort(int[] array, int[] tmp, int leftStart, int rightEnd)
		{
			if (leftStart >= rightEnd)
				return 0;
			
			var mid = (leftStart + rightEnd) / 2;
			int count = 0;
			count += MergeSort(array, tmp, leftStart, mid);
			count += MergeSort(array, tmp, mid + 1, rightEnd);

			//merge
			var leftEnd = mid;
			var rightStart = mid + 1;

			var l = leftStart;
			var r = rightStart;
			var i = leftStart;

			while(l <= leftEnd && r <= rightEnd)
			{
				if (array[l] <= array[r])
				{
					tmp[i] = array[i];
					l++;
				}
				else
				{
					tmp[i] = array[r];
					r++;
				}

				i++;
			}
			Array.Copy(array, l, tmp, i, leftEnd - l + 1);
			Array.Copy(array, r, tmp, i, rightEnd - r + 1);
			Array.Copy(tmp, leftStart, array, leftStart, rightEnd - leftStart + 1);
			count += mid + 1 - i;
			return count;
		}
	}
}
