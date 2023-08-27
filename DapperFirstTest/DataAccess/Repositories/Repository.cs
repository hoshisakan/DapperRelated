using Dapper;
using DataAccess.Repository.IRepository;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;
using static Dapper.SqlMapper;

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

    public int GetCount()
    {
        return this.cnn.QueryFirstOrDefault<int>($"SELECT COUNT(*) FROM {typeof(T).Name}");
    }

    public List<T> GetWhere(Expression<Func<T, bool>> predicate)
    {
        return this.cnn.Query<T>($"SELECT * FROM {typeof(T).Name} WHERE {predicate}").ToList();
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

            string? primaryKey = (
                from p in entityProperties
                select p.Name
            ).FirstOrDefault();

            if (primaryKey == null)
            {
                throw new ArgumentNullException(nameof(primaryKey));
            }

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains(primaryKey)
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                where !v.Name.Contains(primaryKey)
                select "@" + v.Name
            );

            string fields = allFields.Aggregate((x, y) => x + ", " + y);
            string values = allValues.Aggregate((x, y) => x + ", " + y);

            string query = $"INSERT INTO {typeof(T).Name} ({fields}) VALUES ({values})";
            int result = -1;

            //Console.WriteLine(query);

            /// Method 1 - Using Dapper StaticParameters to create the query(avoid SQL injection attack)
            result = this.cnn.QueryFirstOrDefault<int>(query, entity);

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

            string? primaryKey = (
                from p in entityProperties
                select p.Name
            ).FirstOrDefault();

            if (primaryKey == null)
            {
                throw new ArgumentNullException(nameof(primaryKey));
            }

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains(primaryKey)
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                where !v.Name.Contains(primaryKey)
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

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains(primaryKey)
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                where !v.Name.Contains(primaryKey)
                select "@" + v.Name
            );

            /// Method 1 - Using LINQ and String.Join method to create the query
            string updateFields = string.Join(", ", allFields.Select((f, i) => $"{f} = {allValues.ElementAt(i)}"));

            /// Method 2 - Using LINQ and Zip method to create the query
            //IEnumerable<string> numberFields = allFields.Zip(allValues, (f, v) => $"{f} = {v}");
            //string updateFields = numberFields.Aggregate((x, y) => x + ", " + y);

            /// Beacause of the values, we need to use reflection to get the values
            string query = $"UPDATE {typeof(T).Name} SET {updateFields} WHERE {primaryKey} = @{primaryKey}";
            int result = -1;

            //Console.WriteLine(query);

            /// Method 1 - Using Dapper StaticParameters to create the query (avoid SQL injection attack)
            result = this.cnn.Execute(query, entity);

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

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains(primaryKey)
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                where !v.Name.Contains(primaryKey)
                select "@" + v.Name
            );

            /// Method 1 - Using LINQ and String.Join method to create the query
            string updateFields = string.Join(", ", allFields.Select((f, i) => $"{f} = {allValues.ElementAt(i)}"));

            /// Method 2 - Using LINQ and Zip method to create the query
            //IEnumerable<string> numberFields = allFields.Zip(allValues, (f, v) => $"{f} = {v}");
            //string updateFields = numberFields.Aggregate((x, y) => x + ", " + y);

            /// Beacause of the values, we need to use reflection to get the values
            string query = $"UPDATE {typeof(T).Name} SET {updateFields} WHERE {primaryKey} = @{primaryKey};" +
                $"SELECT * FROM {typeof(T).Name} WHERE {primaryKey} = @{primaryKey}";
            ;

            //Console.WriteLine(query);

            /// Method 1 - Using Dapper StaticParameters to create the query (avoid SQL injection attack)
            int editId = 0;

            editId = this.cnn.QuerySingle<int>(query, entity);

            //Console.WriteLine(editId);

            return this.GetById(editId);
        }
    }

    public int Delete(T entity)
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
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                select "@" + v.Name
            );

            /// Method 1 - Using LINQ and String.Join method to create the query
            //string deleteFields = string.Join(" AND ", allFields.Select((f, i) => $"{f} = {allValues.ElementAt(i)}"));

            /// Method 2 - Using LINQ and Zip method to create the query
            IEnumerable<string> numberFields = allFields.Zip(allValues, (f, v) => $"{f} = {v}");
            string deleteFields = numberFields.Aggregate((x, y) => x + " AND " + y);

            string query = $"DELETE FROM {typeof(T).Name} WHERE {deleteFields}";

            //Console.WriteLine(query);

            /// Method 1 - Using Dapper StaticParameters to create the query (avoid SQL injection attack)
            int result = -1;

            result = this.cnn.Execute(query, entity);

            return result;
        }
    }

    /// <summary>
    /// The method is current best practice to add multiple records to database
    /// Such as, add 10 ^ 5 records to database at 18 seconds 
    /// Such as, add 10 ^ 6 records to database at 3 minutes 50 seconds to 4 minutes 10 seconds 
    /// (I think it is slow, because 10 ^ 5 write to database need 18 seconds to 20 seconds, 
    /// then 10 ^ 6 should within 200 seconds, but test result get 250 seconds)
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public int AddRange(IEnumerable<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }
        else
        {
            PropertyInfo[]? entityProperties = entities.FirstOrDefault()?.GetType().GetProperties();

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

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains(primaryKey)
                select f.Name
            );
            IEnumerable<string> allValues = (
                from v in entityProperties
                where !v.Name.Contains(primaryKey)
                select "@" + v.Name
            );

            string fields = allFields.Aggregate((x, y) => x + ", " + y);
            string values = allValues.Aggregate((x, y) => x + ", " + y);

            int take = 1000;
            int skip = 0;
            int count = entities.Count();

            //Console.WriteLine(count);

            string query = string.Empty;
            int result = -1;

            while (count > 0)
            {
                IEnumerable<T> entitiesTake = entities.Skip(skip).Take(take);

                query = $"INSERT INTO {typeof(T).Name} ({fields}) VALUES ({values})";

                result = this.cnn.Execute(query, entitiesTake);

                //if (result == -1)
                //{
                //    Console.WriteLine("Error");
                //}
                //else
                //{
                //    Console.WriteLine("Success");
                //}

                //Console.WriteLine($"count: {count}, skip: {skip}, take: {take}");

                skip += take;
                count -= take;
            }
            return result;
        }
    }

    public int UpdateRange(List<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }
        else
        {
            PropertyInfo[]? entityProperties = entities.FirstOrDefault()?.GetType().GetProperties();

            string? primaryKey = (
                from p in entityProperties
                select p.Name
            ).FirstOrDefault();

            if (primaryKey == null)
            {
                throw new ArgumentNullException(nameof(primaryKey));
            }

            //Console.WriteLine(primaryKey);

            IEnumerable<string> allFields = (
                from f in entityProperties
                where !f.Name.Contains(primaryKey)
                select f.Name
            );

            IEnumerable<string> allValues = (
               from v in entityProperties
               where !v.Name.Contains(primaryKey)
               select "@" + v.Name
            );

            /// Method 1 - Using LINQ and String.Join method to create the query
            string updateFields = string.Join(", ", allFields.Select((f, i) => $"{f} = {allValues.ElementAt(i)}"));

            /// Method 2 - Using LINQ and Zip method to create the query
            //IEnumerable<string> numberFields = allFields.Zip(allValues, (f, v) => $"{f} = {v}");
            //string updateFields = numberFields.Aggregate((x, y) => x + ", " + y);

            /// Beacause of the values, we need to use reflection to get the values
            string query = $"UPDATE {typeof(T).Name} SET {updateFields} WHERE {primaryKey} = @{primaryKey}";
            int result = -1;

            //Console.WriteLine(query);

            /// Method 1 - Using Dapper StaticParameters to create the query (avoid SQL injection attack)
            result = this.cnn.Execute(query, entities);

            return result;
        }
    }

    public int DeleteRange(List<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }
        else
        {
            int result = -1;

            foreach (T entity in entities)
            {
                result = this.Delete(entity);
            }

            return result;
        }
    }
}
