using DapperTraditionalTest.Status;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helper;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace APWindowsTaskSchedulerMonitor.Helper
{
    public class XMLConfigurationHelper
    {
        public static string GetXMLConnectionStringConfigurationValue(string key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.ConnectionStrings[key].ConnectionString ?? string.Empty;
            }
            catch (Exception ex)
            {
                DebugHelper.ReadItemsOutputRawText(ex.ToString(), LogLevelStatus.Error, DateTime.Now.ToString("yyyyMMdd"));
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
                DebugHelper.ReadItemsOutputRawText(ex.ToString(), LogLevelStatus.Error, DateTime.Now.ToString("yyyyMMdd"));
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
                DebugHelper.ReadItemsOutputRawText(ex.ToString(), LogLevelStatus.Error, DateTime.Now.ToString("yyyyMMdd"));
            }
            return isModifiedSuccessfully;
        }
    }
}
