

namespace DataAccess.Repositories.IRepositories
{
    public interface IUnitWork
    {
        IKiosk_Parameter_Repository Kiosk_Parameter_Repository { get; }
        IFileTable_Repository FileTable_Repository { get; }
        IAPLog_Repository APLog_Repository { get; }
        IKiosk_TblMember_Repository Kiosk_TblMember_Repository { get; }
    }
}
