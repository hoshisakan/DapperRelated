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

        //public int Add(Card card)
        //{
        //    int result;
        //    string query = "INSERT INTO Card " +
        //            "" +
        //            "(Name, Description, Attack, HealthPoint, Defense, Cost) " +
        //            "VALUES " +
        //            "(@Name, @Description, @Attack, @HealthPoint, @Defense, @Cost)"
        //        ;

        //    /// Method 1
        //    //result = this.cnn.Execute(query, card);
        //    //result = this.cnn.Execute(query, new
        //    //{
        //    //    Name = card.Name,
        //    //    Description = card.Description,
        //    //    Attack = card.Attack,
        //    //    HealthPoint = card.HealthPoint,
        //    //    Defense = card.Defense,
        //    //    Cost = card.Cost
        //    //});
        //    /// Method 2
        //    result = this.cnn.QueryFirstOrDefault<int>(query, card);
        //    //result = this.cnn.QueryFirstOrDefault<int>(query, new
        //    //{
        //    //    Name = card.Name,
        //    //    Description = card.Description,
        //    //    Attack = card.Attack,
        //    //    HealthPoint = card.HealthPoint,
        //    //    Defense = card.Defense,
        //    //    Cost = card.Cost
        //    //});
        //    //result = this.cnn.QueryFirstOrDefault<int>(query, new
        //    //{
        //    //    card.Name,
        //    //    card.Description,
        //    //    card.Attack,
        //    //    card.HealthPoint,
        //    //    card.Defense,
        //    //    card.Cost
        //    //});
        //    return result;
        //}

        //public int Update(Card card)
        //{
        //    int result;
        //    string query = "UPDATE Card " +
        //            "SET " +
        //            "Name = @Name, " +
        //            "Description = @Description, " +
        //            "Attack = @Attack, " +
        //            "HealthPoint = @HealthPoint, " +
        //            "Defense = @Defense, " +
        //            "Cost = @Cost " +
        //            "WHERE Id = @Id"
        //        ;
        //    this.cnn.
        //    result = this.cnn.Execute(query, card);
        //    return result;
        //}

        //public int Delete(Card card)
        //{
        //    int result;
        //    string query = "DELETE FROM Card WHERE Id = @Id";
        //    result = this.cnn.Execute(query, card);
        //    return result;
        //}

        //public int Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

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
    }
}
