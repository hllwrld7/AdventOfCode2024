using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode
{
    internal class Solutions
    {
        public Solutions() { }

        public string Dec1_Part1()
        {
            InputReader.Dec1(out var list1, out var list2);

            list1.Sort();
            list2.Sort();

            var count = 0;

            for(int i = 0; i < list1.Count; i++)
            {
                count += Math.Abs(list1[i] - list2[i]);
            }

            return count.ToString();
        }

        public string Dec1_Part2()
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

        public string Dec2_Part1()
        {
            InputReader.Dec2(out var list);

            var safeReports = 0;

            foreach (var report in list)
            {
                var previousNumber = report[0];
                var state = 0; // 1 = inc; 2 = dec

                for (var i = 1; i < report.Count; i++) {

                    var number = report[i];

                    if (number == previousNumber)
                        break;

                    if (number > previousNumber)
                    {
                        if (state == 2)
                            break;
                        state = 1;
                    }
                    else
                    {
                        if (state == 1)
                            break;
                        state = 2;
                    }

                    // check diff
                    if (Math.Abs(previousNumber - number) > 3)
                        break;

                    previousNumber = number;
                    if (i == report.Count - 1)
                        safeReports++;
                }
            }

            return safeReports.ToString();
        }

        public string Dec2_Part2()
        {
            InputReader.Dec2(out var list);

            var safeReports = 0;

            foreach (var report in list)
            {
                var previousNumber = report[0];
                var state = 0; // 1 = inc; 2 = dec
                var tryToProblemDamp = false;

                for (var i = 1; i < report.Count; i++)
                {
                    var number = report[i];

                    if (number == previousNumber)
                    {
                        tryToProblemDamp = true;
                        break;
                    }

                    if (number > previousNumber)
                    {
                        if (state == 2)
                        {
                            tryToProblemDamp = true;
                            break;
                        }
                        state = 1;
                    }
                    else
                    {
                        if (state == 1)
                        {
                            tryToProblemDamp = true;
                            break;
                        }
                        state = 2;
                    }

                    // check diff
                    if (Math.Abs(previousNumber - number) > 3)
                    {
                        tryToProblemDamp = true;
                        break;
                    }

                    previousNumber = number;
                    if (i == report.Count - 1)
                    {
                        safeReports++;
                        tryToProblemDamp = false;
                    }
                }

                if (tryToProblemDamp)
                {
                    for (var indexToSkip = 0; indexToSkip < report.Count; indexToSkip++)
                    {
                        var startIndex = indexToSkip == 0 ? 1 : 0;
                        previousNumber = report[startIndex];
                        state = 0; // 1 = inc; 2 = dec
                        for (var i = 0; i < report.Count; i++)
                        {
                            if (i == indexToSkip)
                            {
                                if (indexToSkip == report.Count - 1)
                                {
                                    safeReports++;
                                }
                                continue;
                            }

                            var number = report[i];

                            if (number == previousNumber)
                            {
                                if (state == 3 || state != 0)
                                    break;
                                state = 3;
                            }

                            if (number > previousNumber)
                            {
                                if (state == 2)
                                    break;
                                state = 1;
                            }
                            else if (number < previousNumber)
                            {
                                if (state == 1)
                                    break;
                                state = 2;
                            }

                            // check diff
                            if (Math.Abs(previousNumber - number) > 3)
                                break;

                            previousNumber = number;
                            if (i == report.Count - 1)
                            {
                                safeReports++;
                                indexToSkip = report.Count + 1;
                            }
                        }
                    }

                }
            }

            return safeReports.ToString();
        }
    }
}
