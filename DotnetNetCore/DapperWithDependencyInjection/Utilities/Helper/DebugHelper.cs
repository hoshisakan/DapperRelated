using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Utilities.Helper
{
    public class DebugHelper
    {
        public DebugHelper()
        {
        }

        public static void ReadItemsOutputRawText(string rawText, string currentJobName, string createLogDate)
        {
            Console.WriteLine(rawText);
            LogHelper.WriteLog(currentJobName, createLogDate, rawText);
        }


        /// <summary>
        /// Print out the json string and write to log file with current job name and current log date
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="currentJobName"></param>
        /// <param name="createLogDate"></param>
        public static void ReadItemsOutputJsonString<T>(T data, string currentJobName, string createLogDate)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (string.IsNullOrEmpty(currentJobName))
            {
                throw new ArgumentNullException(nameof(currentJobName));
            }

            if (string.IsNullOrEmpty(createLogDate))
            {
                createLogDate = DateTimeHelper.GetNowDateFormat("yyyyMMdd");
            }

            string jsonString = JsonHelper.Serialize(data);

            Console.WriteLine(jsonString);
            LogHelper.WriteLog(currentJobName, createLogDate, jsonString);
        }
    }
}
