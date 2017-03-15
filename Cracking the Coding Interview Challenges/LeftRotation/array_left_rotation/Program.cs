using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array_left_rotation
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] tokens_n = Console.ReadLine().Split(' ');
			int n = Convert.ToInt32(tokens_n[0]);
			int k = Convert.ToInt32(tokens_n[1]);
			string[] a_temp = Console.ReadLine().Split(' ');
			int[] l = Array.ConvertAll(a_temp, Int32.Parse);
			var trueShift = k % n;
			if (trueShift == 0)
				Console.WriteLine(String.Join(" ", l));
			int[] newL = new int[n];
			Array.Copy(l, trueShift, newL, 0, n - trueShift);
			Array.Copy(l, 0, newL, n - trueShift, trueShift);

			Console.WriteLine(String.Join(" ", newL));
			Console.ReadLine();
		}
	}
}
