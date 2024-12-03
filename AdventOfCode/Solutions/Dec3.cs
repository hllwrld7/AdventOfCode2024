using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode.Solutions
{
    internal static class Dec3
    {
        internal static string Part1()
        {
            InputReader.Dec3(out var text);
            var regex = new Regex(@"((mul\()[0-9]+?[,][0-9]+?(\)))");
            var matches = regex.Matches(text).ToList();

            //var matches = FindMatches(text);

            var sum = 0;
            foreach (var match in matches)
            {
                var regex1 = new Regex(@"(?<=\().+?(?=\,)");
                var regex2 = new Regex(@"(?<=[,]).+?(?=\))");
                var string1 = regex1.Match(match.Value);
                var string2 = regex2.Match(match.Value);

                if (int.TryParse(string1.Value, out var number1))
                    if (int.TryParse(string2.Value, out var number2))
                        sum += number1 * number2;
            }
            return sum.ToString();
        }

        internal static string Part2()
        {
            InputReader.Dec3(out var text);
            var regex = new Regex(@"(do\(\))");
            var dos = regex.Split(text);
            var sum = 0;
            foreach (var match in dos)
            {
                var regex1 = new Regex(@"(don't\(\))");
                var donts = regex1.Split(match);
                var doCount = true;

                foreach (var match2 in donts)
                {
                    if (regex1.IsMatch(match2))
                        doCount = false;

                    if (!doCount)
                        break;
                    var regex2 = new Regex(@"((mul\()[0-9]+?[,][0-9]+?(\)))");
                    var nums = regex2.Matches(match2).ToList();

                    foreach (var match3 in nums)
                    {
                        var regex3 = new Regex(@"(?<=\().+?(?=\,)");
                        var regex4 = new Regex(@"(?<=[,]).+?(?=\))");
                        var string1 = regex3.Match(match3.Value);
                        var string2 = regex4.Match(match3.Value);

                        if (int.TryParse(string1.Value, out var number1))
                            if (int.TryParse(string2.Value, out var number2))
                                sum += number1 * number2;
                    }
                }
            }
            var matches = regex.Matches(text).ToList();

            return sum.ToString();
        }
    }
}
