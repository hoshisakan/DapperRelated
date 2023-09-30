using DapperWithDependencyInjection.Test.ITest;
using DapperWithDependencyInjection.Test;
using DataAccess.Data;
using DataAccess.Repositories.IRepository;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Data.IData;
using Utilities.Helper;


namespace DapperWithDependencyInjection.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //services.AddSingleton<IDapperConnectionProvider>(new DapperConnectionProvider(config));

            services.AddSingleton<IDapperConnectionProvider>(
                new DapperConnectionProvider(config, JsonConfigurationHelper.GetConnectionString("SelfConnection"))
            );

            services.AddSingleton<IUnitWork, UnitWork>();

            services.AddTransient<IDapperTest, DapperTest>();

            return services;
        }
    }
}
