using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidUsernames
{
    public class UsernamePair : IComparable<UsernamePair>
    {
        private readonly Tuple<string, string> _usernames;

        private UsernamePair(string firstUsername, string secondUsername)
        {
            _usernames = Tuple.Create(firstUsername, secondUsername);
        }

        private long NamesLength => _usernames.Item1.Length + _usernames.Item2.Length;

        public int CompareTo(UsernamePair other)
        {
            return NamesLength.CompareTo(other.NamesLength);
        }

        public override string ToString()
        {
            return $"{_usernames.Item1}{Environment.NewLine}{_usernames.Item2}";
        }

        public static UsernamePair Parse(string firstUsername, string secondUsername)
        {
            var usernamePair = new UsernamePair(firstUsername, secondUsername);
            return usernamePair;
        }
    }

    public class ValidUsernamesExcercise
    {
        private static readonly char[] _separators = {' ', '/', '\\', '(', ')'};
        private static readonly Regex _usernameRegex = new Regex(@"\b[A-z]\w{2,24}$",
            RegexOptions.None);

        public static void Main()
        {
            var rawUsernamesInput = Console.ReadLine();
            var separatedUsernames = rawUsernamesInput.Split(_separators, 
                StringSplitOptions.RemoveEmptyEntries);
            var validUsernames = ExtractValidUsernames(separatedUsernames)
                .ToArray();

            var validUsernamePairs = CreateUsernamePairs(validUsernames);
            var pairToprint = validUsernamePairs.Max();

            Console.WriteLine(pairToprint);
        }
        
        private static IEnumerable<string> ExtractValidUsernames(IEnumerable<string> usernames)
        {
            var validUsernames = new List<string>();

            foreach (var username in usernames)
            {
                if (IsUsernameValid(username))
                {
                    validUsernames.Add(username);
                }
            }

            return validUsernames;
        }

        private static bool IsUsernameValid(string username)
        {
            return _usernameRegex.IsMatch(username);
        }

        private static IEnumerable<UsernamePair> CreateUsernamePairs(IList<string> validUsernames)
        {
            var usernamePairs = new List<UsernamePair>();

            for (var i = 0; i < validUsernames.Count - 1; ++i)
            {
                usernamePairs.Add(UsernamePair.Parse(validUsernames[i], validUsernames[i + 1]));
            }

            return usernamePairs;
        }
    }
}
