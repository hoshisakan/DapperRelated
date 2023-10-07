using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper.IHelper
{
    public interface IDateTimeHelper
    {
        public string GetNowDateFormat(string format);
        public string GetCurrentDateTimeString(string format = "yyyy-MM-dd HH:mm:ss");
        public string GetNowSpecificDateTimeFormat(DateTime dateTime, string format = "yyyy-MM-dd HH:mm:ss");
        public DateTime GetDefaultDateTime();
        public bool IsAnyNotNullInDateTimeList(List<DateTime?> dateTimeList);
        public bool IsAnyHasNullInDateTimeList(List<DateTime?> dateTimeList);
        public bool IsAllNotHaveNullInDateTimeList(List<DateTime?> dateTimeList);
        public bool IsAllHaveNullInDateTimeList(List<DateTime?> dateTimeList);
        public bool IsDateEqual(DateTime dt1, DateTime dt2);
        public bool IsDateTimeEqual(DateTime dt1, DateTime dt2);
        public T CompareDateTime<T>(DateTime jobStartTime, DateTime jobLogTime);
    }
}
