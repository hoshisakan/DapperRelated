using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public class JsonConfigurationHelper
    {
        public JsonConfigurationHelper()
        {

        }

        public static ConfigurationBuilder BuildJsonConfiguration(string path)
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddJsonFile(path, optional: true, reloadOnChange: true);
            return configurationBuilder;
        }

        private static IConfigurationSection LoadConfigurationFile(string actionName, string filename = "")
        {
            if (string.IsNullOrEmpty(filename))
            {
                filename = "appsettings.json";
            }

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(filename, optional: true, reloadOnChange: true);
            IConfiguration configuration = configurationBuilder.Build();
            IConfigurationSection configurationSection = configuration.GetSection(actionName);

            return configurationSection;
        }

        public static string GetConnectionString(string keyName)
        {
            IConfigurationSection configurationSection = LoadConfigurationFile("ConnectionStrings");

            string connectionString = configurationSection[keyName] ?? string.Empty;

            return connectionString;
        }

        public static string GetAppSettingString(string keyName)
        {
            IConfigurationSection configurationSection = LoadConfigurationFile("AppSettings");

            string connectionString = configurationSection[keyName] ?? string.Empty;

            return connectionString;
        }

        public static string GetLogPath(string keyName)
        {
            IConfigurationSection configurationSection = LoadConfigurationFile("Logging:LogPath");

            string connectionString = configurationSection[keyName] ?? string.Empty;

            return connectionString;
        }
    }
}
