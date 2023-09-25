using Dapper;
using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories;
using System.Data.SqlClient;
using Utilities.Helper;
using Models.DAO.TestDatabase;
using DataAccess.Data;

namespace DataAccess.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly DapperConnectionProvider _dapperProvider;


        public PersonRepository(DapperConnectionProvider dapperProvider) : base(dapperProvider)
        {
            _dapperProvider = dapperProvider;
        }

        /// <summary>
        /// The method GetTake() add new for hide that base method
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        //public new List<Person> GetTake(int take)
        //{
        //    return _dapperProvider.Connect().Query<Person>($"SELECT TOP {take} * FROM Person").ToList();
        //}

        /// <summary>
        /// The method GetTakeReverse() add new for hide that base method
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        //public new List<Person> GetTakeReverse(int take)
        //{
        //    return _dapperProvider.Connect().Query<Person>($"SELECT TOP {take} * FROM Person ORDER BY Id DESC").ToList();
        //}

        public List<Person> GetSkip(int skip)
        {
            return _dapperProvider.Connect().Query<Person>($"SELECT * FROM Person ORDER BY Id ASC OFFSET {skip} ROWS").ToList();
        }

        public List<Person> GetSkipReverse(int skip)
        {
            return _dapperProvider.Connect().Query<Person>($"SELECT * FROM Person ORDER BY Id DESC OFFSET {skip} ROWS").ToList();
        }

        public List<Person> GetTakeSkip(int take, int skip)
        {
            return _dapperProvider.Connect().Query<Person>(
                $"SELECT * FROM Person ORDER BY Id ASC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }

        public List<Person> GetTakeSkipReverse(int take, int skip)
        {
            return _dapperProvider.Connect().Query<Person>(
                $"SELECT * FROM Person ORDER BY Id DESC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }
    }
}
