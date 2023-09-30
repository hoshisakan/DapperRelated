using Models.DAO.NEC.Test;


namespace DataAccess.Repositories.IRepositories
{
    public interface IAPLog_Repository : IRepository<APLog>
    {
        APLog GetRecordByNameAndLogTime(string name, string logTime);
        APLog GetRecordByNameAndLogTime(string name, DateTime logTime);
        bool IsExistByNameAndLogTime(string name, string logTime);
    }
}
