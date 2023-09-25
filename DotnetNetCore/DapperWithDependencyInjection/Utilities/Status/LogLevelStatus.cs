using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helper;

namespace Utilities.Status
{
    public class LogLevelStatus
    {
        public static readonly string Critical = $"{SystemHelper.GetApplicationName()}-Critical";
        public static readonly string Error = $"{SystemHelper.GetApplicationName()}-Error";
        public static readonly string Warning = $"{SystemHelper.GetApplicationName()}-Warning";
        public static readonly string Information = $"{SystemHelper.GetApplicationName()}-Info";
        public static readonly string Verbose = $"{SystemHelper.GetApplicationName()}-Verbose";
        public static readonly string Debug = $"{SystemHelper.GetApplicationName()}-Debug";
    }
}
