using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal static class InputReader
    {
        internal static void Dec1(out List<int> list1, out List<int> list2)
        {
            var text = File.ReadAllLines("..\\..\\..\\Inputs\\Dec1.txt");

            list1 = new List<int>();
            list2 = new List<int>();

            var list = new List<string>();

            foreach (var item in text)
            {
                var numbers2 = item.Split("   ");
                list.AddRange(numbers2);
            }

            var numbers = list.Select(x => Int32.Parse(x)).ToList();

            // sort into lists
            for (int i = 0; i < numbers.Count(); i++)
            {
                if (i % 2 == 0)
                    list1.Add(numbers[i]);
                else
                    list2.Add(numbers[i]);
            }
        }

        internal static void Dec2(out List<List<int>> list)
        {
            var text = File.ReadAllLines("..\\..\\..\\Inputs\\Dec2.txt");
            list = new List<List<int>>();

            foreach (var item in text)
            {
                var numbers2 = item.Split(" ");
                list.Add(numbers2.Select(x => Int32.Parse(x)).ToList());
            }

        }

        internal static void Dec3(out string text)
        {
            var textLines = File.ReadAllLines("..\\..\\..\\Inputs\\Dec3.txt");
            text = "";
            foreach (var line in textLines)
                text += line;
        }
    }
}
