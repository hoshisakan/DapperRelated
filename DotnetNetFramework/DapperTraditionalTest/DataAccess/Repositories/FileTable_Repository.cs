using Dapper;
using DataAccess.Data.IData;
using DataAccess.Repositories.IRepositories;
using Models.DAO.NEC.Test;
using Utilities.Helper.IHelper;

namespace DataAccess.Repositories
{
    public class FileTable_Repository : Repository<FileTable>, IFileTable_Repository
    {
        private readonly IDapperConnectionProvider _dapperProvider;
        private readonly ILoggerHelper _loggerHelper;

        public FileTable_Repository(IDapperConnectionProvider dapperProvider, ILoggerHelper loggerHelper) : base(dapperProvider, loggerHelper)
        {
            _dapperProvider = dapperProvider;
            _loggerHelper = loggerHelper;
        }

        public FileTable GetFirst(string file2, DateTime updateTime)
        {
            FileTable result;

            string sql = @"SELECT * FROM [dbo].[FileTable]
                           WHERE [File2] = @File2 
                           AND [UpdateTime] = @UpdateTime
                        ";
            result = _dapperProvider.Connect().QueryFirstOrDefault<FileTable>(sql, new { File2 = file2, UpdateTime = updateTime });

            return result;
        }

        public FileTable GetFirst(string file2, string updateTime)
        {
            FileTable result;

            string sql = @"SELECT * FROM [dbo].[FileTable]
                           WHERE [File2] = @File2 
                           AND [UpdateTime] = @UpdateTime
                        ";
            result = _dapperProvider.Connect().QueryFirstOrDefault<FileTable>(sql, new { File2 = file2, UpdateTime = updateTime });

            return result;
        }

        public new int Add(FileTable entity)
        {
            int result;

            entity.UpdateTime = DateTime.Now;

            string sql = @"INSERT INTO [dbo].[FileTable]
                           ([File1]
                           ,[File2]
                           ,[Account]
                           ,[UpdateTime])
                        VALUES
                           (@File1
                           ,@File2
                           ,@Account
                           ,@UpdateTime)
                     ";

            result = _dapperProvider.Connect().Execute(sql, entity);

            return result;
        }

        public new int Update(FileTable entity)
        {
            int result;

            string sql = @"
                            UPDATE [dbo].[FileTable]
                            SET [File1] = @File1
                            ,[Account] = @Account
                            ,[UpdateTime] = @New_UpdateTime
                            WHERE
                            [File2] = @File2
                            AND [UpdateTime] = @Old_UpdateTime
                         ";

            result = _dapperProvider.Connect().Execute(sql, new
            {
                entity.File1,
                entity.File2,
                entity.Account,
                New_UpdateTime = DateTime.Now,
                Old_UpdateTime = entity.UpdateTime
            });

            return result;
        }

        public new int Delete(FileTable entity)
        {
            int result;

            string sql = @"
                            DELETE [dbo].[FileTable]
                            WHERE
                            [File1] = @File1 AND
                            [File2] = @File2 AND
                            [Account] = @Account
                         ";

            result = _dapperProvider.Connect().Execute(sql, entity);

            Console.WriteLine($"Delete: {result}");

            return result;
        }

        public bool IsExist(string file2, DateTime updateTime)
        {
            bool result;

            string sql = @"SELECT * FROM [dbo].[FileTable]
                           WHERE [File2] = @File2 
                           AND [UpdateTime] = @UpdateTime
                        ";
            result = _dapperProvider.Connect().QueryFirstOrDefault<FileTable>(sql, new { File2 = file2, UpdateTime = updateTime }) != null;

            return result;
        }

        public bool IsExist(string file2, string updateTime)
        {
            bool result;

            string sql = @"SELECT * FROM [dbo].[FileTable]
                           WHERE [File2] = @File2 
                           AND [UpdateTime] = @UpdateTime
                        ";
            result = _dapperProvider.Connect().QueryFirstOrDefault<FileTable>(sql, new { File2 = file2, UpdateTime = updateTime }) != null;

            return result;
        }

        public int Delete(string file2, string updateTime)
        {
            int result;

            string sql = @"DELETE FROM [dbo].[FileTable]
                           WHERE [File2] = @File2 
                           AND [UpdateTime] = @UpdateTime
                        ";
            result = _dapperProvider.Connect().Execute(sql, new { File2 = file2, UpdateTime = updateTime });

            return result;
        }
    }
}
