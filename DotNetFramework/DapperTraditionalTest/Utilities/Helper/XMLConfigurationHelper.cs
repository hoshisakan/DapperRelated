using Models.DataModel.ConfigurationRelated;
using System.Configuration;
using Utilities.Helper.IHelper;


namespace Utilities.Helper
{
    public class XMLConfigurationHelper : IXMLConfigurationHelper
    {
        private readonly string className = nameof(XMLConfigurationHelper);
        public readonly Lazy<ILoggerHelper> _loggerHelper;

        public XMLConfigurationHelper(Lazy<ILoggerHelper> loggerHelper)
        {
            this._loggerHelper = loggerHelper;
        }

        public string GetConnectionStringConfigurationValue(string key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            catch (Exception ex)
            {
                _loggerHelper.Value.LogError(ex.ToString());
            }
            return value;
        }

        public string GetAppSettingConfigurationValue(string key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.AppSettings[key] ?? string.Empty;
            }
            catch (Exception ex)
            {
                _loggerHelper.Value.LogError(ex.ToString());
            }
            return value;
        }

        public bool SetAppSettingConfigurationValue(string key, string modifiedValue)
        {
            bool isModifiedSuccessfully = false;

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = modifiedValue;
                config.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");

                Console.WriteLine(GetAppSettingConfigurationValue(key));
            }
            catch (Exception ex)
            {
                _loggerHelper.Value.LogError(ex.ToString());
            }
            return isModifiedSuccessfully;
        }

        public UpdateXMLConfigurationValueResult SetXMLAppSettingConfigurationValue(SetXMLAppSettingConfigurationParameters parameters)
        {
            UpdateXMLConfigurationValueResult updateXMLConfigurationValueResult = new UpdateXMLConfigurationValueResult();

            try
            {
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                if (string.IsNullOrEmpty(parameters.Key))
                {
                    throw new ArgumentNullException(nameof(parameters.Key));
                }

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[parameters.Key].Value = parameters.Value;
                config.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");

                updateXMLConfigurationValueResult.SettingFileKey = parameters.SettingFileKey;
                updateXMLConfigurationValueResult.ModifiedValue = GetAppSettingConfigurationValue(parameters.Key);
                updateXMLConfigurationValueResult.IsModifiedSuccessfully = true;
            }
            catch (Exception ex)
            {
                _loggerHelper.Value.LogError(ex.ToString());
            }
            return updateXMLConfigurationValueResult;
        }
    }
}
