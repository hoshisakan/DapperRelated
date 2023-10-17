using System.Diagnostics;
using Utilities.Helper.IHelper;


namespace Utilities.Helper
{
    public class StopwatchHelper : IStopwatchHelper
    {
        private readonly string className = nameof(StopwatchHelper);
        private readonly ILoggerHelper _loggerHelper;
        private readonly Stopwatch _stopwatch;

        public StopwatchHelper(ILoggerHelper loggerHelper, Stopwatch stopwatch)
        {
            this._loggerHelper = loggerHelper;
            this._stopwatch = stopwatch;
        }

        public void Timer(Action action)
        {
            string methodName = nameof(Timer);

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            else
            {
                _stopwatch.Start();
                action();
                _stopwatch.Stop();

                //LogHelper.WriteLog(LogLevelEnum.DEBUG, className, methodName, $"Elapsed time: {sw.ElapsedMilliseconds} ms");

                TimeSpan ts = _stopwatch.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                Console.WriteLine($"Run time: {elapsedTime}, className: {className}, methodName: {methodName}");
                _loggerHelper.LogDebug($"Run time: {elapsedTime}", className, methodName);
            }
        }

        public void Timer(Action action, int iterations)
        {
            string methodName = nameof(Timer);

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            else
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                for (int i = 0; i < iterations; i++)
                {
                    action();
                }
                _stopwatch.Stop();

                //LogHelper.WriteLog(LogLevelEnum.DEBUG, className, methodName, $"Elapsed time: {sw.ElapsedMilliseconds} ms");

                TimeSpan ts = _stopwatch.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                Console.WriteLine($"Run time: {elapsedTime}, className: {className}, methodName: {methodName}");
                _loggerHelper.LogDebug($"Run time: {elapsedTime}", className, methodName);
            }
        }
    }
}
