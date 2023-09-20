using System;
using System.IO;
using System.Text;
using System.Configuration;


namespace Utilities.Helper
{
    public class LogHelper
    {
        public LogHelper()
        {
        }

        public static void WriteLog(string logMsg)
        {
            try
            {
                // Log路徑
                string? logPath = ConfigurationManager.AppSettings["CheckResultLogPath"];

                // 建立資料夾
                Directory.CreateDirectory(logPath);

                string filePath = string.Empty;
                string fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";

                int i = 0;
                while (File.Exists(logPath + "\\" + fileName))
                {
                    FileInfo file = new FileInfo(logPath + "\\" + fileName);
                    if (file.Length > 209715200)
                    {
                        i++;
                        fileName = DateTime.Now.ToString("yyyyMMdd") + "_" + i.ToString() + ".log";
                    }
                    else
                    {
                        break;
                    }
                }

                filePath = logPath + "\\" + fileName;

                // 新增文字附加至檔案
                string appendText = $"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")}]";
                appendText += $"[{logMsg}]";
                appendText += Environment.NewLine;

                File.AppendAllText(filePath, appendText, Encoding.UTF8);
            }
            catch (Exception)
            {
                return;
            }
        }

        //public static void WriteLog(string msg)
        //{
        //    try
        //    {
        //        string sFile = Func.LogPath + "\\" + string.Format("{0:yyyyMMdd}", DateTime.Now) + ".log";
        //        System.IO.StreamWriter sWriter = System.IO.File.AppendText(sFile);
        //        sWriter.WriteLine(String.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now) + ":" + msg);
        //        sWriter.Close();
        //    }
        //    catch (Exception e) { }
        //}

        //public static void WriteLog(string log)
        //{
        //    try
        //    {
        //        string logpath = Func.LogPath + "\\log.txt";
        //        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logpath, true))
        //        {
        //            sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + log);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Get WriteLog error! e:" + e.ToString());
        //    }
        //}
    }
}
