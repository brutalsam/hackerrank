using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tries_Contacts
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = Convert.ToInt32(Console.ReadLine());
		    var book = new ContactsTrie();

            for (int a0 = 0; a0 < n; a0++)
			{
				string[] tokens_op = Console.ReadLine().Split(' ');
				string op = tokens_op[0];
				string contact = tokens_op[1];

			    if (op == "add")
			    {
			        book.Add(contact);
			    }
                else if (op == "find")
			    {
			        var count = book.SearchPrefix(contact);
                    Console.WriteLine(count);
			    }
			    else
			    {
			        throw new Exception($"Unsupported operation [{op}]");
			    }
			}

		    Console.ReadLine();

		}
	}


    public class LetterNode
    {
        public List<LetterNode> Children { get; set; }
        public char Letter { get; set; }
        public int Count { get; set; }
        public LetterNode(char letter)
        {
            Children = new List<LetterNode>();
            Letter = letter;
        }

        public LetterNode GetChild(char c)
        {
            return Children.SingleOrDefault(x => x.Letter == c);
        }
    }

    public class ContactsTrie
    {
        private LetterNode _root;
        public ContactsTrie()
        {
            _root = new LetterNode('@');
        }
        public void Add(string name)
        {
            var nodePointer = _root;
            foreach (var letter in name)
            {
                var nextNode = nodePointer.GetChild(letter);
                if (nextNode == null)
                {
                    nextNode = new LetterNode(letter);
                    nodePointer.Children.Add(nextNode);
                }
                nextNode.Count += 1;
                nodePointer = nextNode;
            }
        }

        public int SearchPrefix(string prefix)
        {
            var nodePointer = _root;

            foreach (var letter in prefix)
            {
                var nextNode = nodePointer.GetChild(letter);
                if (nextNode == null)
                {
                    return 0;
                }
                nodePointer = nextNode;
            }
            return nodePointer.Count;
        }
    }
}
