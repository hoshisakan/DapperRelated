using DapperWithDependencyInjection.Test;
using Utilities.Helper;

using System.Diagnostics;

namespace DapperWithDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = XMLConfigurationHelper.GetXMLConnectionStringConfigurationValue("SelfConnection");

                DapperTest dapperTest = new DapperTest(connectionString);

                Stopwatch s = new Stopwatch();
                /// Execute 1000 times for each method
                //s.Timer(() => dapperTest.TestByCardWithUnitWork(), 1000);

                s.Timer(() => dapperTest.TestSqlRaw());
                //s.Timer(() => dapperTest.TestByCardWithUnitWork());
            }
            catch (Exception ex)
            {
                DebugHelper.ReadItemsOutputRawText(ex.Message, "Main", DateTime.Now.ToString("yyyyMMdd"));
            }
        }
    }
}