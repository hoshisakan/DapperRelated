using System;
using System.IO;
using System.Linq;

namespace Utilities.Helper
{
    public class FileHelper
    {
        public FileHelper()
        {
        }

        private static readonly Func<string, bool> IsFileExists = (path) =>
        {
            return File.Exists(path);
        };

        private static string SaveValue(string filepath, string dt, bool append)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, append))
                {
                    sw.WriteLine(dt);
                }
                return "success";
            }
            catch (Exception e)
            {
                Console.WriteLine("Get SetDateValue error! e:" + e.ToString());
                LogHelper.WriteLog("Get SetDateValue error! e:" + e.ToString());
                return "fail";
            }
        }

        private static void ReadFile(string filePath)
        {
            try
            {
                if (!IsFileExists(filePath))
                {
                    LogHelper.WriteLog("無法讀取 log 檔!");
                    return;
                }

                string text = System.IO.File.ReadAllText(filePath);
                Console.WriteLine("Contents of WriteText.txt = {0}", text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get ReadFile error! e:" + ex.ToString());
                LogHelper.WriteLog("Get ReadFile error! e:" + ex.ToString());
            }
        }


        private static bool CheckTextExists(string filepath, string text)
        {
            bool result = false;

            try
            {
                if (!File.Exists(filepath))
                {
                    result = false;
                }
                else
                {
                    result = File.ReadAllLines(filepath).Any(f => f == text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get CheckTextExists error! e:" + e.ToString());
                LogHelper.WriteLog("Get CheckTextExists error! e:" + e.ToString());
            }
            return result;
        }

        public static bool RemoveValue(string filepath, string rt)
        {
            bool result = false;
            try
            {
                if (!File.Exists(filepath))
                {
                    result = false;
                }
                else
                {
                    string[] oldFileContent = File.ReadAllLines(filepath);

                    if (!oldFileContent.Contains(rt))
                    {
                        result = false;
                    }

                    string tempFile = Path.GetTempFileName();

                    string[] newFileContent = oldFileContent.Where(val => val != rt).ToArray();

                    File.WriteAllLines(tempFile, newFileContent);
                    File.Delete(filepath);
                    File.Move(tempFile, filepath);

                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get RemoveValue error! e:" + e.ToString());
                LogHelper.WriteLog("Get RemoveValue error! e:" + e.ToString());
            }
            return result;
        }

        public static string GetValue(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    return "fail";
                }
                else
                {
                    ReadFile(filepath);
                    return "success";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get GetValue error! e:" + e.ToString());
                LogHelper.WriteLog("Get GetValue error! e:" + e.ToString());
                return "fail";
            }
        }

        public static string SetValue(string filepath, string dt)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    return SaveValue(filepath, dt, false);
                }
                else
                {
                    if (!CheckTextExists(filepath, dt))
                    {
                        return SaveValue(filepath, dt, true);
                    }
                    return "success";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get SetValue error! e:" + e.ToString());
                LogHelper.WriteLog("Get SetValue error! e:" + e.ToString());
                return "fail";
            }
        }
    }
}
