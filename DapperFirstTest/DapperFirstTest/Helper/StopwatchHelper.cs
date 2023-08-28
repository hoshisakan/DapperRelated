using System.Diagnostics;

namespace DataAccess.Helper
{
    public static class StopwatchHelper
    {
        public static void Timer(this Stopwatch sw, Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            else
            {
                sw.Start();
                action();
                sw.Stop();
                //Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
                TimeSpan ts = sw.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine($"Run time: {elapsedTime}");
            }
        }

        public static void Timer(this Stopwatch sw, Action action, int iterations)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            else
            {
                sw.Reset();
                sw.Start();
                for (int i = 0; i < iterations; i++)
                {
                    action();
                }
                sw.Stop();

                //Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds} ms");

                TimeSpan ts = sw.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine($"Run time: {elapsedTime}");
            }
        }
    }
}
