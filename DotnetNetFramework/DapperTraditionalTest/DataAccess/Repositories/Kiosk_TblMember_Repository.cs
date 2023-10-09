using DataAccess.Data.IData;
using DataAccess.Repositories.IRepositories;
using Models.DAO.NEC.Test;
using Utilities.Helper.IHelper;

namespace DataAccess.Repositories
{
    public class Kiosk_TblMember_Repository : Repository<Kiosk_tblMember>, IKiosk_TblMember_Repository
    {
        private readonly IDapperConnectionProvider _dapperProvider;
        private readonly ILoggerHelper _loggerHelper;

        public Kiosk_TblMember_Repository(IDapperConnectionProvider dapperProvider, ILoggerHelper loggerHelper) : base(dapperProvider, loggerHelper)
        {
            _dapperProvider = dapperProvider;
            _loggerHelper = loggerHelper;
        }
    }
}
