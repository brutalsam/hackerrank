using System;
using System.Linq;

namespace RansomNote
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);
            string[] magazine = Console.ReadLine().Split(' ');
            string[] ransom = Console.ReadLine().Split(' ');

            Console.WriteLine(CanMakeRansom(magazine, ransom) ? "Yes" : "No");
            Console.ReadLine();
        }

        private static bool CanMakeRansom(string[] magazine, string[] ransom)
        {
            var magazineWords = magazine.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());

            var ransomWords = ransom.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());
            foreach (var word in ransomWords)
            {
                if (!magazineWords.ContainsKey(word.Key))
                    return false;
                if (magazineWords[word.Key] < word.Value)
                    return false;
            }

            return true;
        }
    }
}
