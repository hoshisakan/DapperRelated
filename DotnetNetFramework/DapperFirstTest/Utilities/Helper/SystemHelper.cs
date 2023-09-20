using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Utilities.Helper
{
    public class SystemHelper
    {
        public static void CloseProgram()
        {
            int sleepTime;
            sleepTime = int.TryParse(ConfigurationManager.AppSettings["SleepTime"], out sleepTime) ? sleepTime : 5;
            Console.WriteLine($"Will be close program after {sleepTime} seconds");
            Thread.Sleep(sleepTime * 1000);
            Environment.Exit(0);
        }

        public static void CloseProgram(int sleepTime)
        {
            Console.WriteLine($"Will be close program after {sleepTime} seconds");
            Thread.Sleep(sleepTime * 1000);
            Environment.Exit(0);
        }

        public static string GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }

        public static Func<string> GetApplicationName = () => System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

        public static Func<string> GetApplicationVersion = () => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static Func<string> GetHostName = () => Dns.GetHostName();

        public static Func<string> GetMachineName = () => Environment.MachineName;
    }
}
