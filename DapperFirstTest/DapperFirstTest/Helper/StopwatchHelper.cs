using System.Diagnostics;

namespace DataAccess.Helper
{
    public class StopwatchHelper
    {
        public StopwatchHelper()
        {

        }

        public static void Timer(Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            else
            {
                Stopwatch stopwatch = new();
                stopwatch.Start();
                action();
                stopwatch.Stop();
                Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
            }
        }


    }
}
