using Dapper;
using DapperTraditionalTest.Helper;
using DataAccess.Repositories.IRepositories;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;
using Utilities.Helper;
using static Dapper.SqlMapper;

namespace DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly SqlConnection cnn;

    public Repository(SqlConnection cnn)
    {
        this.cnn = cnn;
    }

    public string GetPrimaryKeyName()
    {
        PropertyInfo[]? entityProperties = typeof(T).GetProperties();

        string? primaryKey = null;

        /// Method 1 - Using LINQ get first field to get the primary key (assuming the first field is the primary key)
        primaryKey = (
            from p in entityProperties
            select p.Name
        ).FirstOrDefault();

        /// Method 2 - Using LINQ filter includes "Id" related fields to get the primary key (assuming includes "Id" realted field is the primary key)
        //primaryKey = (
        //    from p in entityProperties
        //    where p.Name.Contains("Id")
        //    select p.Name
        //).FirstOrDefault();

        /// Not working
        //primaryKey = (
        //    from p in entityProperties
        //    where p.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0
        //    select p.Name
        //).FirstOrDefault();

        /// Not working
        //foreach (PropertyInfo property in entityProperties)
        //{
        //    //KeyAttribute? attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute))
        //    //    as KeyAttribute;

        //    Attribute? attribute = property.GetCustomAttribute(typeof(KeyAttribute));

        //    if (attribute != null)
        //    {
        //        primaryKey = property.Name;
        //        break;
        //    }
        //}

        //entityProperties.ToList().ForEach(p =>
        //{
        //    Console.WriteLine($"{typeof(KeyAttribute)}");
        //    Console.WriteLine($"Property name: {p.Name}");
        //    Console.WriteLine($"Property type: {p.PropertyType}");
        //    Console.WriteLine($"Property data type: {p.GetType()}");
        //    Console.WriteLine($"Property custom attributes: {p.GetCustomAttributes()}");
        //    Console.WriteLine($"Property custom attributes: {p.GetCustomAttributes(typeof(KeyAttribute), true)}");
        //    Console.WriteLine($"Property custom attributes length: {p.GetCustomAttributes(typeof(KeyAttribute), true).Length}");
        //    Console.WriteLine($"Property custom attributes length compare result: {p.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0}");
        //    Console.WriteLine("-------------------------------------------------------------------------------");
        //});

        if (primaryKey == null)
        {
            throw new ArgumentNullException(nameof(primaryKey));
        }

        Console.WriteLine($"Primary key name: {primaryKey}");

        return primaryKey;
    }

    public bool IsTableExists()
    {
        //return this.cnn.Query<T>($"SELECT CASE WHEN OBJECT_ID('{typeof(T).Name}', 'U') IS NOT NULL THEN 1 ELSE 0 END").Count() > 0;
        dynamic result = this.cnn.QueryFirst<int>($"SELECT CASE WHEN OBJECT_ID('{typeof(T).Name}', 'U') IS NOT NULL THEN 1 ELSE 0 END") > 0;
        DebugHelper.ReadItemsOutputRawText(
            $"Check table exists result: {result}",
            SystemHelper.GetApplicationName(),
            DateTimeHelper.GetNowDateFormat("yyyyMMdd")
        );
        return result;
    }

    public List<T> GetAll()
    {
        return this.cnn.Query<T>($"SELECT * FROM {typeof(T).Name}").ToList();
    }

    public T GetFirst()
    {
        return this.cnn.QueryFirstOrDefault<T>($"SELECT TOP 1 * FROM {typeof(T).Name}");
    }

    public T GetLast()
    {
        return this.cnn.QueryFirstOrDefault<T>($"SELECT TOP 1 * FROM {typeof(T).Name} ORDER BY {GetPrimaryKeyName()} DESC");
    }

    public T GetById(int id)
    {
        return this.cnn.QueryFirstOrDefault<T>($"SELECT * FROM {typeof(T).Name} WHERE {GetPrimaryKeyName()} = @Id", new { Id = id });
    }

    public int GetCount()
    {
        return this.cnn.QueryFirstOrDefault<int>($"SELECT COUNT(*) FROM {typeof(T).Name}");
    }

    public List<T> GetWhere(Expression<Func<T, bool>> predicate)
    {
        List<string> allQueryList = new List<string>()
        {
            $"SELECT * FROM {typeof(T).Name} WHERE {predicate.Compile()}",
            $"SELECT * FROM {typeof(T).Name} WHERE {predicate.Body}",
            $"SELECT * FROM {typeof(T).Name} WHERE {predicate.Body.ToString().Replace("AndAlso", "AND").Replace("OrElse", "OR")}",
            $"SELECT * FROM {typeof(T).Name} WHERE {predicate.Body.ToString().Replace("AndAlso", "AND").Replace("OrElse", "OR").Replace("==", "=")}",
            $"SELECT * FROM {typeof(T).Name} WHERE {predicate.Body.ToString().Replace("AndAlso", "AND").Replace("OrElse", "OR").Replace("==", "=").Replace("True", "1").Replace("False", "0").Replace("x.", "")}",
            $""
        };

        string query = allQueryList[5];

        foreach (string temp in allQueryList)
        {
            Console.WriteLine(temp);
        }

        //return this.cnn.Query<T>($"SELECT * FROM {typeof(T).Name}").Where(predicate.Compile()).ToList();
        return this.cnn.Query<T>(query).ToList();
    }

    public List<T> GetTake(int take)
    {
        return this.cnn.Query<T>($"SELECT TOP {take} * FROM {typeof(T).Name}").ToList();
    }

    public List<T> GetTakeReverse(int take)
    {
        return this.cnn.Query<T>($"SELECT TOP {take} * FROM {typeof(T).Name} ORDER BY {GetPrimaryKeyName()} DESC").ToList();
    }

    /// <summary>
    /// Add a new entity to the database and return inserted query result code (0 = success, -1 = fail)
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public virtual int Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        else
        {
            PropertyInfo[]? entityProperties = entity.GetType().GetProperties();

            string primaryKey = GetPrimaryKeyName();

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

            Console.WriteLine(query);

            /// Method 1 - Using Dapper StaticParameters to create the query(avoid SQL injection attack)
            //result = this.cnn.QueryFirstOrDefault<int>(query, entity); /// Get the inserted query result code (0 = success, -1 = fail)

            /// Method 2 - Using Dapper DynamicParameters to create the query(avoid SQL injection attack)
            /// Not tested
            //result = this.cnn.QueryFirstOrDefault<int>(query, new DynamicParameters(entity)); /// Get the inserted query result code (0 = success, -1 = fail)

            /// Method 3 - Using Dapper DynamicParameters to create the query(avoid SQL injection attack)
            /// Not tested
            result = this.cnn.Execute(query, new DynamicParameters(entity)); /// Get the inserted query result code (1 = success, -1 = fail)

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

            string primaryKey = GetPrimaryKeyName();

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

            newId = this.cnn.QuerySingle<int>(query, entity); /// Get the new Id

            //Console.WriteLine(newId);

            return this.GetById(newId);
        }
    }

    public int AddOrUpdate(T entity)
    {
        throw new NotImplementedException();
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

            string primaryKey = GetPrimaryKeyName();

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
            result = this.cnn.Execute(query, entity); /// Return the number of rows affected

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

            string primaryKey = GetPrimaryKeyName();

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

            editId = this.cnn.QuerySingle<int>(query, entity); /// Return the Id of the edited entity

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

            result = this.cnn.Execute(query, entity); /// Return the number of rows affected

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

            string primaryKey = GetPrimaryKeyName();

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
            int result = 0;

            while (count > 0)
            {
                IEnumerable<T> entitiesTake = entities.Skip(skip).Take(take);

                query = $"INSERT INTO {typeof(T).Name} ({fields}) VALUES ({values})";

                result += this.cnn.Execute(query, entitiesTake); /// Return the number of rows affected

                //Console.WriteLine($"count: {count}, skip: {skip}, take: {take}");

                skip += take;
                count -= take;
            }
            return result;
        }
    }

    /// <summary>
    /// The method is current best practice to update multiple records to database
    /// But the method is not good, because it spend too much time to update
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public int UpdateRange(List<T> entities)
    {
        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities));
        }
        else
        {
            PropertyInfo[]? entityProperties = entities.FirstOrDefault()?.GetType().GetProperties();

            string primaryKey = GetPrimaryKeyName();

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

            int take = 1000;
            int skip = 0;
            int count = entities.Count();

            //Console.WriteLine(count);

            string query = string.Empty;

            int result = 0;

            while (count > 0)
            {
                query = $"UPDATE {typeof(T).Name} SET {updateFields} WHERE {primaryKey} = @{primaryKey}";

                IEnumerable<T> entitiesTake = entities.Skip(skip).Take(take);

                result += this.cnn.Execute(query, entitiesTake);

                //Console.WriteLine($"count: {count}, skip: {skip}, take: {take}");

                skip += take;
                count -= take;
            }
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
            PropertyInfo[]? entityProperties = entities.FirstOrDefault()?.GetType().GetProperties();

            string primaryKey = GetPrimaryKeyName();

            int take = 1000;
            int skip = 0;
            int count = entities.Count();
            int result = 0;

            //Console.WriteLine(count);

            int[] allIds = (
                from e in entities
                where e.GetType()?.GetProperty(primaryKey)?.GetValue(e) != null
                select (int)e.GetType()?.GetProperty(primaryKey)?.GetValue(e)
            ).ToArray();

            int[] ids = new int[] { };

            while (count > 0)
            {
                IEnumerable<T> entitiesTake = entities.Skip(skip).Take(take);

                string query = $"DELETE FROM {typeof(T).Name} WHERE {primaryKey} IN @ids";

                //Console.WriteLine(query);

                ids = allIds.Skip(skip).Take(take).ToArray();

                //Console.WriteLine($"Remove data count: {ids.Length}");

                if (ids.Length > 0)
                {
                    //foreach (int id in ids)
                    //{
                    //    Console.WriteLine(id);
                    //}
                    result += this.cnn.Execute(query, new { ids }); /// Return the number of rows affected
                }
                skip += take;
                count -= take;
            }
            return result;
        }
    }

    public T? GetFirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable GetAllOri()
    {
        throw new NotImplementedException();
    }
}
