using DataAccess.Data.IData;
using DataAccess.Repositories.IRepositories;
using Utilities.Helper.IHelper;

namespace DataAccess.Repositories
{
    public class UnitWork : IUnitWork
    {
        private readonly IDapperConnectionProvider _dapperProvider;
        private ILoggerHelper _loggerHelper;
        public IKiosk_Parameter_Repository Kiosk_Parameter_Repository { get; }
        public IFileTable_Repository FileTable_Repository { get; }
        public IAPLog_Repository APLog_Repository { get; }
        public IKiosk_TblMember_Repository Kiosk_TblMember_Repository { get; }


        public UnitWork(IDapperConnectionProvider dapperProvider, ILoggerHelper loggerHelper)
        {
            _dapperProvider = dapperProvider;
            _loggerHelper = loggerHelper;
            Kiosk_Parameter_Repository = new Kiosk_Parameter_Repository(_dapperProvider, _loggerHelper);
            FileTable_Repository = new FileTable_Repository(_dapperProvider, _loggerHelper);
            APLog_Repository = new APLogRepository(_dapperProvider, _loggerHelper);
            Kiosk_TblMember_Repository = new Kiosk_TblMember_Repository(_dapperProvider, _loggerHelper);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
