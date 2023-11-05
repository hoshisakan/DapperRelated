using DapperTraditionalTest.Test.ITest;
using DataAccess.Repositories.IRepositories;
using Models.DataModel.NECRelated.APLog;
using Models.Entity.NEC.Test;
using Utilities.Helper.IHelper;

namespace DapperTraditionalTest.Test
{
    public class QueryTest : IQueryTest
    {
        private readonly IUnitWork _unitWork;
        private readonly IJsonHelper _jsonHelper;
        private readonly ILoggerHelper _loggerHelper;
        //private readonly IJsonConfigurationHelper _jsonConfigurationHelper;


        public QueryTest(IUnitWork unitWork, IJsonHelper jsonHelper,
            ILoggerHelper loggerHelper)
        {
            _unitWork = unitWork;
            _jsonHelper = jsonHelper;
            _loggerHelper = loggerHelper;
            //_jsonConfigurationHelper = jsonConfigurationHelper;
        }

        public void TestIsTableEmpty()
        {
            Console.WriteLine($"Test: {this._unitWork.FileTable_Repository.IsTableEmpty()}");
        }

        public void TestIsTableExists()
        {
            Dictionary<string, bool> tempAllTableCheckResult = new Dictionary<string, bool>()
            {
                {"FileTable", _unitWork.FileTable_Repository.IsTableExists()},
                {"APLog",_unitWork.APLog_Repository.IsTableExists()},
                {"Kiosk_tblMember",  _unitWork.Kiosk_TblMember_Repository.IsTableExists()},
            };
            _loggerHelper.LogDebug(_jsonHelper.Serialize(tempAllTableCheckResult), nameof(QueryTest), nameof(TestIsTableExists));
            Console.WriteLine(_jsonHelper.Serialize(tempAllTableCheckResult));
        }

        public void TestAPLog_Parameter()
        {
            List<CheckDetectionResultExists> searchList = new List<CheckDetectionResultExists>
            {
                new CheckDetectionResultExists()
                {
                    JobName = "TestErrorException",
                    LogDateTime = "2023-09-17 23:23:01.000"
                },
                new CheckDetectionResultExists()
                {
                    JobName = "TestErrorException",
                    LogDateTime = "2023-09-17 11:23:01.000"
                },
            };

            bool isExists;

            foreach (CheckDetectionResultExists item in searchList)
            {
                isExists = _unitWork.APLog_Repository.IsExistByNameAndLogTime(item.JobName, item.LogDateTime);
                _loggerHelper.LogDebug($"{item.JobName}, {item.LogDateTime} => Is exists? {isExists}", nameof(QueryTest), nameof(TestAPLog_Parameter));
            }
        }

        public void TestKiosk_Parameter()
        {
            List<Kiosk_Parameter> dataList;

            dataList = _unitWork.Kiosk_Parameter_Repository.GetAll();

            _loggerHelper.LogDebug(_jsonHelper.Serialize(dataList), nameof(QueryTest), nameof(TestKiosk_Parameter));

            this._unitWork.Kiosk_Parameter_Repository.SetOrUpdateKiosk_ParameterValue("SOAPTestKeyReadFile1", "00000000000000000000000000000001", true);

            _loggerHelper.LogDebug(_jsonHelper.Serialize(dataList), nameof(QueryTest), nameof(TestKiosk_Parameter));
        }

