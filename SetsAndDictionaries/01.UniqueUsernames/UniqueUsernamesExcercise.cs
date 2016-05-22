using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.UniqueUsernames
{
    public class UniqueUsernamesExcercise
    {
        public static void Main(string[] args)
        {
            var usernamesCount = int.Parse(Console.ReadLine());
            var usernames = new HashSet<string>();

            for (var i = 0; i < usernamesCount; ++i)
            {
                usernames.Add(Console.ReadLine());
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
