using Dapper;
using DataAccess.Repositories.IRepository;
using Models.DataModel;
using System.Data.SqlClient;


namespace DataAccess.Repositories
{
    public class TestCardRepository : Repository<TestCard>, ITestCardRepository
    {
        public TestCardRepository(SqlConnection cnn) : base(cnn)
        {
            this.cnn = cnn;
        }

        private readonly SqlConnection cnn;

        //public List<TestCard> GetTake(int take)
        //{
        //    return this.cnn.Query<TestCard>($"SELECT TOP {take} * FROM TestCard").ToList();
        //}

        //public List<TestCard> GetTakeReverse(int take)
        //{
        //    var attributes = typeof(TestCard).GetCustomAttributes(typeof(KeyAttribute), true);
        //    Console.WriteLine(attributes[0].ToString());
        //    return this.cnn.Query<TestCard>($"SELECT TOP {take} * FROM TestCard ORDER BY {attributes[0].ToString()} DESC").ToList();
        //    //return this.cnn.Query<TestCard>($"SELECT TOP {take} * FROM TestCard ORDER BY Id DESC").ToList();
        //}

        /// <summary>
        /// List<T> GetSkip<T>(int skip) maybe try this later, 
        /// but exists a problem with the sql query order by primary key, beacuse the primary key is everyone different name
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<TestCard> GetSkip(int skip)
        {
            return this.cnn.Query<TestCard>($"SELECT * FROM TestCard ORDER BY Id ASC OFFSET {skip} ROWS").ToList();
        }

        public List<TestCard> GetSkipReverse(int skip)
        {
            return this.cnn.Query<TestCard>($"SELECT * FROM TestCard ORDER BY Id DESC OFFSET {skip} ROWS").ToList();
        }

        public List<TestCard> GetTakeSkip(int take, int skip)
        {
            return this.cnn.Query<TestCard>(
                $"SELECT * FROM TestCard ORDER BY Id ASC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }

        public List<TestCard> GetTakeSkipReverse(int take, int skip)
        {
            return this.cnn.Query<TestCard>(
                $"SELECT * FROM TestCard ORDER BY Id DESC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }

        public void ReadAll(List<TestCard> cards)
        {
            if (cards != null)
            {
                foreach (var card in cards)
                {
                    Console.WriteLine($"Id: {card.Id},Name: {card.Name},Description: {card.Description}");
                }
            }
            else
            {
                Console.WriteLine("No data");
            }
        }

        public void ReadFirst(TestCard card)
        {
            if (card != null)
            {
                Console.WriteLine($"Id: {card.Id},Name: {card.Name},Description: {card.Description}");
            }
            else
            {
                Console.WriteLine("No data");
            }
        }
    }
}
