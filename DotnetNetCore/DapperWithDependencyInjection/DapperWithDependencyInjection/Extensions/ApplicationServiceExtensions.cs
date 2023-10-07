using DapperWithDependencyInjection.Test.ITest;
using DapperWithDependencyInjection.Test;
using DataAccess.Data;
using DataAccess.Repositories.IRepository;
using DataAccess.Repositories;
using DataAccess.Data.IData;
using Utilities.Helper;
using Utilities.Helper.IHelper;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DapperWithDependencyInjection.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddLazyResolution();

            services.AddSingleton<IJsonConfigurationHelper, JsonConfigurationHelper>();

            services.AddSingleton<IJsonHelper, JsonHelper>();

            services.AddSingleton<IFileHelper, FileHelper>();

            services.AddSingleton<ISystemHelper, SystemHelper>();

            services.AddSingleton<IStopwatchHelper, StopwatchHelper>();

            services.AddSingleton<IDateTimeHelper, DateTimeHelper>();

            services.AddSingleton<ILoggerHelper, LoggerHelper>();

            ILoggerHelper _loggerHelper = services.BuildServiceProvider().GetRequiredService<ILoggerHelper>();

            IJsonConfigurationHelper _jsonConfigurationHelper = services.BuildServiceProvider().GetRequiredService<IJsonConfigurationHelper>();

            services.AddSingleton<IDapperConnectionProvider>(
                new DapperConnectionProvider(_loggerHelper, _jsonConfigurationHelper.GetConnectionString("SelfConnection"))
            );

            services.AddScoped<IUnitWork, UnitWork>();

            services.AddScoped<IDapperTest, DapperTest>();

            return services;
        }
    }
}
