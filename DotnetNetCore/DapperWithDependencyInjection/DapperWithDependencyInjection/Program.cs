using Utilities.Helper;
using DapperWithDependencyInjection.Extensions;
using DapperWithDependencyInjection.Test.ITest;

using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Utilities.Enums;


namespace DapperWithDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /// Build service collection
                ServiceCollection services = new ServiceCollection();

                /// Use dapper
                ConfigurationBuilder? configuraion = JsonConfigurationHelper.BuildJsonConfiguration("appsettings.json");

                /// Add configuration to service collection
                services.AddSingleton<IConfiguration>(configuraion.Build());

                /// Get instance of IConfiguration interface from service provider
                IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>() ?? throw new Exception("IConfiguration interace is null.");

                /// Add application services to service collection
                services.AddApplicationServices(configuration);

                /// Get instance of IDapperTest interface from service provider
                /// Method 1: Get instance of DapperTest class from service provider through IDapperTest interface
                IDapperTest? dapperTest = services.BuildServiceProvider().GetService<IDapperTest>() ?? throw new Exception("IDapperTest interace is null.");
                /// Method 2: New an instance of DapperTest class and pass IUnitWork to constructor
                //IDapperTest? dapperTest = new DapperTest(services.BuildServiceProvider().GetService<IUnitWork>());

                Stopwatch s = new Stopwatch();
                /// Execute 1000 times for each method
                //s.Timer(() => dapperTest.TestByCardWithUnitWork(), 1000);
                //s.Timer(() => dapperTest.TestSqlRaw());
                //s.Timer(() => dapperTest.TestByCardWithUnitWork());
                s.Timer(() => dapperTest.TestIsTableExists());
                s.Timer(() => dapperTest.TestTakeRelatedMethods());
                s.Timer(() => dapperTest.TestSkipRelatedMethods());
                s.Timer(() => dapperTest.TestTakeAndSkipRelatedMethods());
                s.Timer(() => dapperTest.TestWriteMessageToLogFile());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(LogLevelEnum.ERROR, ex.ToString());
            }
            finally
            {
                //Console.ReadLine();
                SystemHelper.CloseProgram(int.Parse(JsonConfigurationHelper.GetAppSettingString("SleepTime")));
            }
        }
    }
}