using System.Data;

namespace DataAccess.Data.IData
{
    public interface IDapperConnectionProvider : IDisposable
    {
        public IDbConnection Connect();
        public void Dispose(bool disposing);
    }
}
