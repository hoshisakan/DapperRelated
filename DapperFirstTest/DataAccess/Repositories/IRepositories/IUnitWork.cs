using DataAccess.Repositories.IRepositories;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitWork
    {
        ITestCardRepository TestCardRepository { get; }
        IPersonRepository PersonRepository { get; }
    }
}
