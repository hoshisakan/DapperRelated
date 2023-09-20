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
            return CheckFileExists(path);
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
                return "fail";
            }
        }

        private static void ReadFile(string filePath)
        {
            try
            {
                if (!IsFileExists(filePath))
                {
                    //LogHelper.WriteLog("無法讀取 log 檔!");
                    return;
                }

                string text = System.IO.File.ReadAllText(filePath);
                Console.WriteLine("Contents of WriteText.txt = {0}", text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Func<string, bool> CheckFileExists = (filepath) => File.Exists(filepath);

        public static Func<string, bool> CheckDirExists = (filepath) => Directory.Exists(filepath);

        private static bool CheckTextExists(string filepath, string text)
        {
            bool result = false;

            try
            {
                if (!CheckFileExists(filepath))
                {
                    result = false;
                }
                else
                {
                    result = File.ReadAllLines(filepath).Any(f => f == text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool RemoveValue(string filepath, string rt)
        {
            bool result = false;
            try
            {
                if (!CheckFileExists(filepath))
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
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static string GetValue(string filepath)
        {
            try
            {
                if (!CheckFileExists(filepath))
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
                return "fail";
            }
        }

        public static string SetValue(string filepath, string dt)
        {
            try
            {
                if (!CheckFileExists(filepath))
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
                return "fail";
            }
        }
    }
}
