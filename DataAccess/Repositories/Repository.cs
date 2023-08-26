using Dapper;
using DataAccess.Repository.IRepository;
using System.Data.SqlClient;
using System.Reflection;

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

    public T GetLast()
    {
        return this.cnn.QueryFirstOrDefault<T>($"SELECT TOP 1 FROM {typeof(T).Name} ORDER BY Id DESC");
    }

    public T GetById(int id)
    {
        return this.cnn.QueryFirstOrDefault<T>($"SELECT * FROM {typeof(T).Name} WHERE Id = @Id", new { Id = id });
    }

    /// <summary>
    /// Add a new entity to the database and return inserted query result code (0 = success, -1 = fail)
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public int Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        else
        {
            PropertyInfo[]? entityProperties = entity.GetType().GetProperties();

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains("Id")
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                where !v.Name.Contains("Id")
                select "@" + v.Name
            );

            string fields = allFields.Aggregate((x, y) => x + ", " + y);
            string values = allValues.Aggregate((x, y) => x + ", " + y);

            string query = $"INSERT INTO {typeof(T).Name} ({fields}) VALUES ({values})";
            int result = -1;

            //Console.WriteLine(query);

            /// Method 1 - Using Dapper StaticParameters to create the query(avoid SQL injection attack)
            result = this.cnn.QueryFirstOrDefault<int>(query, entity);

            /// Method 2 - Using Dapper DynamicParameters to create the query(avoid SQL injection attack)
            result = this.cnn.Execute(query, new
            {
                Name = entity.GetType()?.GetProperty("Name")?.GetValue(entity, null),
                Description = entity.GetType()?.GetProperty("Description")?.GetValue(entity, null),
                Attack = entity.GetType()?.GetProperty("Attack")?.GetValue(entity, null),
                HealthPoint = entity.GetType()?.GetProperty("HealthPoint")?.GetValue(entity, null),
                Defense = entity.GetType()?.GetProperty("Defense")?.GetValue(entity, null),
                Cost = entity.GetType()?.GetProperty("Cost")?.GetValue(entity, null)
            });

            Console.WriteLine(result);

            return result;
        }
    }

    /// <summary>
    ///  Add a new entity to the database and return the entity with the Id
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public T? AddReturnEntity(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        else
        {
            PropertyInfo[]? entityProperties = entity.GetType().GetProperties();

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains("Id")
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                where !v.Name.Contains("Id")
                select "@" + v.Name
            );

            string fields = allFields.Aggregate((x, y) => x + ", " + y);
            string values = allValues.Aggregate((x, y) => x + ", " + y);

            string query = $"INSERT INTO {typeof(T).Name} ({fields}) VALUES ({values});" +
                            $"SELECT CAST(SCOPE_IDENTITY() as int)";
            int newId = 0;

            //Console.WriteLine(query);

            newId = this.cnn.QuerySingle<int>(query, entity);

            //Console.WriteLine(newId);

            return this.GetById(newId);
        }
    }

    public int Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        else
        {
            PropertyInfo[]? entityProperties = entity.GetType().GetProperties();

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains("Id")
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                where !v.Name.Contains("Id")
                select "@" + v.Name
            );

            /// Method 1 - Using LINQ filter includes "Id" related fields to get the primary key (assuming includes "Id" realted field is the primary key)
            //string? primaryKey = (
            //    from p in entityProperties
            //    where p.Name.Contains("Id")
            //    select p.Name
            //).FirstOrDefault();

            /// Method 2 - Using LINQ get first field to get the primary key (assuming the first field is the primary key)
            string? primaryKey = (
                from p in entityProperties
                select p.Name
            ).FirstOrDefault();

            if (primaryKey == null)
            {
                throw new ArgumentNullException(nameof(primaryKey));
            }

            //Console.WriteLine(primaryKey);

            /// Method 1 - Using LINQ and String.Join method to create the query
            string updateFields = string.Join(", ", allFields.Select((f, i) => $"{f} = {allValues.ElementAt(i)}"));

            /// Method 2 - Using LINQ and Zip method to create the query
            //IEnumerable<string> numberFields = allFields.Zip(allValues, (f, v) => $"{f} = {v}");
            //string updateFields = numberFields.Aggregate((x, y) => x + ", " + y);

            /// Beacause of the values, we need to use reflection to get the values
            string query = $"UPDATE {typeof(T).Name} SET {updateFields} WHERE {primaryKey} = @Id";
            int result = -1;

            //Console.WriteLine(query);

            /// Method 1 - Using Dapper StaticParameters to create the query (avoid SQL injection attack)
            result = this.cnn.Execute(query, entity);

            /// Method 2 - Using Dapper DynamicParameters to create the query (avoid SQL injection attack)
            //result = this.cnn.Execute(
            //    query,
            //    new
            //    {
            //        Name = entity.GetType()?.GetProperty("Name")?.GetValue(entity, null),
            //        Description = entity.GetType()?.GetProperty("Description")?.GetValue(entity, null),
            //        Attack = entity.GetType()?.GetProperty("Attack")?.GetValue(entity, null),
            //        HealthPoint = entity.GetType()?.GetProperty("HealthPoint")?.GetValue(entity, null),
            //        Defense = entity.GetType()?.GetProperty("Defense")?.GetValue(entity, null),
            //        Cost = entity.GetType()?.GetProperty("Cost")?.GetValue(entity, null),
            //        Id = entity.GetType()?.GetProperty("Id")?.GetValue(entity, null)
            //    }
            //);

            return result;
        }
    }

    public T? UpdateReturnEntity(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        else
        {
            PropertyInfo[]? entityProperties = entity.GetType().GetProperties();

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains("Id")
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                where !v.Name.Contains("Id")
                select "@" + v.Name
            );

            /// Method 1 - Using LINQ filter includes "Id" related fields to get the primary key (assuming includes "Id" realted field is the primary key)
            //string? primaryKey = (
            //    from p in entityProperties
            //    where p.Name.Contains("Id")
            //    select p.Name
            //).FirstOrDefault();

            /// Method 2 - Using LINQ get first field to get the primary key (assuming the first field is the primary key)
            string? primaryKey = (
                from p in entityProperties
                select p.Name
            ).FirstOrDefault();

            if (primaryKey == null)
            {
                throw new ArgumentNullException(nameof(primaryKey));
            }

            //Console.WriteLine(primaryKey);

            /// Method 1 - Using LINQ and String.Join method to create the query
            string updateFields = string.Join(", ", allFields.Select((f, i) => $"{f} = {allValues.ElementAt(i)}"));

            /// Method 2 - Using LINQ and Zip method to create the query
            //IEnumerable<string> numberFields = allFields.Zip(allValues, (f, v) => $"{f} = {v}");
            //string updateFields = numberFields.Aggregate((x, y) => x + ", " + y);

            /// Beacause of the values, we need to use reflection to get the values
            string query = $"UPDATE {typeof(T).Name} SET {updateFields} WHERE {primaryKey} = @Id;" +
                            $"SELECT * FROM {typeof(T).Name} WHERE {primaryKey} = @Id";
            ;

            //Console.WriteLine(query);

            /// Method 1 - Using Dapper StaticParameters to create the query (avoid SQL injection attack)
            int editId = 0;

            //Console.WriteLine(query);

            editId = this.cnn.QuerySingle<int>(query, entity);

            //Console.WriteLine(editId);

            return this.GetById(editId);
        }
    }

    public int Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public int AddRange(List<T> entities)
    {
        throw new NotImplementedException();
    }

    public int UpdateRange(List<T> entities)
    {
        throw new NotImplementedException();
    }

    public int DeleteRange(List<T> entities)
    {
        throw new NotImplementedException();
    }
}
