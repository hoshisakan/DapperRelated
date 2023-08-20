using Models.Model;

namespace DataAccess.Repository.IRepository
{
    public interface ICardRepository : IRepository<Card>
    {
        int Add(Card card);
        int Update(Card card);
        int Delete(Card card);
        int Delete(int id);
    }
}
