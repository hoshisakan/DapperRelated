// See https://aka.ms/new-console-template for more information

using DapperFirstTest.Test;
using DataAccess.Helper;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

Dictionary<string, string> connectionStringDict = new Dictionary<string, string>()
{
    {"localhost", "Server=localhost;User ID=sa;Password=2wsx1qaz`;Database=TestDatabase;Encrypt=false"}
};

try
{
    DapperTest dapperTest = new DapperTest(connectionStringDict["localhost"]);

    Stopwatch s = new Stopwatch();
    /// Execute 1000 times for each method
    //s.Timer(() => dapperTest.TestByCardWithUnitWork(), 1000);

    s.Timer(() => dapperTest.TestByCardWithUnitWork());
}
catch (Exception ex)
{
    Console.WriteLine($"Message: {ex.Message}\nStacktrace: {ex.StackTrace}");
}