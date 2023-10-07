using DataAccess.Data.IData;
using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories.IRepository;
using Utilities.Helper;
using Utilities.Enums;
using Utilities.Helper.IHelper;

namespace DataAccess.Repositories
{
    public class UnitWork : IUnitWork
    {
        private readonly IDapperConnectionProvider _dapperProvider;
        public ITestCardRepository TestCardRepository { get; private set; }
        public IPersonRepository PersonRepository { get; private set; }
        public ILoggerHelper _loggerHelper { get; private set; }


        public UnitWork(IDapperConnectionProvider dapperProvider, ILoggerHelper loggerHelper)
        {
            _dapperProvider = dapperProvider;
            _loggerHelper = loggerHelper;
            TestCardRepository = new TestCardRepository(_dapperProvider, _loggerHelper);
            PersonRepository = new PersonRepository(_dapperProvider, _loggerHelper);
        }

        //~UnitWork()
        //{
        //    LogHelper.WriteLog(LogLevelEnum.INFO, nameof(UnitWork), nameof(UnitWork), "UnitWork is disposed.");
        //    _dapperProvider.Dispose(true);
        //}

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
