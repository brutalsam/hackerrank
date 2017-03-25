using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues_A_Tale_of_Two_Stacks
{
	class Program
	{
		static void Main(string[] args)
		{
			var queryCnt = Convert.ToInt32(Console.ReadLine());
			var stackQueue = new StackQueue();
			var queryList = new List<string>();
			for (int i = 0; i < queryCnt; i++)
			{
				var fullQuery = Console.ReadLine();
				queryList.Add(fullQuery);
			}

			stackQueue.ProcessQuery(queryList);
			Console.ReadKey();
		}

		public class StackQueue
		{
			private Stack<Int32> first;
			private Stack<Int32> second;
			public StackQueue()
			{
				first = new Stack<int>();
				second = new Stack<int>();
			}

			private void Print()
			{
				CopyStack();
				Console.WriteLine(second.Peek());
			}

			private void Dequeue()
			{
				CopyStack();
				second.Pop();
			}

			private void Enqueue(Int32 v)
			{
				first.Push(v);
			}

			public void ProcessQuery(List<string> queryList)
			{
				foreach (var query in queryList)
				{
					var tokens = query.Split(' ');
					switch (Convert.ToInt32(tokens[0]))
					{
						case 1:
							Enqueue(Convert.ToInt32(tokens[1]));
							break;
						case 2:
							Dequeue();
							break;
						case 3:
							Print();
							break;
					}
				}
			}

			private void CopyStack()
			{
				if (second.Count == 0)
				{
					while (first.Count !=0)
					{
						second.Push(first.Pop());
					}
				}

			}
		}
	}

}
