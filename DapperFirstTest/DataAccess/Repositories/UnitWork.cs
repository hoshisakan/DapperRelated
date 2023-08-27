using DataAccess.Repository.IRepository;
using System.Data.SqlClient;

namespace DataAccess.Repository
{
    public class UnitWork : IUnitWork
    {
        private readonly SqlConnection cnn;
        public ICardRepository CardRepository { get; private set; }


        public UnitWork(SqlConnection cnn)
        {
            this.cnn = cnn;
            CardRepository = new CardRepository(this.cnn);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
