using Dapper;
using DataAccess.Data.IData;
using DataAccess.Repositories.IRepositories;
using Models.DAO.NEC.Test;
using System.Linq.Expressions;
using Utilities.Helper.IHelper;

namespace DataAccess.Repositories
{
    public class Kiosk_Parameter_Repository : Repository<Kiosk_Parameter>, IKiosk_Parameter_Repository
    {
        private readonly IDapperConnectionProvider _dapperProvider;
        private readonly ILoggerHelper _loggerHelper;
        private readonly Dictionary<string, string> Description = new Dictionary<string, string>()
        {
            {"SOAPTestKeyReadFile1", "測試金鑰ReadFile1"},
            {"SOAPTestKeyReadFile2", "測試金鑰ReadFile2"},
            {"SOAPTestKeyWriteFile2", "測試金鑰WriteFile2"},
        };

        public Kiosk_Parameter_Repository(IDapperConnectionProvider dapperProvider, ILoggerHelper loggerHelper) : base(dapperProvider, loggerHelper)
        {
            _dapperProvider = dapperProvider;
            _loggerHelper = loggerHelper;
        }

        public void DeleteKiosk_ParameterValue(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteKiosk_ParameterValue(int sn)
        {
            throw new NotImplementedException();
        }

        public void DeleteKiosk_ParameterValue(List<string> names)
        {
            throw new NotImplementedException();
        }

        public void DeleteKiosk_ParameterValue(List<int> sns)
        {
            throw new NotImplementedException();
        }

        public void DeleteKiosk_ParameterValue(List<Kiosk_Parameter> kiosk_Parameters)
        {
            throw new NotImplementedException();
        }

        public void DeleteKiosk_ParameterValue(Kiosk_Parameter kiosk_Parameter)
        {
            throw new NotImplementedException();
        }

        public void DeleteKiosk_ParameterValue(Expression<Func<Kiosk_Parameter, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public string GetKiosk_ParameterValue(string name)
        {
            throw new NotImplementedException();
        }

        public string GetKiosk_ParameterValue(int sn)
        {
            throw new NotImplementedException();
        }

        public List<Kiosk_Parameter> GetKiosk_ParameterByKeys(string[] keys)
        {
            List<Kiosk_Parameter> result = new List<Kiosk_Parameter>();
            string queryString;

            try
            {
                queryString = "SELECT [Name],[Value] FROM [dbo].[Kiosk_Parameter] WHERE [Name] IN @keys";

                _loggerHelper.LogDebug($"queryString: {queryString}", nameof(Kiosk_Parameter_Repository), nameof(GetKiosk_ParameterByKeys));

                result = _dapperProvider.Connect().Query<Kiosk_Parameter>(queryString, new { keys }).ToList();
            }
            catch (Exception ex)
            {
                _loggerHelper.LogError(ex.ToString(), ex, nameof(Kiosk_Parameter_Repository), nameof(GetKiosk_ParameterByKeys));
            }
            return result;
        }

        public void SetKiosk_ParameterValue(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void SetKiosk_ParameterValue(int sn, string name, string value)
        {
            throw new NotImplementedException();
        }

        public void SetOrUpdateKiosk_ParameterValue(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void SetOrUpdateKiosk_ParameterValue(int sn, string name, string value)
        {
            throw new NotImplementedException();
        }

        public void SetOrUpdateKiosk_ParameterValue(string name, string value, bool isTestMode = false)
        {
            DynamicParameters parameters = new DynamicParameters();
            int result;
            string queryString;

            /// Decarlare parameters Group field can't use @[Group] in dapper query, because it will be recognized as a parameter.
            if (isTestMode)
            {
                parameters.Add("@Name", name);
                parameters.Add("@Value", value);
                parameters.Add("@Status", true);
                parameters.Add("@Description", Description[name]);
                parameters.Add("@Group", "TsmcAPI");
                parameters.Add("@SN", GetLast().SN + 1);
                queryString = " IF NOT EXISTS (SELECT * FROM [dbo].[Kiosk_Parameter] WHERE [Name] = @Name) INSERT INTO [dbo].[Kiosk_Parameter] (SN, Name, Value, [Group], Description, Status) VALUES (@SN, @Name, @Value, @Group, @Description, @Status) ELSE UPDATE [dbo].[Kiosk_Parameter] SET [Value] = @Value WHERE [Name] = @Name ";
            }
            else
            {
                parameters.Add("@Name", name);
                parameters.Add("@Value", value);
                parameters.Add("@Status", true);
                parameters.Add("@Description", Description[name]);
                parameters.Add("@Group", "TsmcAPI");
                queryString = " IF NOT EXISTS (SELECT * FROM [dbo].[Kiosk_Parameter] WHERE [Name] = @Name) INSERT INTO [dbo].[Kiosk_Parameter] (Name, Value, [Group], Description, Status) VALUES (@Name, @Value, @Group, @Description, @Status) ELSE UPDATE [dbo].[Kiosk_Parameter] SET [Value] = @Value WHERE [Name] = @Name ";
            }

            Console.WriteLine($"query: {queryString}");

            result = _dapperProvider.Connect().Execute(queryString, parameters);

            Console.WriteLine($"SetOrUpdateKiosk_ParameterValue: {result}");
        }

        public void UpdateKiosk_ParameterValue(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void UpdateKiosk_ParameterValue(int sn, string value)
        {
            throw new NotImplementedException();
        }
    }
}
