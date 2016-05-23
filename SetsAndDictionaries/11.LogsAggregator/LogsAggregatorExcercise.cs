using System;
using System.Collections.Generic;

namespace _11.LogsAggregator
{
    public class LogsAggregatorExcercise
    {
        public static void Main(string[] args)
        {
            var numberOfAccessLogs = int.Parse(Console.ReadLine());

            var userSessionsIpInfo = new SortedDictionary<string, SortedSet<string>>();
            var userSessionsDurationInfo = new Dictionary<string, int>();

            for (var i = 0; i < numberOfAccessLogs; ++i)
            {
                var accessLogInfo = Console.ReadLine();
                var accessLogInfoParts = accessLogInfo.Split(' ');

                var username = accessLogInfoParts[1];
                var ip = accessLogInfoParts[0];
                var duration = int.Parse(accessLogInfoParts[2]);

                ProcessUserIp(username, ip, userSessionsIpInfo);
                ProcessUserSessionDuration(username, duration, userSessionsDurationInfo);
            }

            foreach (var userInfo in userSessionsIpInfo)
            {
                Console.Write($"{userInfo.Key}: {userSessionsDurationInfo[userInfo.Key]} ");
                Console.WriteLine($"[{string.Join(", ", userSessionsIpInfo[userInfo.Key])}]");
            }
        }

        private static void ProcessUserIp(string username, string ip, 
            SortedDictionary<string, SortedSet<string>> userSessionsIpInfo)
        {
            if (userSessionsIpInfo.ContainsKey(username))
            {
                userSessionsIpInfo[username].Add(ip);
            }
            else
            {
                userSessionsIpInfo.Add(username, new SortedSet<string> { ip });
            }
        }

        private static void ProcessUserSessionDuration(string username, int duration,
            Dictionary<string, int> userSessionsDurationInfo)
        {
            if (userSessionsDurationInfo.ContainsKey(username))
            {
                userSessionsDurationInfo[username] += duration;
            }
            else
            {
                userSessionsDurationInfo.Add(username, duration);
            }
        }
    }
}
