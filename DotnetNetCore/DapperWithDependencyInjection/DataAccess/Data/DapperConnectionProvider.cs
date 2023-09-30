using DataAccess.Data.IData;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace DataAccess.Data
{
    public class DapperConnectionProvider : IDapperConnectionProvider
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public DapperConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;

            /// Use IConfiguration to get connection string from appsettings.json of json format file
            _connectionString = _configuration.GetConnectionString("SelfConnection");

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException("Connection string is null or empty");
            }
        }

        public DapperConnectionProvider(IConfiguration configuration, string conectionString)
        {
            _configuration = configuration;

            /// Use IConfiguration to get connection string from appsettings.json of json format file
            _connectionString = conectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException("Connection string is null or empty");
            }
        }

        /// <summary>
        /// Create a new connection to database with connection string
        /// </summary>
        /// <returns></returns>
        public IDbConnection Connect()
            => new System.Data.SqlClient.SqlConnection(_connectionString);
    }
}
