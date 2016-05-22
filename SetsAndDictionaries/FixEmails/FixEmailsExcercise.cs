using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    public class FixEmailsExcercise
    {
        public static void Main()
        {
            var prohibitedDomains = new[] { "us", "uk" };
            var usersEmails = new Dictionary<string, string>();

            var username = Console.ReadLine();

            while (username != "stop")
            {
                var userEmail = Console.ReadLine();
                var domain = userEmail.Substring(
                    userEmail.IndexOf('.') + 1);

                if (!prohibitedDomains.Contains(domain.ToLower()))
                {
                    usersEmails.Add(username, userEmail);
                }

                username = Console.ReadLine();
            }

            foreach (var usersEmail in usersEmails)
            {
                Console.WriteLine($"{usersEmail.Key} -> {usersEmail.Value}");
            }
        }
    }
}
