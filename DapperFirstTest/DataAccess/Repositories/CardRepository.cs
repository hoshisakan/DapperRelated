using Dapper;
using DataAccess.Repository.IRepository;
using Models.Model;
using System.Data.SqlClient;


namespace DataAccess.Repository
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(SqlConnection cnn) : base(cnn)
        {
            this.cnn = cnn;
        }

        private readonly SqlConnection cnn;

        public void ReadAll(List<Card> cards)
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

        public void ReadFirst(Card card)
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

        public List<Card> GetTake(int take)
        {
            return this.cnn.Query<Card>($"SELECT TOP {take} * FROM Card").ToList();
        }

        public List<Card> GetTakeReverse(int take)
        {
            return this.cnn.Query<Card>($"SELECT TOP {take} * FROM Card ORDER BY Id DESC").ToList();
        }

        public List<Card> GetSkip(int skip)
        {
            return this.cnn.Query<Card>($"SELECT * FROM Card ORDER BY Id ASC OFFSET {skip} ROWS").ToList();
        }

        public List<Card> GetSkipReverse(int skip)
        {
            return this.cnn.Query<Card>($"SELECT * FROM Card ORDER BY Id DESC OFFSET {skip} ROWS").ToList();
        }

        public List<Card> GetTakeSkip(int take, int skip)
        {
            return this.cnn.Query<Card>(
                $"SELECT * FROM Card ORDER BY Id ASC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }

        public List<Card> GetTakeSkipReverse(int take, int skip)
        {
            return this.cnn.Query<Card>(
                $"SELECT * FROM Card ORDER BY Id DESC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }
    }
}
