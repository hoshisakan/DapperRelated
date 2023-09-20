using DataAccess.Repositories.IRepositories;
using Models.DAO.NEC.Test;
using System;

namespace DataAccess.Repositories.IRepositories
{
    public interface IAPLogRepository : IRepository<APLog>
    {
        APLog GetRecordByNameAndLogTime(string name, string logTime);
        APLog GetRecordByNameAndLogTime(string name, DateTime logTime);
        bool IsExistByNameAndLogTime(string name, string logTime);
    }
}
