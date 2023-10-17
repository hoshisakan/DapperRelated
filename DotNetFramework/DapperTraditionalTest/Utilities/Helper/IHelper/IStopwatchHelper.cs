namespace Utilities.Helper.IHelper
{
    public interface IStopwatchHelper
    {
        public void Timer(Action action);
        public void Timer(Action action, int iterations);
    }
}
