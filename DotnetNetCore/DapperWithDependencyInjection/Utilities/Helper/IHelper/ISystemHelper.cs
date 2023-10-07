namespace Utilities.Helper.IHelper
{
    public interface ISystemHelper
    {
        public void CloseProgram();
        public void CloseProgram(int sleepTime);
        public string GetLocalIPAddress();
        public string GetApplicationName();
        public string GetApplicationVersion();
        public string GetHostName();
        public string GetMachineName();
    }
}
