using Microsoft.Extensions.Configuration;

namespace Utilities.Helper.IHelper
{
    public interface IJsonConfigurationHelper
    {
        public ConfigurationBuilder BuildJsonConfiguration(string path);
        //public IConfigurationRoot GetJsonConfiguration(string path);
        public string GetConnectionString(string keyName);
        public string GetAppSettingString(string keyName);
        public int GetAppSettingInt(string keyName, int defaultValue = 0);
        public string GetLogPath(string keyName);
    }
}
