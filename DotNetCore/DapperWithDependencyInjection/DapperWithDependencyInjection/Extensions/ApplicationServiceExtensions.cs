using DapperWithDependencyInjection.Test;
using DapperWithDependencyInjection.Test.ITest;
using DataAccess.Data;
using DataAccess.Data.IData;
using DataAccess.Repositories;
using DataAccess.Repositories.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Utilities.Helper;
using Utilities.Helper.IHelper;


namespace DapperWithDependencyInjection.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            /// Add lazy resolution for relsove circular dependency, which is defined in Extensions/LazyResolutionMiddlewareExtensions.cs
            services.AddLazyResolution();

            /// Add application services, which are defined in Extensions/ApplicationServiceExtensions.cs
            services.AddSingleton<IJsonConfigurationHelper, JsonConfigurationHelper>();

            services.AddSingleton<IJsonHelper, JsonHelper>();

            services.AddSingleton<IFileHelper, FileHelper>();

            services.AddSingleton<ISystemHelper, SystemHelper>();

            //services.AddSingleton<IStopwatchHelper, StopwatchHelper>();

            services.AddSingleton<IDateTimeHelper, DateTimeHelper>();

            services.AddSingleton<ILoggerHelper, LoggerHelper>();

            /// Build service provider
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            /// Create service scope
            IServiceScope scope = serviceProvider.CreateScope();

            /// Use service scope to get service provider
            IServiceProvider service = scope.ServiceProvider;

            /// Get services from service provider of service scope
            ILoggerHelper _loggerHelper = service.GetRequiredService<ILoggerHelper>();

            /// Get services from service provider of service scope
            IJsonConfigurationHelper _jsonConfigurationHelper = service.GetRequiredService<IJsonConfigurationHelper>();

            Stopwatch sw = new Stopwatch();

            services.AddSingleton<IStopwatchHelper>(new StopwatchHelper(_loggerHelper, sw));

            string connectionStringKeyName = "SelfConnection";

            services.AddSingleton<IDapperConnectionProvider>(
                new DapperConnectionProvider(_loggerHelper, _jsonConfigurationHelper.GetConnectionString(connectionStringKeyName))
            // new DapperConnectionProvider(
            //     _loggerHelper,
            //     config.GetConnectionString(connectionStringKeyName)
            //     ?? throw new Exception($"The {connectionStringKeyName} doesn't exists in ConnecitonStrings.")
            //)
            );

            services.AddScoped<IUnitWork, UnitWork>();

            services.AddScoped<IDapperTest, DapperTest>();

            return services;
        }
    }
}
