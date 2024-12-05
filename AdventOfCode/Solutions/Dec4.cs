using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode.Solutions
{
    internal static class Dec4
    {
        internal static string Part1()
        {
            InputReader.Dec4(out var text);
            var orginalText = text;

            var invertedHorizontally = InvertListHorizontally(text);

            var invertedVertically = InvertListVertically(text);

            var h = invertedHorizontally;
            var invertedVerticallyAndHorizontally = InvertListVertically(h);

            var diagonals = GetDiagonals(orginalText);
            diagonals.RemoveAt(0);

            var diagonals1 = GetDiagonals(invertedVerticallyAndHorizontally);
            var diagonals2 = GetDiagonals(invertedVertically);
      
            var diagonals3 = GetDiagonals(invertedHorizontally);
            diagonals3.RemoveAt(0);

            File.WriteAllLines("..\\..\\..\\Inputs\\Dec4_test.txt", diagonals1);

            var count = GetXmasCount(orginalText) + GetXmasCount(invertedHorizontally)
                + GetXmasCount(invertedVertically) + GetXmasCount(invertedVerticallyAndHorizontally)
                + GetXmasCount(diagonals) + GetXmasCount(diagonals1)
                + GetXmasCount(InvertListHorizontally(diagonals)) + GetXmasCount(InvertListHorizontally(diagonals1))
                + GetXmasCount(diagonals2) + GetXmasCount(diagonals3)
                + GetXmasCount(InvertListHorizontally(diagonals2)) + GetXmasCount(InvertListHorizontally(diagonals3));

            return count.ToString();
        }

        private static List<string> GetDiagonals(List<string> list)
        {
            var diagonals = new List<string>();
            for (int column = 0; column < list[0].Length; column++)
            {
                var diagonal = "";
                for (int row = 0; row < list.Count; row++)
                {
                    var index = column + row;
                    if (index >= list[0].Length || index < 0)
                        break;
                    diagonal += list[row][index];
                }
                diagonals.Add(diagonal);
            }

            return diagonals;
        }

        private static List<string> InvertListHorizontally(List<string> list)
        {
            var invertedHorizontally = new List<string>();
            foreach (var line in list)
            {
                invertedHorizontally.Add(new String(RevertString(line)));
            }
            return invertedHorizontally;
        }

        private static List<string> InvertListVertically(List<string> list)
        {
            list.Reverse();
            return list;
        }

        private static int GetXmasCount(List<string> strings)
        {
            var regex = new Regex("XMAS");
            var count = 0;
            foreach (var s in strings)
            {
                var matches = regex.Matches(s);
                count += matches.Count;
            }

            return count;
        }

        private static string RevertString(string text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        internal static string Part2()
        {
            return "";
        }
    }
}
