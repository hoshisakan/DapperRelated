using DataAccess.Repositories.IRepository;
using Models.DAO.TestDatabase;
using Models.DataModel;

namespace DataAccess.Repositories.IRepositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        //public List<Person> GetTake(int take);
        //public List<Person> GetTakeReverse(int take);
        public List<Person> GetSkip(int skip);
        public List<Person> GetSkipReverse(int skip);
        public List<Person> GetTakeSkip(int take, int skip);
        public List<Person> GetTakeSkipReverse(int take, int skip);
    }
}
