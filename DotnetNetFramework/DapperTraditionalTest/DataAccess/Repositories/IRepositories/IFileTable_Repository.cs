using DataAccess.Repositories.IRepository;
using Models.DAO.NEC.Test;

namespace DataAccess.Repositories.IRepositories
{
    public interface IFileTable_Repository : IRepository<FileTable>
    {
        FileTable GetFirst(string file2, DateTime updateTime);
        FileTable GetFirst(string file2, string updateTime);
        bool IsExist(string file2, DateTime updateTime);
        bool IsExist(string file2, string updateTime);
        int Delete(string file2, string updateTime);
    }
}
