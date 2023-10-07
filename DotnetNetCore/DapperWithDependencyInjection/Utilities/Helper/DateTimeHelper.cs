using Utilities.Helper.IHelper;


namespace Utilities.Helper
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public string GetNowDateFormat(string format = "yyyy-MM-dd HH:mm:ss")
        {
            return DateTime.Now.Date.ToString(format);
        }

        public string GetCurrentDateTimeString(string format = "yyyy-MM-dd HH:mm:ss")
        {
            return DateTime.Now.ToString(format);
        }

        public string GetNowSpecificDateTimeFormat(DateTime dateTime, string format = "yyyy-MM-dd HH:mm:ss")
        {
            return dateTime.ToString(format);
        }

        public DateTime GetDefaultDateTime()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        }

        public bool IsAnyNotNullInDateTimeList(List<DateTime?> dateTimeList)
        {
            return dateTimeList.Any(dt => dt != null);
        }

        public bool IsAnyHasNullInDateTimeList(List<DateTime?> dateTimeList)
        {
            return dateTimeList.Any(dt => dt == null);
        }

        public bool IsAllNotHaveNullInDateTimeList(List<DateTime?> dateTimeList)
        {
            return dateTimeList.All(dt => dt != null);
        }

        public bool IsAllHaveNullInDateTimeList(List<DateTime?> dateTimeList)
        {
            return dateTimeList.All(dt => dt == null);
        }

        public bool IsDateEqual(DateTime dt1, DateTime dt2)
        {
            return dt1.Date == dt2.Date;
        }

        public bool IsDateTimeEqual(DateTime dt1, DateTime dt2)
        {
            return dt1 == dt2;
        }

        public T CompareDateTime<T>(DateTime jobStartTime, DateTime jobLogTime)
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
    }
}
