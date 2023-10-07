using Dapper;
using DataAccess.Data;
using DataAccess.Data.IData;
using DataAccess.Repositories.IRepository;
using Models.DAO.TestDatabase;
using Utilities.Helper.IHelper;


namespace DataAccess.Repositories
{
    public class TestCardRepository : Repository<TestCard>, ITestCardRepository
    {
        private readonly IDapperConnectionProvider _dapperProvider;
        private readonly ILoggerHelper _loggerHelper;


        public TestCardRepository(IDapperConnectionProvider dapperProvider, ILoggerHelper loggerHelper) : base(dapperProvider, loggerHelper)
        {
            _dapperProvider = dapperProvider;
            _loggerHelper = loggerHelper;
        }
    }
}
