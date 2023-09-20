using Models.DAO.NEC.Test;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
