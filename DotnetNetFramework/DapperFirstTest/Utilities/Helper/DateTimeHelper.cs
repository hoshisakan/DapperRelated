using System;

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

        //public static Func<DateTime, DateTime, bool> CompareDateTime = (jobStartTime, jobLogTime) => DateTime.Compare(jobStartTime, jobLogTime) == 0;
    }
}
