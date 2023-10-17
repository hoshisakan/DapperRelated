using DataAccess.Repositories.IRepository;
using Models.Entity.TestDatabase;
using Models.LoggerRelated;

namespace DataAccess.Repositories.IRepositories
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
