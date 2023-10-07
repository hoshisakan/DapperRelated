using Microsoft.Extensions.Configuration;

using Utilities.Helper.IHelper;


namespace Utilities.Helper
{
    public class JsonConfigurationHelper : IJsonConfigurationHelper
    {
        public ConfigurationBuilder BuildJsonConfiguration(string path)
        {
            ConfigurationBuilder configurationBuilder = new();
            configurationBuilder.AddJsonFile(path, optional: true, reloadOnChange: true);
            return configurationBuilder;
        }

        private IConfigurationSection LoadConfigurationFile(string actionName, string filename = "")
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

        public string GetConnectionString(string keyName)
        {
            IConfigurationSection configurationSection = LoadConfigurationFile("ConnectionStrings");

            string connectionString = configurationSection[keyName] ?? string.Empty;

            return connectionString;
        }

        public string GetAppSettingString(string keyName)
        {
            IConfigurationSection configurationSection = LoadConfigurationFile("AppSettings");

            string appSettingValue = configurationSection[keyName] ?? string.Empty;

            return appSettingValue;
        }

        public int GetAppSettingInt(string keyName, int defaultValue = 0)
        {
            if (int.TryParse(GetAppSettingString(keyName), out int result))
            {
                return result;
            }
            return defaultValue;
        }

        public string GetLogPath(string keyName)
        {
            IConfigurationSection configurationSection = LoadConfigurationFile("Logging:LogPath");

            string connectionString = configurationSection[keyName] ?? string.Empty;

            return connectionString;
        }
    }
}
