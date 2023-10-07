using Utilities.Helper;
using Utilities.Helper.IHelper;
using DapperWithDependencyInjection.Extensions;
using DapperWithDependencyInjection.Test.ITest;
using Models.DAO.TestDatabase;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace DapperWithDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Build service collection
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IJsonConfigurationHelper, JsonConfigurationHelper>();
            IJsonConfigurationHelper _jsonConfigurationHelper = services.BuildServiceProvider().GetRequiredService<IJsonConfigurationHelper>();

            ConfigurationBuilder? configuraion = _jsonConfigurationHelper.BuildJsonConfiguration("appsettings.json");
            //services.AddApplicationServices(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
            services.AddApplicationServices(configuraion.Build());
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IServiceScope scope = serviceProvider.CreateScope();

            IJsonHelper? _jsonHelper = scope.ServiceProvider.GetRequiredService<IJsonHelper>();
            IDateTimeHelper? _dateTimeHelper = scope.ServiceProvider.GetRequiredService<IDateTimeHelper>();
            IFileHelper? _fileHelper = scope.ServiceProvider.GetRequiredService<IFileHelper>();
            ILoggerHelper? _loggerHelper = scope.ServiceProvider.GetRequiredService<ILoggerHelper>();
            IDapperTest? _dapperTest = scope.ServiceProvider.GetRequiredService<IDapperTest>();
            ISystemHelper? _systemHelper = scope.ServiceProvider.GetRequiredService<ISystemHelper>();
            //IStopwatchHelper? _stopwatchHelper = scope.ServiceProvider.GetRequiredService<IStopwatchHelper>();

            try
            {
                string connectionString = _jsonConfigurationHelper.GetConnectionString("SelfConnection");
                Console.WriteLine(connectionString);

                TestCard testCard = new TestCard();
                testCard.Id = 1;
                testCard.Name = "TestCard";
                testCard.Description = "TestCardDescription";
                testCard.CreatedTime = DateTime.Now;
                testCard.Defense = 1;
                testCard.Attack = 1;
                testCard.HealthPoint = 1;

                string json = _jsonHelper.Serialize(testCard);

                Console.WriteLine(json);

                string currentDateTime = _dateTimeHelper.GetCurrentDateTimeString();

                Console.WriteLine(currentDateTime);

                //_fileHelper.ReadFile("appsettings.json");

                _loggerHelper.LogDebug("Connection string is: " + connectionString, nameof(Program), nameof(Main));

                //IConfigurationSection configurationSection = 

                //Stopwatch s = new Stopwatch();

                int methodExecutionTimes = _jsonConfigurationHelper.GetAppSettingInt("MethodExecutionTimes", 1);

                //_dapperTest.TestByCardWithUnitWork();
                _dapperTest.TestByPersonWithUnitWork();

                /// First get connection string and method execution times from appsettings.json
                /// Then use them to execute methods in DapperTest class
                //s.Timer(() => _dapperTest.TestByCardWithUnitWork(), methodExecutionTimes);
                //s.Timer(() => _dapperTest.TestSqlRaw(), methodExecutionTimes);
                //s.Timer(() => _dapperTest.TestByCardWithUnitWork(), methodExecutionTimes);
                //_stopwatchHelper.Timer(() => _dapperTest.TestIsTableExists(), methodExecutionTimes);
                //_stopwatchHelper.Timer(() => _dapperTest.TestTakeRelatedMethods(), methodExecutionTimes);
                //s.Timer(() => _dapperTest.TestSkipRelatedMethods(), methodExecutionTimes);
                //s.Timer(() => _dapperTest.TestTakeAndSkipRelatedMethods(), methodExecutionTimes);
                //s.Timer(() => _dapperTest.TestWriteMessageToLogFile());
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