using Models.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DataModel.ConfigurationRelated;

namespace Utilities.Helper
{
    public class XMLConfigurationHelper
    {
        public static string GetXMLConnectionStringConfigurationValue(string key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            catch (Exception ex)
            {
                DebugHelper.ReadItemsOutputRawText(ex.Message, "GetXMLConnectionStringConfigurationValue", DateTime.Now.ToString("yyyyMMdd"));
            }
            return value;
        }

        public static string GetXMLAppSettingConfigurationValue(string key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.AppSettings[key] ?? string.Empty;
            }
            catch (Exception ex)
            {
                DebugHelper.ReadItemsOutputRawText(ex.Message, "GetXMLAppSettingConfigurationValue", DateTime.Now.ToString("yyyyMMdd"));
            }
            return value;
        }

        public static bool SetXMLAppSettingConfigurationValue(string key, string modifiedValue)
        {
            bool isModifiedSuccessfully = false;

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = modifiedValue;
                config.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");

                Console.WriteLine(GetXMLAppSettingConfigurationValue(key));
            } 
            catch (Exception ex)
            {
                DebugHelper.ReadItemsOutputRawText(ex.Message, "GetXMLAppSettingConfigurationValue", DateTime.Now.ToString("yyyyMMdd"));
            }
            return isModifiedSuccessfully;
        }

        public static UpdateXMLConfigurationValueResult SetXMLAppSettingConfigurationValue(SetXMLAppSettingConfigurationParameters parameters)
        {
            UpdateXMLConfigurationValueResult updateXMLConfigurationValueResult = new UpdateXMLConfigurationValueResult();

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[parameters.Key].Value = parameters.Value;
                config.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");

                updateXMLConfigurationValueResult.SettingFileKey = parameters.SettingFileKey;
                updateXMLConfigurationValueResult.ModifiedValue = GetXMLAppSettingConfigurationValue(parameters.Key);
                updateXMLConfigurationValueResult.IsModifiedSuccessfully = true;
            }
            catch (Exception ex)
            {
                DebugHelper.ReadItemsOutputRawText(ex.Message, "GetXMLAppSettingConfigurationValue", DateTime.Now.ToString("yyyyMMdd"));
            }
            return updateXMLConfigurationValueResult;
        }
    }
}
