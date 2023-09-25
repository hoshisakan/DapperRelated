using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using Utilities.Helper;

namespace DataAccess.Data
{
    public class DapperConnectionProvider
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        //public DapperConnectionProvider()
        //{
        //    _connectionString = XMLConfigurationHelper.GetXMLConnectionStringConfigurationValue("SelfConnection");

        //    if (string.IsNullOrEmpty(_connectionString))
        //    {
        //        throw new ArgumentNullException("Connection string is null or empty");
        //    }
        //}

        public DapperConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SelfConnection");

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException("Connection string is null or empty");
            }
        }

        public IDbConnection Connect()
            //=> new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
            => new System.Data.SqlClient.SqlConnection(_connectionString);
    }
}
