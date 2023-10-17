using Models.DataModel.ExceptionRelated;
using Models.DataModel.LoggerRelated;
using System.Text;
using Utilities.Enums;
using Utilities.Helper.IHelper;

namespace Utilities.Helper
{
    public class LoggerHelper : ILoggerHelper
    {
        private readonly IJsonConfigurationHelper _jsonConfigurationHelper;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IJsonHelper _jsonHelper;
        private readonly Lazy<ISystemHelper> _systemHelper;
        private readonly Lazy<IFileHelper> _fileHelper;

        private readonly string LOG_PATH;
        /// <summary>
        /// If log file size is over 200MB, then create a new file with the same name but with a number suffix
        /// And if appsetting.json file does not have LogSizeLimit key, then use default value 100 MB
        /// Calculate the size of log file: 1 KB = 1024 bytes, 1 MB = 1024 KB, 1 GB = 1024 MB
        /// So 5 KB = 5120 bytes, 10 KB = 10240 bytes, 100 KB = 102400 bytes, 200 KB = 204800 bytes, 512 KB = 524288 bytes, 
        /// 1 MB = 1048576 bytes, 100 MB = 104857600 bytes, 200 MB = 209715200 bytes,
        /// 1 GB = 1073741824 bytes, 2 GB = 2147483648 bytes, 5 GB = 5368709120 bytes, 10 GB = 10737418240 bytes
        /// </summary>
        private readonly int LOG_SIZE_LIMIT;
        private readonly string LOG_FILE_DATE_FORMAT;
        private readonly string LOG_FILE_CONTENT_DATE_FORMAT;
        private readonly string LOG_DIRNAME;
        private readonly string LOG_FILENAME;
        private readonly string LOG_FILE_CONTENT_DATE;

        public LoggerHelper(
            IJsonConfigurationHelper jsonConfigurationHelper, IDateTimeHelper dateTimeHelper,
            Lazy<ISystemHelper> systemHelper, Lazy<IFileHelper> fileHelper, IJsonHelper jsonHelper
        )
        {
            this._jsonConfigurationHelper = jsonConfigurationHelper;
            this._dateTimeHelper = dateTimeHelper;
            this._systemHelper = systemHelper;
            this._fileHelper = fileHelper;
            this._jsonHelper = jsonHelper;

            this.LOG_PATH = _jsonConfigurationHelper.GetAppSettingString("LogPath");
            this.LOG_SIZE_LIMIT = _jsonConfigurationHelper.GetAppSettingInt("LogSizeLimit", 209715200);
            this.LOG_FILE_DATE_FORMAT = "yyyyMMdd";
            this.LOG_FILE_CONTENT_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";
            this.LOG_DIRNAME = Path.Combine(LOG_PATH, _systemHelper.Value.GetApplicationName());
            this.LOG_FILENAME = $"{_dateTimeHelper.GetCurrentDateTimeString(LOG_FILE_DATE_FORMAT)}.log";
            this.LOG_FILE_CONTENT_DATE = _dateTimeHelper.GetCurrentDateTimeString(LOG_FILE_CONTENT_DATE_FORMAT);
        }

        public void LogALL(string message)
        {
            WriteLog(new LoggerDto { LogLevel = GetLogLevelName(LogLevelEnum.ALL), Message = message });
        }

        public void LogALL(string message, string className = "", string methodName = "")
        {
            WriteLog(
                new LoggerDto
                {
                    LogLevel = GetLogLevelName(LogLevelEnum.ALL),
                    Message = message,
                    ClassName = className,
                    MethodName = methodName
                }
            );
        }

        public void LogTrace(string message)
        {
            WriteLog(new LoggerDto { LogLevel = GetLogLevelName(LogLevelEnum.TRACE), Message = message });
        }

        public void LogTrace(string message, string className = "", string methodName = "")
        {
            WriteLog(
                new LoggerDto
                {
                    LogLevel = GetLogLevelName(LogLevelEnum.TRACE),
                    Message = message,
                    ClassName = className,
                    MethodName = methodName
                }
            );
        }

        public void LogDebug(string message)
        {
            WriteLog(new LoggerDto { LogLevel = GetLogLevelName(LogLevelEnum.DEBUG), Message = message });
        }

        public void LogDebug(string message, string className = "", string methodName = "")
        {
            WriteLog(
                new LoggerDto
                {
                    LogLevel = GetLogLevelName(LogLevelEnum.DEBUG),
                    Message = message,
                    ClassName = className,
                    MethodName = methodName
                }
            );
        }

        public void LogInfo(string message)
        {
            WriteLog(new LoggerDto { LogLevel = GetLogLevelName(LogLevelEnum.INFO), Message = message });
        }

