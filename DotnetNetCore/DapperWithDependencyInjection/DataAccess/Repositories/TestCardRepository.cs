using Dapper;
using DataAccess.Data;
using DataAccess.Repositories.IRepository;
using Models.DAO.TestDatabase;
using System.Data.SqlClient;


namespace DataAccess.Repositories
{
    public class TestCardRepository : Repository<TestCard>, ITestCardRepository
    {
        private readonly DapperConnectionProvider _dapperProvider;


        public TestCardRepository(DapperConnectionProvider dapperProvider) : base(dapperProvider)
        {
            _dapperProvider = dapperProvider;
        }

        //public List<TestCard> GetTake(int take)
        //{
        //    return _dapperProvider.Connect().Query<TestCard>($"SELECT TOP {take} * FROM TestCard").ToList();
        //}

        //public List<TestCard> GetTakeReverse(int take)
        //{
        //    var attributes = typeof(TestCard).GetCustomAttributes(typeof(KeyAttribute), true);
        //    Console.WriteLine(attributes[0].ToString());
        //    return _dapperProvider.Connect().Query<TestCard>($"SELECT TOP {take} * FROM TestCard ORDER BY {attributes[0].ToString()} DESC").ToList();
        //    //return _dapperProvider.Connect().Query<TestCard>($"SELECT TOP {take} * FROM TestCard ORDER BY Id DESC").ToList();
        //}

        /// <summary>
        /// List<T> GetSkip<T>(int skip) maybe try this later, 
        /// but exists a problem with the sql query order by primary key, beacuse the primary key is everyone different name
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<TestCard> GetSkip(int skip)
        {
            return _dapperProvider.Connect().Query<TestCard>($"SELECT * FROM TestCard ORDER BY Id ASC OFFSET {skip} ROWS").ToList();
        }

        public List<TestCard> GetSkipReverse(int skip)
        {
            return _dapperProvider.Connect().Query<TestCard>($"SELECT * FROM TestCard ORDER BY Id DESC OFFSET {skip} ROWS").ToList();
        }

        public List<TestCard> GetTakeSkip(int take, int skip)
        {
            return _dapperProvider.Connect().Query<TestCard>(
                $"SELECT * FROM TestCard ORDER BY Id ASC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }

        public List<TestCard> GetTakeSkipReverse(int take, int skip)
        {
            return _dapperProvider.Connect().Query<TestCard>(
                $"SELECT * FROM TestCard ORDER BY Id DESC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }
    }
}
