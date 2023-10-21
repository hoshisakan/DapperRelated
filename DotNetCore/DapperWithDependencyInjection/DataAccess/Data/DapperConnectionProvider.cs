using DataAccess.Data.IData;
using DataAccess.Repositories;
using System.Data;
using Utilities.Helper.IHelper;

namespace DataAccess.Data
{
    public class DapperConnectionProvider : IDapperConnectionProvider
    {
        private readonly ILoggerHelper _loggerHelper;
        //private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        private IDbConnection? _connection;
        private bool _disposed;


        public DapperConnectionProvider(ILoggerHelper loggerHelper, string conectionString)
        {
            _loggerHelper = loggerHelper;
            _connectionString = conectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException("Connection string is null or empty");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    /// If use _connection.State, then it will get connection state from connection pool
                    _connection?.Dispose();
                    _loggerHelper.LogDebug("Connection is disposed.", nameof(UnitWork), nameof(Dispose));

                    _connection?.Close();
                    _loggerHelper.LogDebug("Connection is closed.", nameof(UnitWork), nameof(Dispose));

                    _connection = null;
                    _loggerHelper.LogDebug("Connection object is set null.", nameof(UnitWork), nameof(Dispose));
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Create a new connection to database with connection string
        /// </summary>
        /// <returns></returns>
        //public IDbConnection Connect()
        //    => new System.Data.SqlClient.SqlConnection(_connectionString);

        public IDbConnection Connect()
        {
            _loggerHelper.LogDebug("Connection is created.", nameof(UnitWork), nameof(Connect));

            this._connection = new System.Data.SqlClient.SqlConnection(_connectionString);

            return this._connection;
        }
    }
}
