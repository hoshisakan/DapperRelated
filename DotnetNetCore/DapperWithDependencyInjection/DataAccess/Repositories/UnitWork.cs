using DataAccess.Data;
using DataAccess.Repositories;
using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories.IRepository;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class UnitWork : IUnitWork
    {
        //private readonly SqlConnection cnn;
        private readonly DapperConnectionProvider _dapperProvider;
        public ITestCardRepository TestCardRepository { get; private set; }
        public IPersonRepository PersonRepository { get; private set; }


        public UnitWork(DapperConnectionProvider dapperProvider)
        {
            _dapperProvider = dapperProvider;
            TestCardRepository = new TestCardRepository(_dapperProvider);
            PersonRepository = new PersonRepository(_dapperProvider);
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
