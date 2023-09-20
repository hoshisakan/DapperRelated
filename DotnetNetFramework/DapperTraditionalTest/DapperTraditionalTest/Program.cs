using Utilities.Helper;
using DapperTraditionalTest.Test;

namespace DataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString;

            try
            {
                connectionString = ConfigurationHelper.GetConnectionString("DefaultConnection") ?? string.Empty;

                Console.WriteLine(connectionString);

                QueryTest queryTest = new QueryTest(connectionString);
                //queryTest.TestKiosk_Parameter();
                //queryTest.TestFileTable();
                queryTest.TestAPLog_Parameter();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}\nStackTrace: {ex.StackTrace}");
                Environment.Exit(0);
            }
        }
    }
}