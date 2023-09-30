using APWindowsTaskSchedulerMonitor.Helper;
using DapperTraditionalTest.Helper;
using System;
using System.IO;
using System.Text;

namespace Utilities.Helper
{
    public class LogHelper
    {
        private readonly static string SETTING_FILE_LOG_PATH = "CheckResultLogPath";
        private const int LOG_SIZE_LIMIT = 209715200; // 200MB
        private readonly static string LOG_DIR_DATE_FORMAT = "yyyyMMdd";
        private readonly static string LOG_FILE_DATE_FORMAT = "yyyy-MM-dd";
        private readonly static string LOG_FILE_CONTENT_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";
        private readonly static string LOG_DIRNAME = DateTimeHelper.GetNowDateFormat(LOG_DIR_DATE_FORMAT);
        private readonly static string LOG_FILENAME = DateTimeHelper.GetNowDateFormat(LOG_FILE_DATE_FORMAT);
        private readonly static string LOG_FILE_CONTENT_DATE = DateTimeHelper.GetNowDateTimeFormat(LOG_FILE_CONTENT_DATE_FORMAT);


        public LogHelper()
        {
        }

        public static void WriteLog(string logMsg)
        {
            try
            {
                // Log路徑
                string logPath = Path.Combine(
                    XMLConfigurationHelper.GetXMLAppSettingConfigurationValue(SETTING_FILE_LOG_PATH),
                    LOG_DIRNAME
                );

                // 建立資料夾
                Directory.CreateDirectory(logPath);

                string filePath = string.Empty;
                string fileName = LOG_FILENAME + ".log";

                int i = 0;
                while (FileHelper.CheckFileExists(logPath + "\\" + fileName))
                {
                    FileInfo file = new FileInfo(logPath + "\\" + fileName);
                    if (file.Length > LOG_SIZE_LIMIT)
                    {
                        i++;
                        fileName = LOG_FILENAME + "-" + i.ToString() + ".log";
                    }
                    else
                    {
                        break;
                    }
                }

                filePath = logPath + "\\" + fileName;

                // 新增文字附加至檔案
                string appendText = $"[{LOG_FILE_CONTENT_DATE}]";
                appendText += $"[{logMsg}]";
                appendText += Environment.NewLine;

                File.AppendAllText(filePath, appendText, Encoding.UTF8);
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void WriteLog(string jobName, string logMsg)
        {
            try
            {
                // Log路徑
                string logPath = Path.Combine(
                    XMLConfigurationHelper.GetXMLAppSettingConfigurationValue(SETTING_FILE_LOG_PATH),
                    LOG_DIRNAME
                );

                // 建立資料夾
                Directory.CreateDirectory(logPath);

                string filePath = string.Empty;
                string fileName = $"{jobName}-{LOG_FILENAME}.log";

                int i = 0;
                while (FileHelper.CheckFileExists(logPath + "\\" + fileName))
                {
                    FileInfo file = new FileInfo(logPath + "\\" + fileName);
                    if (file.Length > LOG_SIZE_LIMIT)
                    {
                        i++;
                        //fileName = DateTimeHelper.GetNowDate("yyyyMMdd") + "_" + i.ToString() + ".log";
                        fileName = $"{jobName}-{LOG_FILENAME}-{i}.log";
                    }
                    else
                    {
                        break;
                    }
                }

                filePath = logPath + "\\" + fileName;

                // 新增文字附加至檔案
                string appendText = $"[{LOG_FILE_CONTENT_DATE}]";
                appendText += $"[{logMsg}]";
                appendText += Environment.NewLine;

                File.AppendAllText(filePath, appendText, Encoding.UTF8);
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void WriteLog(string jobName, string jobLogDate, string logMsg)
        {
            try
            {
                // Log路徑
                string logPath = Path.Combine(
                    XMLConfigurationHelper.GetXMLAppSettingConfigurationValue(SETTING_FILE_LOG_PATH),
                    jobLogDate.Replace("-", "")
                );

                // 建立資料夾
                Directory.CreateDirectory(logPath);

                string filePath = string.Empty;
                string fileName = $"{jobName}-{jobLogDate}.log";

                int i = 0;
                while (FileHelper.CheckFileExists(logPath + "\\" + fileName))
                {
                    FileInfo file = new FileInfo(logPath + "\\" + fileName);
                    if (file.Length > LOG_SIZE_LIMIT)
                    {
                        i++;
                        //fileName = DateTimeHelper.GetNowDate("yyyyMMdd") + "_" + i.ToString() + ".log";
                        fileName = $"{jobName}-{jobLogDate}-{i}.log";
                    }
                    else
                    {
                        break;
                    }
                }

                filePath = logPath + "\\" + fileName;

                // 新增文字附加至檔案
                string appendText = $"[{LOG_FILE_CONTENT_DATE}]";
                appendText += $"[{logMsg}]";
                appendText += Environment.NewLine;

                File.AppendAllText(filePath, appendText, Encoding.UTF8);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
