using System.Diagnostics;
using Utilities.Helper.IHelper;


namespace Utilities.Helper
{
    public class StopwatchHelper : IStopwatchHelper
    {
        private readonly string className = nameof(StopwatchHelper);
        private readonly Lazy<ILoggerHelper> _loggerHelper;

        public StopwatchHelper(Lazy<ILoggerHelper> loggerHelper)
        {
            this._loggerHelper = loggerHelper;
        }

        public void Timer(Stopwatch sw, Action action)
        {
            string methodName = nameof(Timer);

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            else
            {
                sw.Start();
                action();
                sw.Stop();

                //LogHelper.WriteLog(LogLevelEnum.DEBUG, className, methodName, $"Elapsed time: {sw.ElapsedMilliseconds} ms");

                TimeSpan ts = sw.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                _loggerHelper.Value.LogDebug($"Run time: {elapsedTime}", className, methodName);
            }
        }

        public void Timer(Stopwatch sw, Action action, int iterations)
        {
            string methodName = nameof(Timer);

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

                //LogHelper.WriteLog(LogLevelEnum.DEBUG, className, methodName, $"Elapsed time: {sw.ElapsedMilliseconds} ms");

                TimeSpan ts = sw.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                           ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                _loggerHelper.Value.LogDebug($"Run time: {elapsedTime}", className, methodName);
            }
        }
    }
}
