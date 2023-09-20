using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public class ConfigurationHelper
    {
        public ConfigurationHelper() { }

        /// <summary>
        /// Need send args to this method, otherwise, it will throw exception.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        //private static IConfigurationSection LoadConfigurationFile(string actionName)
        //{
        //    IConfigurationSection configurationSection;
        //    IConfiguration configuration;

        //    /// Method 1, read from appsettings.json file for getting connection string, use IConfigurationSection
        //    using IHost host = Host.CreateDefaultBuilder(args).Build();
        //    configuration = host.Services.GetRequiredService<IConfiguration>();
        //    configurationSection = configuration.GetSection(actionName);

        //    return configurationSection;
        //}

        private static IConfigurationSection LoadConfigurationFile(string actionName, string filename = "")
        {
            if (string.IsNullOrEmpty(filename))
            {
                filename = "appsettings.json";
            }

            /// Method 2, read from appsettings.json file for getting connection string, 
            /// 
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

        public static string GetLogPath(string keyName)
        {
            IConfigurationSection configurationSection = LoadConfigurationFile("Logging:LogPath");

            string connectionString = configurationSection[keyName] ?? string.Empty;

            return connectionString;
        }
    }
}
