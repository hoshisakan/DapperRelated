using Models.LoggerRelated.ConfigurationRelated;

namespace Utilities.Helper.IHelper
{
    public interface IXMLConfigurationHelper
    {
        public string GetConnectionStringConfigurationValue(string key);
        public string GetAppSettingConfigurationValue(string key);
        public bool SetAppSettingConfigurationValue(string key, string modifiedValue);
        public UpdateXMLConfigurationValueResult SetXMLAppSettingConfigurationValue(SetXMLAppSettingConfigurationParameters parameters);
    }
}