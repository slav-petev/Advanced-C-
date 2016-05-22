using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.UserLogs
{
    public class UserLogsExcercise
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var userMesagesInfo = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                var inputParts = input.Split(' ');
                var ip = inputParts[0].Substring(inputParts[0].IndexOf('=') + 1);
                var username = inputParts[2].Substring(inputParts[2].IndexOf('=') + 1);

                if (userMesagesInfo.ContainsKey(username))
                {
                    if (userMesagesInfo[username].ContainsKey(ip))
                    {
                        ++userMesagesInfo[username][ip];
                    }
                    else
                    {
                        userMesagesInfo[username].Add(ip, 1);
                    }
                }
                else
                {
                    userMesagesInfo.Add(username, new Dictionary<string, int>
                    {
                        { ip, 1 }
                    });
                }
                input = Console.ReadLine();
            }

            foreach (var userMessageInfo in userMesagesInfo)
            {
                Console.WriteLine($"{userMessageInfo.Key}:");
                var messageStaticticsBuilder = new StringBuilder();
                foreach (var value in userMessageInfo.Value)
                {
                    messageStaticticsBuilder.AppendFormat($"{value.Key} => {value.Value}, ");
                }
                messageStaticticsBuilder.Remove(messageStaticticsBuilder.Length - 2, 2);
                messageStaticticsBuilder.Append(".");
                Console.WriteLine(messageStaticticsBuilder);
            }
        }
    }
}
