using DataAccess.Data.IData;

using System.Data.SqlClient;


namespace DataAccess.Data
{
    public class DbContextInitialize : IDbContextInitialize
    {
        private readonly string connectionString;

        public DbContextInitialize(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection Initialize()
        {
            SqlConnection cnn = new();
            try
            {
                cnn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
            return cnn;
        }
    }
}
