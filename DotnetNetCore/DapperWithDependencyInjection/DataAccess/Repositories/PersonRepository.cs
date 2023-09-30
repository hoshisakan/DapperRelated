using Dapper;
using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories;
using System.Data.SqlClient;
using Utilities.Helper;
using Models.DAO.TestDatabase;
using DataAccess.Data;
using DataAccess.Data.IData;

namespace DataAccess.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly IDapperConnectionProvider _dapperProvider;


        public PersonRepository(IDapperConnectionProvider dapperProvider) : base(dapperProvider)
        {
            _dapperProvider = dapperProvider;
        }
    }
}
