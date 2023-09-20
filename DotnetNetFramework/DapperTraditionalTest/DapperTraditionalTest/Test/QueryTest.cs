using Utilities.Helper;
using DataAccess.Data;
using DataAccess.Data.IData;
using DataAccess.Repositories;
using DataAccess.Repositories.IRepositories;
using Models.DAO.NEC.Test;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DataModel.APLog;

namespace DapperTraditionalTest.Test
{
    public class QueryTest
    {
        private readonly SqlConnection cnn;
        private readonly IDbContextInitialize dbContextInitialize;
        private readonly IUnitWork unitWork;


        public QueryTest(string connectionString)
        {
            dbContextInitialize = new DbContextInitialize(connectionString);
            cnn = dbContextInitialize.Initialize();
            unitWork = new UnitWork(this.cnn);
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
                isExists = unitWork.APLog_Repository.IsExistByNameAndLogTime(item.JobName, item.LogDateTime);
                Console.WriteLine($"{item.JobName}, {item.LogDateTime} => Is exists? {isExists}");
            }
        }

        public void TestKiosk_Parameter()
        {
            List<Kiosk_Parameter> dataList;

            dataList = unitWork.Kiosk_Parameter_Repository.GetAll();

            Console.WriteLine(JsonHelper.Serialize(dataList));

            this.unitWork.Kiosk_Parameter_Repository.SetOrUpdateKiosk_ParameterValue("SOAPTestKeyReadFile1", "00000000000000000000000000000001", true);

            Console.WriteLine(JsonHelper.Serialize(dataList));
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

            int addResult = unitWork.FileTable_Repository.Add(addData);

            if (addResult != 1)
            {
                Console.WriteLine("Add data failed");
                return;
            }
            else
            {
                Console.WriteLine("Add data successfully");
            }

            //oldData = unitWork.FileTable_Repository.GetFirst(addData.File2, addData.UpdateTime);
            Console.WriteLine(addData.UpdateTime.ToString("yyyy-MM-ddThh:mm:ss.fff"));
            oldData = unitWork.FileTable_Repository.GetFirst(addData.File2, addData.UpdateTime.ToString("yyyy-MM-ddThh:mm:ss.fff"));
            //oldData = unitWork.FileTable_Repository.GetFirst("C125896375", "2023-09-11 22:28:11.113");
            //oldData = unitWork.FileTable_Repository.GetFirst("C125896375", "2023-09-11T22:12:01.827");

            if (oldData == null)
            {
                Console.WriteLine("No data");
                return;
            }
            else
            {
                Console.WriteLine("Get data successfully");
            }

            string resultData = JsonHelper.Serialize(oldData);

            if (string.IsNullOrEmpty(resultData))
            {
                Console.WriteLine("No data");
            }
            else
            {
                Console.WriteLine(resultData);
            }

            Console.WriteLine(oldData.UpdateTime);

            editData = unitWork.FileTable_Repository.GetFirst(oldData.File2, oldData.UpdateTime);

            if (editData == null)
            {
                Console.WriteLine("No data");
            }
            else
            {
                Console.WriteLine(JsonHelper.Serialize(editData));
                editData.File1 = "1420119899";
                editData.Account = "testUpdate";
                int updateResult = unitWork.FileTable_Repository.Update(editData);

                if (updateResult == 1)
                {
                    Console.WriteLine("Update successfully");
                }
                else
                {
                    Console.WriteLine("Update failed");
                }
            }

            //bool isExist = unitWork.FileTable_Repository.IsExist("C125896999", "2023-09-11 16:34:19.327");
            //Console.WriteLine(isExist);

            //newData.File1 = "1420582763";
            //newData.File2 = "A2631192";
            //newData.Account = "test";

            //Console.WriteLine(JsonHelper.Serialize(newData));

            //int addResult = unitWork.FileTable_Repository.Add(newData);

            //Console.WriteLine(addResult);

            //if (addResult == 1)
            //{
            //    Console.WriteLine("Add successfully");

            //    oldData = unitWork.FileTable_Repository.GetFirst(newData.File2, newData.UpdateTime);

            //    Console.WriteLine(JsonHelper.Serialize(oldData));

            //    if (oldData != null)
            //    {
            //        oldData.File1 = "1420119899";
            //        oldData.Account = "testUpdate";
            //        int updateResult = unitWork.FileTable_Repository.Update(oldData);

            //        if (updateResult == 1)
            //        {
            //            Console.WriteLine("Update successfully");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Update failed");
            //        }

            //        editData = unitWork.FileTable_Repository.GetFirst(oldData.File2, oldData.UpdateTime);

            //        Console.WriteLine(JsonHelper.Serialize(editData));

            //        //if (editData != null)
            //        //{
            //        //    Console.WriteLine("Remove successfully");

            //        //    int removeResult = unitWork.FileTable_Repository.Delete(editData);

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
