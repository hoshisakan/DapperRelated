using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Helper
{
    public class DateTimeHelper
    {
        public static T CompareDateTime<T>(DateTime jobStartTime, DateTime jobLogTime)
        {
            int compareResult = DateTime.Compare(jobStartTime, jobLogTime);

            if (typeof(T) == typeof(int))
            {
                return (T)Convert.ChangeType(compareResult, typeof(T));
            }
            else if (typeof(T) == typeof(bool))
            {
                return (T)Convert.ChangeType(compareResult == 0, typeof(T));
            }
            else
            {
                throw new Exception("Type is not support");
            }
        }

        //public static readonly Func<DateTime, DateTime, bool> CompareDateTime = (jobStartTime, jobLogTime) => DateTime.Compare(jobStartTime, jobLogTime) == 0;

        public static readonly Func<string, string> GetNowDateFormat = (format) => DateTime.Now.Date.ToString(format);

        public static readonly Func<string, string> GetNowDateTimeFormat = (format) => DateTime.Now.ToString(format);

        public static readonly Func<DateTime> GetDefaultDateTime = () => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static string GetFormatDateTime(DateTime dt, string format = "yyyy-MM-dd HH:mm:ss")
        {
            return dt.ToString(format);
        }

        public static readonly Func<List<DateTime?>, bool> CheckDateTimeListAnyNotNull = (dateTimeList) => dateTimeList.Any(dt => dt != null);

        public static readonly Func<List<DateTime?>, bool> CheckDateTimeListAnyHasNull = (dateTimeList) => dateTimeList.Any(dt => dt == null);

        public static readonly Func<List<DateTime?>, bool> CheckDateTimeListAllNotHaveNull = (dateTimeList) => dateTimeList.All (dt => dt != null);
        
        public static readonly Func<List<DateTime?>, bool> CheckDateTimeListAllHaveNull = (dateTimeList) => dateTimeList.All (dt => dt == null);
    
        //public static Func<DateTime, DateTime, bool> CheckDateEqual = (dt1, dt2) => dt1.Date == dt2.Date;

        //public static Func<DateTime, string, bool> CheckDateEqual = (dt1, dt2_str) => DateTime.TryParse(dt2_str, out DateTime dt2) && dt1.Date == dt2.Date;

        public static readonly Func<DateTime, DateTime, bool> CheckDateEqual = (dt1, dt2) => dt1.Date == dt2.Date;

        public static readonly Func<DateTime, DateTime, bool> CheckDateTimeEqual = (dt1, dt2) => dt1 == dt2;
    }
}
