using DataAccess.Repositories;
using DataAccess.Repositories.IRepositories;
using DataAccess.Repository.IRepository;
using System.Data.SqlClient;

namespace DataAccess.Repository
{
    public class UnitWork : IUnitWork
    {
        private readonly SqlConnection cnn;
        public ITestCardRepository TestCardRepository { get; private set; }
        public IPersonRepository PersonRepository { get; private set; }


        public UnitWork(SqlConnection cnn)
        {
            this.cnn = cnn;
            TestCardRepository = new TestCardRepository(this.cnn);
            PersonRepository = new PersonRepository(this.cnn);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
