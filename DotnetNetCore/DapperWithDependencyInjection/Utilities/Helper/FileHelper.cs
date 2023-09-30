using Utilities.Enums;


namespace Utilities.Helper
{
    public class FileHelper
    {
        public FileHelper()
        {
        }

        private static bool IsFileExists(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }
            return CheckFileExists(path);
        }

        private static bool IsDirExists(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }
            return CheckDirExists(path);
        }

        private static bool IsFileExistsInDir(string dir, string filename)
        {
            if (string.IsNullOrEmpty(dir) || string.IsNullOrEmpty(filename))
            {
                return false;
            }
            return CheckFileExists(Path.Combine(dir, filename));
        }

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
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());  
                return "fail";
            }
        }

        private static void ReadFile(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException(nameof(filePath));
                }

                if (!IsFileExists(filePath))
                {
                    throw new FileNotFoundException();
                }

                string text = System.IO.File.ReadAllText(filePath);
                Console.WriteLine("Contents of WriteText.txt = {0}", text);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
            }
        }

        public static readonly Func<string, bool> CheckFileExists = (filepath) => File.Exists(filepath);

        public static readonly Func<string, bool> CheckDirExists = (filepath) => Directory.Exists(filepath);

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
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
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
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
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
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
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
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
                return "fail";
            }
        }
    }
}
