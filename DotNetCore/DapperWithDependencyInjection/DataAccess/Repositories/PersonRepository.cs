using DataAccess.Data.IData;
using DataAccess.Repositories.IRepositories;
using Models.Entity.TestDatabase;
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
