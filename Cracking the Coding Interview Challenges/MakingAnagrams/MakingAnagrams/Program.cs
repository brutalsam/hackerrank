using System;

namespace MakingAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            var result = CountRedundantCharacters(a, b);
            Console.WriteLine(result);
        }


        //clinton_stampers solution from https://www.hackerrank.com/challenges/ctci-making-anagrams/forum
        private static int CountRedundantCharacters(string a, string b)
        {
            var letterArray = new int[26];
            foreach (var ch in a.ToCharArray())
            {
                letterArray[ch - 'a']++;
            }
            foreach (var ch in b.ToCharArray())
            {
                letterArray[ch - 'a']--;
            }

            int lettersTodelete = 0;
            foreach (var i in letterArray)
            {
                lettersTodelete += Math.Abs(i);
            }
            return lettersTodelete;
        }
    }
}
