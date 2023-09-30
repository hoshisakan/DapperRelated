using Models.DataModel.ExceptionRelated;
using Utilities.Enums;

using System.Reflection;
using System.Text;


namespace Utilities.Helper
{
    public class LogHelper
    {
        private readonly static string LOG_PATH = JsonConfigurationHelper.GetAppSettingString("LogPath");
        private const int LOG_SIZE_LIMIT = 209715200; // 200MB
        private readonly static string LOG_FILE_DATE_FORMAT = "yyyyMMdd";
        private readonly static string LOG_FILE_CONTENT_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";
        private readonly static string LOG_DIRNAME = Path.Combine(LOG_PATH, SystemHelper.GetApplicationName());
        private readonly static string LOG_FILENAME = $"{DateTimeHelper.GetNowDateFormat(LOG_FILE_DATE_FORMAT)}.log";
        private readonly static string LOG_FILE_CONTENT_DATE = DateTimeHelper.GetNowDateTimeFormat(LOG_FILE_CONTENT_DATE_FORMAT);
        private readonly static Dictionary<LogLevelEnum, string> LOG_LEVEL = new Dictionary<LogLevelEnum, string>
        {
            {LogLevelEnum.ALL, "ALL"},
            {LogLevelEnum.TRACE, "TRC"},
            {LogLevelEnum.DEBUG, "DEG"},
            {LogLevelEnum.INFO, "INF"},
            {LogLevelEnum.WARN, "WAR"},
            {LogLevelEnum.ERROR, "ERR"},
            {LogLevelEnum.FATAL, "FAT"},
            {LogLevelEnum.OFF, "OFF"}
        };


        public LogHelper()
        {
        }

        public static string GetCurrentClassName<T>()
        {
            /// In SystemHelper class, the method name will be return SystemHelper instead of the class name which call this method.
            //return MethodBase.GetCurrentMethod()?.DeclaringType?.Name ?? string.Empty;
            /// Return the class name which call this method.
            return typeof(T).Name;
            /// Return the class name which call this method.
            //return nameof(T);
        }

        public static string GetCurrentMethodName()
        {
            return MethodBase.GetCurrentMethod()?.Name ?? string.Empty;
        }

        //[MethodImpl(MethodImplOptions.NoInlining)]
        //public static string GetCurrentMethodName()
        //{
        //    StackTrace st = new StackTrace(new StackFrame(1));
        //    return st.GetFrame(0).GetMethod().Name;
        //}

        public static void WriteLog(LogLevelEnum logLevel, string methodName, string message)
        {
            try
            {
                if (!FileHelper.CheckDirExists(LOG_DIRNAME))
                {
                    /// Create directory if not exists
                    Directory.CreateDirectory(LOG_DIRNAME);
                }

                string fileName = LOG_FILENAME;
                string filePath = Path.Combine(LOG_DIRNAME, fileName);

                /// If file exists and file size is over LOG_SIZE_LIMIT (200MB), then create a new file with the same name but with a number suffix
                //int i = 0;
                //while (FileHelper.CheckFileExists(filePath))
                //{
                //    FileInfo file = new FileInfo(filePath);
                //    if (file.Length > LOG_SIZE_LIMIT)
                //    {
                //        i++;
                //        fileName = $"{LOG_FILENAME}_{i.ToString()}.log";
                //    }
                //    else
                //    {
                //        break;
                //    }
                //}

                //Console.WriteLine($"Log file path: {filePath}");

                /// Append text to file
                //string appendText = $"{LOG_FILE_CONTENT_DATE} [{LOG_LEVEL[logLevel]}] {message}{Environment.NewLine}";
                string appendText = $"{LOG_FILE_CONTENT_DATE} [{LOG_LEVEL[logLevel]}] [{methodName}] {message}{Environment.NewLine}";

                File.AppendAllText(filePath, appendText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ExceptionDetails exceptionDetails = new ExceptionDetails
                {
                    Message = $"WriteLog error! logLevel: {LOG_LEVEL[logLevel]}, message: {message}",
                    StackTrace = ex.ToString()
                };
                Console.WriteLine($"{JsonHelper.Serialize(exceptionDetails)}");
                return;
            }
        }

        public static void WriteLog(LogLevelEnum logLevel, string message)
        {
            try
            {
                if (!FileHelper.CheckDirExists(LOG_DIRNAME))
                {
                    /// Create directory if not exists
                    Directory.CreateDirectory(LOG_DIRNAME);
                }

                string fileName = LOG_FILENAME;
                string filePath = Path.Combine(LOG_DIRNAME, fileName);

                /// If file exists and file size is over LOG_SIZE_LIMIT (200MB), then create a new file with the same name but with a number suffix
                //int i = 0;
                //while (FileHelper.CheckFileExists(filePath))
                //{
                //    FileInfo file = new FileInfo(filePath);
                //    if (file.Length > LOG_SIZE_LIMIT)
                //    {
                //        i++;
                //        fileName = $"{LOG_FILENAME}_{i.ToString()}.log";
                //    }
                //    else
                //    {
                //        break;
                //    }
                //}

                //Console.WriteLine($"Log file path: {filePath}");

                /// Append text to file
                //string appendText = $"{LOG_FILE_CONTENT_DATE} [{LOG_LEVEL[logLevel]}] {message}{Environment.NewLine}";
                string appendText = $"{LOG_FILE_CONTENT_DATE} [{LOG_LEVEL[logLevel]}] [{GetCurrentMethodName()}] {message}{Environment.NewLine}";

                File.AppendAllText(filePath, appendText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ExceptionDetails exceptionDetails = new ExceptionDetails
                {
                    Message = $"WriteLog error! logLevel: {LOG_LEVEL[logLevel]}, message: {message}",
                    StackTrace = ex.ToString()
                };
                Console.WriteLine($"{JsonHelper.Serialize(exceptionDetails)}");
                return;
            }
        }

        public static void WriteLog<T>(LogLevelEnum logLevel, string message)
        {
            try
            {
                if (!FileHelper.CheckDirExists(LOG_DIRNAME))
                {
                    /// Create directory if not exists
                    Directory.CreateDirectory(LOG_DIRNAME);
                }

                string fileName = LOG_FILENAME;
                string filePath = Path.Combine(LOG_DIRNAME, fileName);

                /// If file exists and file size is over LOG_SIZE_LIMIT (200MB), then create a new file with the same name but with a number suffix
                //int i = 0;
                //while (FileHelper.CheckFileExists(filePath))
                //{
                //    FileInfo file = new FileInfo(filePath);
                //    if (file.Length > LOG_SIZE_LIMIT)
                //    {
                //        i++;
                //        fileName = LOG_FILENAME + "_" + i.ToString() + ".log";
                //    }
                //    else
                //    {
                //        break;
                //    }
                //}

                //Console.WriteLine($"Log file path: {filePath}");

                /// Append text to file
                string appendText = $"{LOG_FILE_CONTENT_DATE} [{LOG_LEVEL[logLevel]}] [{GetCurrentClassName<T>()}] " +
                                    $"[{GetCurrentMethodName()}] {message}{Environment.NewLine}";

                File.AppendAllText(filePath, appendText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ExceptionDetails exceptionDetails = new ExceptionDetails
                {
                    Message = $"WriteLog error! logLevel: {LOG_LEVEL[logLevel]}, message: {message}",
                    StackTrace =  ex.ToString()
                };
                Console.WriteLine($"{JsonHelper.Serialize(exceptionDetails)}");
                return;
            }
        }
    }
}
