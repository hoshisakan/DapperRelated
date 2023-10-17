namespace Utilities.Helper.IHelper
{
    public interface IDateTimeHelper
    {
        public DateTime GetDefaultDateTime();
        public DateTime GetCurrentDate();
        public DateTime GetCurrentDateTime();
        public string GetCurrentDateString(string format = "yyyy-MM-dd HH:mm:ss");
        public string GetCurrentDateTimeString(string format = "yyyy-MM-dd HH:mm:ss");
        public string GetSpecificDateTimeString(DateTime dateTime, string format = "yyyy-MM-dd HH:mm:ss");
        public bool IsAnyNotNullInDateTimeList(List<DateTime?> dateTimeList);
        public bool IsAnyHasNullInDateTimeList(List<DateTime?> dateTimeList);
        public bool IsAllNotHaveNullInDateTimeList(List<DateTime?> dateTimeList);
        public bool IsAllHaveNullInDateTimeList(List<DateTime?> dateTimeList);
        public bool IsDateEqual(DateTime dt1, DateTime dt2);
        public bool IsDateTimeEqual(DateTime dt1, DateTime dt2);
        public T CompareDateTime<T>(DateTime jobStartTime, DateTime jobLogTime);
    }
}
