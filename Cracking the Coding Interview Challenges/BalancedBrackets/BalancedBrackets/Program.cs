using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBrackets
{
	class Program
	{
		static void Main(string[] args)
		{
			int t = Convert.ToInt32(Console.ReadLine());
			for (int a0 = 0; a0 < t; a0++)
			{
				string expression = Console.ReadLine();
				Console.WriteLine(IsBracketsBalanced(expression) ? "YES" : "NO");
			}

			Console.ReadLine();
		}

		static bool IsBracketsBalanced(string brackets)
		{
			var opositeCharDict = new Dictionary<char, char> {
				{')', '(' },
				{']', '[' },
				{'}', '{' }
			};
			var stack = new Stack<char>();
			foreach (var bracket in brackets)
			{
				if (bracket == '(' || bracket == '[' || bracket == '{')
				{
					stack.Push(bracket);
				}
				else
				{
					if (stack.Count == 0 || stack.Peek() != opositeCharDict[bracket])
						return false;
					stack.Pop();
				}

			}
			return stack.Count == 0 ? true : false;
		}
	}
}
