using DataAccess.Repositories.IRepositories;

using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class UnitWork : IUnitWork
    {
        private readonly SqlConnection cnn;
        public IKiosk_Parameter_Repository Kiosk_Parameter_Repository { get; }
        public IFileTable_Repository FileTable_Repository { get; }
        public IAPLog_Repository APLog_Repository { get; }
        public IKiosk_TblMember_Repository Kiosk_TblMember_Repository { get; }


        public UnitWork(SqlConnection cnn)
        {
            this.cnn = cnn;
            Kiosk_Parameter_Repository = new Kiosk_Parameter_Repository(this.cnn);
            FileTable_Repository = new FileTable_Repository(this.cnn);
            APLog_Repository = new APLogRepository(this.cnn);
            Kiosk_TblMember_Repository = new Kiosk_TblMember_Repository(this.cnn);
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
