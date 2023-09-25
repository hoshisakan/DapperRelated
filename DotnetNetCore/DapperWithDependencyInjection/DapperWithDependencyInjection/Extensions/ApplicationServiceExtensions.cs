using DapperWithDependencyInjection.Test.ITest;
using DapperWithDependencyInjection.Test;
using DataAccess.Data;
using DataAccess.Repositories.IRepository;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperWithDependencyInjection.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<DapperConnectionProvider>();

            services.AddSingleton<IUnitWork, UnitWork>();

            services.AddTransient<IDapperTest, DapperTest>();
            

            return services;
        }
    }
}
