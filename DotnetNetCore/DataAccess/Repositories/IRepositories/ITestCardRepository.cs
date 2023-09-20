using Models.DataModel;

namespace DataAccess.Repositories.IRepository
{
    public interface ITestCardRepository : IRepository<TestCard>
    {
        //public List<TestCard> GetTake(int take);
        //public List<TestCard> GetTakeReverse(int take);
        public List<TestCard> GetSkip(int skip);
        public List<TestCard> GetSkipReverse(int skip);
        public List<TestCard> GetTakeSkip(int take, int skip);
        public List<TestCard> GetTakeSkipReverse(int take, int skip);
        public void ReadAll(List<TestCard> cards);
        public void ReadFirst(TestCard card);
    }
}
