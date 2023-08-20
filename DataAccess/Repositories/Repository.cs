using Dapper;
using DataAccess.Repository.IRepository;
using System.Data.SqlClient;

namespace DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly SqlConnection cnn;

    public Repository(SqlConnection cnn)
    {
        this.cnn = cnn;
    }

    public List<T> GetAll()
    {
        return this.cnn.Query<T>($"SELECT * FROM {typeof(T).Name}").ToList();
    }

    public T GetFirst()
    {
        return this.cnn.QueryFirstOrDefault<T>($"SELECT TOP 1 FROM {typeof(T).Name}");
    }

    public T GetById(int id)
    {
        return this.cnn.QueryFirstOrDefault<T>($"SELECT * FROM {typeof(T).Name} WHERE Id = @Id", new { Id = id });
    }
}
