using Models.Model;

namespace DataAccess.Repository.IRepository
{
    public interface ICardRepository : IRepository<Card>
    {
        public List<Card> GetTake(int take);
        public List<Card> GetTakeReverse(int take);
        public List<Card> GetSkip(int skip);
        public List<Card> GetSkipReverse(int skip);
        public List<Card> GetTakeSkip(int take, int skip);
        public List<Card> GetTakeSkipReverse(int take, int skip);
        void ReadAll(List<Card> cards);
        void ReadFirst(Card card);
    }
}
