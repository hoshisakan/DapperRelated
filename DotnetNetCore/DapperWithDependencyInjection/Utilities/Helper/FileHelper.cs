using Utilities.Enums;
using Utilities.Helper.IHelper;

namespace Utilities.Helper
{
    public class FileHelper : IFileHelper
    {
        private readonly Lazy<ILoggerHelper> _loggerHelper;

        public FileHelper(Lazy<ILoggerHelper> loggerHelper)
        {
            this._loggerHelper = loggerHelper;
        }

        public bool IsFileExists(string path)
        {
            return !string.IsNullOrEmpty(path) && File.Exists(path);
        }

        public bool IsDirExists(string path)
        {
            return !string.IsNullOrEmpty(path) && Directory.Exists(path);
        }

        public bool IsFileExistsInDir(string dir, string filename)
        {
            if (string.IsNullOrEmpty(dir) || string.IsNullOrEmpty(filename))
            {
                return false;
            }
            return IsFileExists(path: Path.Combine(dir, filename));
        }

        public bool SaveValue(string filepath, string dt, bool append)
        {
            try
            {
                using StreamWriter sw = new StreamWriter(filepath, append);
                sw.WriteLine(dt);

                _loggerHelper.Value.LogDebug($"Write {dt} to {filepath} success", nameof(FileHelper), nameof(SaveValue));

                return true;
            }
            catch (Exception ex)
            {
                _loggerHelper.Value.LogError(ex.ToString());
                return false;
            }
        }

        public void ReadFile(string filePath)
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

                string text = File.ReadAllText(filePath);

                _loggerHelper.Value.LogDebug($"Contents of WriteText.txt = {text}", nameof(FileHelper), nameof(ReadFile));
            }
            catch (Exception ex)
            {
                _loggerHelper.Value.LogError(ex.ToString());
            }
        }
    }
}
