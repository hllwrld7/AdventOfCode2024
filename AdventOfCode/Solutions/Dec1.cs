using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    internal static class Dec1
    {
        internal static string Part1()
        {
            InputReader.Dec1(out var list1, out var list2);

            list1.Sort();
            list2.Sort();

            var count = 0;

            for (int i = 0; i < list1.Count; i++)
            {
                count += Math.Abs(list1[i] - list2[i]);
            }

            return count.ToString();
        }

        internal static string Part2()
        {
            InputReader.Dec1(out var list1, out var list2);

            var similarityScore = 0;

            foreach (var number in list1)
            {
                var count = list2.Count(x => x == number);
                similarityScore += count * number;
            }

            return similarityScore.ToString();
        }
    }
}
