using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace Utilities.Helper.IHelper
{
    public interface ILoggerHelper
    {
        //public void Log(string message, LogLevelEnum logLevel);
        //public void Log(string message, LogLevelEnum logLevel, Exception exception);
        //public void Log(string message, LogLevelEnum logLevel, string className, string methodName);
        //public void Log(string message, LogLevelEnum logLevel, string className, string methodName, Exception exception);
        public void LogALL(string message);
        public void LogALL(string message, string className = "", string methodName = "");
        public void LogTrace(string message);
        public void LogTrace(string message, string className = "", string methodName = "");
        public void LogDebug(string message);
        public void LogDebug(string message, string className = "", string methodName = "");
        public void LogInfo(string message);
        public void LogInfo(string message, string className = "", string methodName = "");
        public void LogWarning(string message);
        public void LogWarning(string message, string className = "", string methodName = "");
        public void LogError(string message);
        public void LogError(string message, Exception ex, string className = "", string methodName = "");
        public void LogFatal(string message);
        public void LogFatal(string message, string className = "", string methodName = "");
        public void LogOff(string message);
        public void LogOff(string message, string className = "", string methodName = "");
    }
}
