using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractHyperlinks
{
    public class ExtractHyperlinksExcercise
    {
        private static readonly Regex _hyperlinkRegex =
            new Regex("<a.*>.*</a>", RegexOptions.Singleline);

        public static void Main()
        {
            var input = ReadInputFromConsole();
            var hyperlinks = ExtractHyperlinksFromInput(input);

            //Console.WriteLine(input);
        }

        private static string ReadInputFromConsole()
        {
            var input = new StringBuilder();

            var currentInputLine = Console.ReadLine();

            while (currentInputLine != "END")
            {
                input.AppendLine(currentInputLine);

                currentInputLine = Console.ReadLine();
            }

            return input.ToString();
        }

        private static IEnumerable<string> ExtractHyperlinksFromInput(string input)
        {
            var hyperlinks = new List<string>();

            var hyperlinkMatches = _hyperlinkRegex.Matches(input);
            foreach (Match hyperlinkMatch in hyperlinkMatches)
            {
                hyperlinks.Add(hyperlinkMatch.Value);
            }

            return hyperlinks;
        }
    }
}
