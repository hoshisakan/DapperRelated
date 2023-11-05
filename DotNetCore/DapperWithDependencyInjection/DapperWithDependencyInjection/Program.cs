using DapperWithDependencyInjection.Extensions;
using DapperWithDependencyInjection.Test.ITest;
using DataAccess.Data.IData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Helper;
using Utilities.Helper.IHelper;

namespace DapperWithDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Build service collection
            ServiceCollection services = new ServiceCollection();

            #region Register services
            /// Add application services, which are defined in Extensions/ApplicationServiceExtensions.cs
            services.AddSingleton<IJsonConfigurationHelper, JsonConfigurationHelper>();

            /// Get IJsonConfigurationHelper from service provider
            IJsonConfigurationHelper _jsonConfigurationHelper = services.BuildServiceProvider().GetRequiredService<IJsonConfigurationHelper>();

            /// Create configuration builder
            ConfigurationBuilder? configuraion = _jsonConfigurationHelper.BuildJsonConfiguration("appsettings.json");

            /// Add application services, which are defined in Extensions/ApplicationServiceExtensions.cs
            services.AddApplicationServices(configuraion.Build());
            #endregion Register services

            #region Build service provider
            /// Build service provider
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            /// Create service scope
            IServiceScope scope = serviceProvider.CreateScope();

            /// Use service scope to get service provider
            IServiceProvider service = scope.ServiceProvider;
            #endregion Build service provider

            #region Get services from service scope
            /// Get services from service scope
            ILoggerHelper? _loggerHelper = service.GetRequiredService<ILoggerHelper>();
            IDapperTest? _dapperTest = service.GetRequiredService<IDapperTest>();
            ISystemHelper? _systemHelper = service.GetRequiredService<ISystemHelper>();
            IStopwatchHelper? _stopwatchHelper = scope.ServiceProvider.GetRequiredService<IStopwatchHelper>();
            #endregion Get services from service scope

            try
            {
                _stopwatchHelper.Timer(_dapperTest.TestIsTableEmpty, _jsonConfigurationHelper.GetAppSettingInt("Iterations", 1000));
                _stopwatchHelper.Timer(_dapperTest.TestIsTableExists, _jsonConfigurationHelper.GetAppSettingInt("Iterations", 1000));
                //_stopwatchHelper.Timer(_dapperTest.TestByPersonWithUnitWork, _jsonConfigurationHelper.GetAppSettingInt("Iterations", 1000));
                IDapperConnectionProvider _dapperConnectionProvider = service.GetRequiredService<IDapperConnectionProvider>();
                _dapperConnectionProvider.Dispose();
            }
            catch (Exception ex)
            {
                _loggerHelper.LogError(ex.Message, ex);
            }
            finally
            {
                //Console.ReadLine();
                _systemHelper.CloseProgram(_jsonConfigurationHelper.GetAppSettingInt("SleepTime", 5));
            }
        }
    }
}