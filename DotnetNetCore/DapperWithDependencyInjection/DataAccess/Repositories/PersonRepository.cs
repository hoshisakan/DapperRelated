using Dapper;
using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories;
using System.Data.SqlClient;
using Utilities.Helper;
using Models.DAO.TestDatabase;
using DataAccess.Data;
using DataAccess.Data.IData;
using Microsoft.Extensions.Logging;
using Utilities.Helper.IHelper;

namespace DataAccess.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly IDapperConnectionProvider _dapperProvider;
        private readonly ILoggerHelper _loggerHelper;


        public PersonRepository(IDapperConnectionProvider dapperProvider, ILoggerHelper loggerHelper) : base(dapperProvider, loggerHelper)
        {
            _dapperProvider = dapperProvider;
            _loggerHelper = loggerHelper;
        }
    }
}
