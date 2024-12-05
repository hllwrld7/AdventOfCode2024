using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    internal static class Dec5
    {
        internal static string Part1()
        {
            InputReader.Dec4(out var rules, out var data);

            var sum = 0;

            foreach (var pages in data)
            {
                var nums = pages.Split(',').ToList();
                if (IsCorrect(rules, nums))
                {
                    sum += GetMiddleNum(nums);
                }
                    
            }

            return sum.ToString();
        }

        internal static bool IsCorrect(List<string> rules, List<string> nums)
        {
            var isCorrect = true;

            foreach (var rule in rules)
            {
                var rulesArr = rule.Split("|");
                var i0 = nums.IndexOf(rulesArr[0]);
                var i1 = nums.IndexOf(rulesArr[1]);

                if ((i0 >= i1) && i0 != -1 && i1 != -1)
                {
                    isCorrect = false;
                    break;
                }
            }

            return isCorrect;
        }

        internal static string Part2()
        {
            InputReader.Dec4(out var rules, out var data);

            var sum = 0;

            foreach (var pages in data)
            {
                var nums = pages.Split(',').ToList();
                sum += CorrectPagesAndGetMiddle(rules, nums);

            }
            return sum.ToString();
        }

        internal static int CorrectPagesAndGetMiddle(List<string> rules, List<string> nums)
        {
            var isWrong = false;

            foreach (var rule in rules)
            {
                var rulesArr = rule.Split("|");
                var i0 = nums.IndexOf(rulesArr[0]);
                var i1 = nums.IndexOf(rulesArr[1]);

                if ((i0 >= i1) && i0 != -1 && i1 != -1)
                {
                    var t = nums[i0];
                    nums[i0] = nums[i1];
                    nums[i1] = t;
                    CorrectPagesAndGetMiddle(rules, nums);
                    isWrong = true;
                }
            }
            return isWrong ? GetMiddleNum(nums) : 0;
        }

        internal static int GetMiddleNum(List<string> nums)
        {
            var i = nums.Count / 2;
            return int.Parse(nums[i]);
        }
    }
}
