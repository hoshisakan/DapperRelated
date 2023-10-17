using DataAccess.Repositories.IRepository;
using Models.Entity.NEC.Test;


namespace DataAccess.Repositories.IRepositories
{
    public interface IAPLog_Repository : IRepository<APLog>
    {
        new int Add(APLog entity);
        APLog GetRecordByNameAndLogTime(string name, string logTime);
        APLog GetRecordByNameAndLogTime(string name, DateTime logTime);
        bool IsExistByNameAndLogTime(string name, string logTime);
    }
}
