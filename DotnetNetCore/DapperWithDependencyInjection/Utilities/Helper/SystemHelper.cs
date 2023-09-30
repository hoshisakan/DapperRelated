using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Utilities.Enums;

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
            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                try
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint? endPoint = socket.LocalEndPoint as IPEndPoint;

                    if (endPoint != null)
                    {
                        localIP = endPoint.Address.ToString();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
                }
            }
            return localIP;
        }

        //public static string GetLocalIPAddress()
        //{
        //    try
        //    {
        //        //IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        //        IPHostEntry host = Dns.GetHostEntry(GetMachineName());
        //        foreach (var ip in host.AddressList)
        //        {
        //            if (ip.AddressFamily == AddressFamily.InterNetwork)
        //            {
        //                return ip.ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());

        //    }
        //    return string.Empty;
        //}

        public static readonly Func<string> GetApplicationName = () => Assembly.GetEntryAssembly().GetName().Name;

        public static readonly Func<string> GetCurrentApplicationName = () => Assembly.GetExecutingAssembly().GetName().Name;

        public static readonly Func<string> GetApplicationVersion = () => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static readonly Func<string> GetHostName = () => Dns.GetHostName();

        public static readonly Func<string> GetMachineName = () => Environment.MachineName;
    }
}
