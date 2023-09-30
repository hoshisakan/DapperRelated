using Dapper;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using DataAccess.Repositories.IRepositories;
using Models.DAO.NEC.Test;


namespace DataAccess.Repositories
{
    public class APLogRepository : Repository<APLog>, IAPLog_Repository
    {
        private readonly SqlConnection cnn;

        public APLogRepository(SqlConnection cnn) : base(cnn)
        {
            this.cnn = cnn;
        }

        public APLog GetRecordByNameAndLogTime(string name, string logTime)
        {
            APLog result;
            string query = $"SELECT * FROM [dbo].[APLog] WHERE [JobName] = '{name}' AND [LogDateTime] = '{logTime}'";

            result = this.cnn.Query<APLog>(query).FirstOrDefault();

            return result;
        }

        public APLog GetRecordByNameAndLogTime(string name, DateTime logTime)
        {
            APLog result;
            string query = $"SELECT * FROM [dbo].[APLog] WHERE [JobName] = '{name}' AND [LogDateTime] = '{logTime}'";

            result = this.cnn.Query<APLog>(query).FirstOrDefault();

            return result;
        }

        public bool IsExistByNameAndLogTime(string name, string logTime)
        {
            bool result;
            string query = "SELECT COUNT(*) FROM [dbo].[APLog] WHERE [JobName] = @JobName AND [LogDateTime] = @LogDateTime";

            result = this.cnn.Query<int>(query, new { JobName = name, LogDateTime = logTime }).FirstOrDefault() > 0;

            return result;
        }

        /// <summary>
        /// Add a new entity to the database and return inserted query result code (1 = success, -1 = fail)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override int Add(APLog entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            else
            {
                PropertyInfo[] entityProperties = entity.GetType().GetProperties();

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

                string query;

                if (entity.LogDateTime == null)
                {
                    //query = $"IF NOT EXISTS (SELECT * FROM [dbo].[APLog] WHERE [JobName] = @JobName AND [LogDateTime] IS NULL) INSERT INTO [dbo].[APLog] ({fields}) VALUES ({values})";
                    query = $"INSERT INTO [dbo].[APLog] ({fields}) VALUES ({values})";
                }
                else
                {
                    query = $"IF NOT EXISTS (SELECT * FROM [dbo].[APLog] WHERE [JobName] = @JobName AND [LogDateTime] = @LogDateTime) INSERT INTO [dbo].[APLog] ({fields}) VALUES ({values})";
                }
                 
                int result = -1;

                //Console.WriteLine(query);

                /// Method 3 - Using Dapper DynamicParameters to create the query(avoid SQL injection attack)
                /// Not tested
                result = this.cnn.Execute(query, new DynamicParameters(entity)); /// Get the inserted query result code (1 = success, -1 = fail)

                Console.WriteLine("Add entity to database result: " + result);

                return result;
            }
        }
    }
}
