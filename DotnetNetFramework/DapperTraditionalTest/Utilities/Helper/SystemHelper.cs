using System.Net;
using System.Net.Sockets;
using System.Reflection;
using Utilities.Helper.IHelper;


namespace Utilities.Helper
{
    public class SystemHelper : ISystemHelper
    {
        private readonly string className = nameof(SystemHelper);
        public readonly Lazy<IJsonConfigurationHelper> _jsonConfigurationHelper;
        public readonly Lazy<ILoggerHelper> _loggerHelper;

        public SystemHelper(Lazy<IJsonConfigurationHelper> jsonConfigurationHelper, Lazy<ILoggerHelper> loggerHelper)
        {
            this._jsonConfigurationHelper = jsonConfigurationHelper;
            this._loggerHelper = loggerHelper;
        }

        public void CloseProgram()
        {
            int sleepTime = _jsonConfigurationHelper.Value.GetAppSettingInt("CloseProgramSleepTime", 5);
            _loggerHelper.Value.LogDebug($"Will be close program after {sleepTime} seconds", className, nameof(CloseProgram));
            Thread.Sleep(sleepTime * 1000);
            Environment.Exit(0);
        }

        public void CloseProgram(int sleepTime)
        {
            Console.WriteLine($"Will be close program after {sleepTime} seconds", className, nameof(CloseProgram));
            _loggerHelper.Value.LogDebug($"Will be close program after {sleepTime} seconds", className, nameof(CloseProgram));
            Thread.Sleep(sleepTime * 1000);
            Environment.Exit(0);
        }

        public string GetLocalIPAddress()
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
                    _loggerHelper.Value.LogError(ex.ToString());
                }
            }
            return localIP;
        }

        //public string GetLocalIPAddress()
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
        //        _loggerHelper.Value.LogError(Lex.ToString());

        //    }
        //    return string.Empty;
        //}

        public string GetApplicationName()
        {
            return Assembly.GetEntryAssembly()?.GetName().Name ?? "No Main Application Name";
        }

        public string GetCurrentApplicationName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name ?? "No Current Application Name";
        }

        public string GetApplicationVersion()
        {
            return Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString() ?? "No Current Application Version";
        }

        public string GetHostName()
        {
            return Dns.GetHostName();
        }

        public string GetMachineName()
        {
            return Environment.MachineName;
        }
    }
}
