using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Utilities.Helper
{
    public class RegexHelper
    {
        public static string GetRegexString(string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            return match.Value;
        }

        public static string GetRegexString(string input, string pattern, int groupIndex)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            return match.Groups[groupIndex].Value;
        }

        public static List<string> GetRegexStringList(string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            MatchCollection matchCollection = regex.Matches(input);
            List<string> result = new List<string>();
            foreach (Match match in matchCollection)
            {
                result.Add(match.Value);
            }
            return result;
        }

        public static Func<string, string, Match> GetRegexMatch => (input, pattern) => Regex.Match(input, pattern, RegexOptions.IgnoreCase);
    }
}
