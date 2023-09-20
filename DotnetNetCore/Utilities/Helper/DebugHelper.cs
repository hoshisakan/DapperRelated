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

        public static void ReadItemsOutputRawText(string rawText, string currentJobName, string currentLogLogDate)
        {
            Console.WriteLine(rawText);
            LogHelper.WriteLog(currentJobName, currentLogLogDate, rawText);
        }


        public static void ReadItemsOutputJsonString<T>(T? data)
        {
            if (data == null)
            {
                return;
            }

            string jsonString = JsonHelper.Serialize(data);

            Console.WriteLine(jsonString);
        }
    }
}
