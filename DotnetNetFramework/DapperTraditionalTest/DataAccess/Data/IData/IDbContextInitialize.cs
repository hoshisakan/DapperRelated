using System.Data.SqlClient;

namespace DataAccess.Data.IData
{
    public interface IDbContextInitialize
    {
        SqlConnection Initialize();
    }
}
