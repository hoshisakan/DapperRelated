using DataAccess.Repositories.IRepository;
using Models.DAO.TestDatabase;
using Models.DataModel;

namespace DataAccess.Repositories.IRepositories
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
