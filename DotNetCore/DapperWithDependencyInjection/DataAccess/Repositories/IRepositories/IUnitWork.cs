using DataAccess.Repositories.IRepositories;

namespace DataAccess.Repositories.IRepository
{
    public interface IUnitWork
    {
        ITestCardRepository TestCardRepository { get; }
        IPersonRepository PersonRepository { get; }
    }
}
