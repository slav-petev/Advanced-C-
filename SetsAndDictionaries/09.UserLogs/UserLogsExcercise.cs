using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryExtensions;

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

                userMesagesInfo.AddOrUpdate(username, 
                    new Dictionary<string, int> { { ip, 1} }, 
                    () => userMesagesInfo[username].AddOrUpdate(ip, 1, () =>
                    {
                        ++userMesagesInfo[username][ip];
                    }));
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
