using DataAccess.Data.IData;
using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories.IRepository;
using Utilities.Helper.IHelper;

namespace DataAccess.Repositories
{
    public class UnitWork : IUnitWork
    {
        private readonly IDapperConnectionProvider _dapperProvider;
        private ILoggerHelper _loggerHelper;
        public ITestCardRepository TestCardRepository { get; private set; }
        public IPersonRepository PersonRepository { get; private set; }


        public UnitWork(IDapperConnectionProvider dapperProvider, ILoggerHelper loggerHelper)
        {
            _dapperProvider = dapperProvider;
            _loggerHelper = loggerHelper;
            TestCardRepository = new TestCardRepository(_dapperProvider, _loggerHelper);
            PersonRepository = new PersonRepository(_dapperProvider, _loggerHelper);
        }

        //~UnitWork()
        //{
        //    _loggerHelper.LogDebug("UnitWork is disposed.", nameof(UnitWork), "~UnitWork");
        //    _dapperProvider.Dispose(true);
        //}

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