        public void TestFileTable()
        {
            List<FileTable> dataList;
            FileTable newData = new FileTable();
            FileTable oldData = new FileTable();
            FileTable editData = new FileTable();

            FileTable addData = new FileTable()
            {
                File1 = "1420582763",
                File2 = "C125896375",
                Account = "test",
                UpdateTime = DateTime.Now
            };

            int addResult = _unitWork.FileTable_Repository.Add(addData);

            if (addResult != 1)
            {
                _loggerHelper.LogDebug("Add data failed", nameof(QueryTest), nameof(TestFileTable));
                return;
            }
            else
            {
                _loggerHelper.LogDebug("Add data successfully", nameof(QueryTest), nameof(TestFileTable));
            }

            //oldData = _unitWork.FileTable_Repository.GetFirst(addData.File2, addData.UpdateTime);
            _loggerHelper.LogDebug(addData.UpdateTime.ToString("yyyy-MM-ddThh:mm:ss.fff"), nameof(QueryTest), nameof(TestFileTable));
            oldData = _unitWork.FileTable_Repository.GetFirst(addData.File2, addData.UpdateTime.ToString("yyyy-MM-ddThh:mm:ss.fff"));
            //oldData = _unitWork.FileTable_Repository.GetFirst("C125896375", "2023-09-11 22:28:11.113");
            //oldData = _unitWork.FileTable_Repository.GetFirst("C125896375", "2023-09-11T22:12:01.827");

            if (oldData == null)
            {
                _loggerHelper.LogDebug("No data", nameof(QueryTest), nameof(TestFileTable));
                return;
            }
            else
            {
                _loggerHelper.LogDebug("Get data successfully", nameof(QueryTest), nameof(TestFileTable));
            }

            string resultData = _jsonHelper.Serialize(oldData);

            if (string.IsNullOrEmpty(resultData))
            {
                _loggerHelper.LogDebug("No data", nameof(QueryTest), nameof(TestFileTable));
            }
            else
            {
                _loggerHelper.LogDebug(resultData, nameof(QueryTest), nameof(TestFileTable));
            }

            _loggerHelper.LogDebug(oldData.UpdateTime.ToString("yyyy-MM-ddThh:mm:ss.fff"), nameof(QueryTest), nameof(TestFileTable));

            editData = _unitWork.FileTable_Repository.GetFirst(oldData.File2, oldData.UpdateTime);

            if (editData == null)
            {
                _loggerHelper.LogDebug("No data", nameof(QueryTest), nameof(TestFileTable));
            }
            else
            {
                _loggerHelper.LogDebug(_jsonHelper.Serialize(editData), nameof(QueryTest), nameof(TestFileTable));
                editData.File1 = "1420119899";
                editData.Account = "testUpdate";
                int updateResult = _unitWork.FileTable_Repository.Update(editData);

                if (updateResult == 1)
                {
                    _loggerHelper.LogDebug("Update successfully", nameof(QueryTest), nameof(TestFileTable));
                }
                else
                {
                    _loggerHelper.LogDebug("Update failed", nameof(QueryTest), nameof(TestFileTable));
                }
            }

            //bool isExist = _unitWork.FileTable_Repository.IsExist("C125896999", "2023-09-11 16:34:19.327");
            //Console.WriteLine(isExist);

            //newData.File1 = "1420582763";
            //newData.File2 = "A2631192";
            //newData.Account = "test";

            //Console.WriteLine(JsonHelper.Serialize(newData));

            //int addResult = _unitWork.FileTable_Repository.Add(newData);

            //Console.WriteLine(addResult);

            //if (addResult == 1)
            //{
            //    Console.WriteLine("Add successfully");

            //    oldData = _unitWork.FileTable_Repository.GetFirst(newData.File2, newData.UpdateTime);

            //    Console.WriteLine(JsonHelper.Serialize(oldData));

            //    if (oldData != null)
            //    {
            //        oldData.File1 = "1420119899";
            //        oldData.Account = "testUpdate";
            //        int updateResult = _unitWork.FileTable_Repository.Update(oldData);

            //        if (updateResult == 1)
            //        {
            //            Console.WriteLine("Update successfully");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Update failed");
            //        }

            //        editData = _unitWork.FileTable_Repository.GetFirst(oldData.File2, oldData.UpdateTime);

            //        Console.WriteLine(JsonHelper.Serialize(editData));

            //        //if (editData != null)
            //        //{
            //        //    Console.WriteLine("Remove successfully");

            //        //    int removeResult = _unitWork.FileTable_Repository.Delete(editData);

            //        //    if (removeResult == 2)
            //        //    {
            //        //        Console.WriteLine("Remove successfully");
            //        //    }
            //        //    else
            //        //    {
            //        //        Console.WriteLine("Remove failed");
            //        //    }
            //        //}
            //        //else
            //        //{
            //        //    Console.WriteLine("Remove failed");
            //        //}
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Add failed");
            //}
        }
    }
}
