using Models.Model;

namespace DataAccess.Repository.IRepository
{
    public interface ICardRepository : IRepository<Card>
    {
        void ReadAll(List<Card> cards);
        void ReadFirst(Card card);
    }
}
