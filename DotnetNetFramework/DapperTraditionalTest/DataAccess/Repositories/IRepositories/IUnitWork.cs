

namespace DataAccess.Repositories.IRepositories
{
    public interface IUnitWork
    {
        IKiosk_Parameter_Repository Kiosk_Parameter_Repository { get; }
        IFileTable_Repository FileTable_Repository { get; }
        IAPLogRepository APLog_Repository { get; }
    }
}
