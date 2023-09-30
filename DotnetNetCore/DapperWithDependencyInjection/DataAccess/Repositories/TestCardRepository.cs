using Dapper;
using DataAccess.Data;
using DataAccess.Data.IData;
using DataAccess.Repositories.IRepository;
using Models.DAO.TestDatabase;
using System.Data.SqlClient;


namespace DataAccess.Repositories
{
    public class TestCardRepository : Repository<TestCard>, ITestCardRepository
    {
        private readonly IDapperConnectionProvider _dapperProvider;


        public TestCardRepository(IDapperConnectionProvider dapperProvider) : base(dapperProvider)
        {
            _dapperProvider = dapperProvider;
        }
    }
}
