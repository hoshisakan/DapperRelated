using Models.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DataModel.ConfigurationRelated;
using Utilities.Enums;

namespace Utilities.Helper
{
    public class XMLConfigurationHelper
    {
        public static string GetConnectionStringConfigurationValue(string key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
            }
            return value;
        }

        public static string GetAppSettingConfigurationValue(string key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.AppSettings[key] ?? string.Empty;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
            }
            return value;
        }

        public static bool SetAppSettingConfigurationValue(string key, string modifiedValue)
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
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
            }
            return isModifiedSuccessfully;
        }

        public static UpdateXMLConfigurationValueResult SetXMLAppSettingConfigurationValue(SetXMLAppSettingConfigurationParameters parameters)
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
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
            }
            return updateXMLConfigurationValueResult;
        }
    }
}