        public void LogInfo(string message, string className = "", string methodName = "")
        {
            WriteLog(
                new LoggerDto
                {
                    LogLevel = GetLogLevelName(LogLevelEnum.INFO),
                    Message = message,
                    ClassName = className,
                    MethodName = methodName
                }
            );
        }

        public void LogWarning(string message)
        {
            WriteLog(new LoggerDto { LogLevel = GetLogLevelName(LogLevelEnum.WARN), Message = message });
        }

        public void LogWarning(string message, string className = "", string methodName = "")
        {
            WriteLog(
                new LoggerDto
                {
                    LogLevel = GetLogLevelName(LogLevelEnum.WARN),
                    Message = message,
                    ClassName = className,
                    MethodName = methodName
                }
            );
        }

        public void LogError(string message)
        {
            WriteLog(new LoggerDto { LogLevel = GetLogLevelName(LogLevelEnum.ERROR), Message = message });
        }

        public void LogError(string message, Exception ex, string className = "", string methodName = "")
        {
            WriteLog(
                new LoggerDto
                {
                    LogLevel = GetLogLevelName(LogLevelEnum.ERROR),
                    Message = message,
                    ClassName = className,
                    MethodName = methodName
                }
            );
        }

        public void LogFatal(string message)
        {
            WriteLog(new LoggerDto { LogLevel = GetLogLevelName(LogLevelEnum.FATAL), Message = message });
        }

        public void LogFatal(string message, string className = "", string methodName = "")
        {
            WriteLog(
                new LoggerDto
                {
                    LogLevel = GetLogLevelName(LogLevelEnum.FATAL),
                    Message = message,
                    ClassName = className,
                    MethodName = methodName
                }
            );
        }

        public void LogOff(string message)
        {
            WriteLog(new LoggerDto { LogLevel = GetLogLevelName(LogLevelEnum.OFF), Message = message });
        }

        public void LogOff(string message, string className = "", string methodName = "")
        {
            WriteLog(
                new LoggerDto
                {
                    LogLevel = GetLogLevelName(LogLevelEnum.OFF),
                    Message = message,
                    ClassName = className,
                    MethodName = methodName
                }
            );
        }

        private string GetLogFullPath()
        {
            if (!_fileHelper.Value.IsDirExists(LOG_DIRNAME))
            {
                /// Create directory if not exists
                Directory.CreateDirectory(LOG_DIRNAME);
            }

            string fileName = LOG_FILENAME;
            string filePath = Path.Combine(LOG_DIRNAME, fileName);

            /// If file exists and file size is over LOG_SIZE_LIMIT (200MB), then create a new file with the same name but with a number suffix
            int i = 0;
            while (_fileHelper.Value.IsFileExists(filePath))
            {
                FileInfo file = new FileInfo(filePath);

                if (file.Length > LOG_SIZE_LIMIT)
                {
                    i++;
                    fileName = $"{LOG_FILENAME}_{i}.log";
                    filePath = Path.Combine(LOG_DIRNAME, fileName);
                }
                else
                {
                    break;
                }
            }
            return filePath;
        }

        private readonly Func<LogLevelEnum, string> GetLogLevelName = (logLevelEnum) => Enum.GetName(typeof(LogLevelEnum), logLevelEnum) ?? throw new Exception("Unknown logLevel.");

        private void WriteLog(LoggerDto loggerDto)
        {
            try
            {
                string filePath = GetLogFullPath();
                string appendText = string.Empty;

                appendText = $"{LOG_FILE_CONTENT_DATE} [{loggerDto.LogLevel}] [ClassName] [MethodName] [Exception] {loggerDto.Message}{Environment.NewLine}";

                if ((loggerDto.LogLevel == "ERROR" && loggerDto.Exception == null) || string.IsNullOrEmpty(loggerDto.ClassName)
                    || string.IsNullOrEmpty(loggerDto.MethodName))
                {
                    if (loggerDto.Exception == null)
                    {
                        appendText = appendText.Replace("[Exception] ", "");
                    }

                    if (string.IsNullOrEmpty(loggerDto.ClassName))
                    {
                        appendText = appendText.Replace("[ClassName] ", "");
                    }
                    if (string.IsNullOrEmpty(loggerDto.MethodName))
                    {
                        appendText = appendText.Replace("[MethodName] ", "");
                    }

                }
                else
                {
                    appendText = $"{LOG_FILE_CONTENT_DATE} [{loggerDto.LogLevel}] [{loggerDto.ClassName}] [{loggerDto.MethodName}] [{loggerDto.Exception}] {loggerDto.Message}{Environment.NewLine}";
                }

                File.AppendAllText(filePath, appendText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ExceptionDetails exceptionDetails = new ExceptionDetails
                {
                    Message = $"WriteLog error! logLevel: {loggerDto.LogLevel}",
                    Details = ex.ToString()
                };
                Console.WriteLine($"{_jsonHelper.Serialize(exceptionDetails)}");
                return;
            }
        }
    }
}
