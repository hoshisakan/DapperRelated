using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModel.WindowsTaskSchedulerRelated
{
    public class WindowsTaskSchedulerDetails
    {
        public string FolderName { get; set; } = string.Empty;
        public string TaskName { get; set; } = string.Empty;
        public DateTime LastRunTime { get; set; }
        public DateTime NextRunTime { get; set; }
        public string LastRunTimeStr { get; set; } = string.Empty;
        public string NextRunTimeStr { get; set; } = string.Empty;
        public int LastTaskResultCode { get; set; }
        public string LastTaskResult { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Definition { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Trigger { get; set; } = string.Empty;
        //public string Principal { get; set; } = string.Empty;
        //public string Settings { get; set; } = string.Empty;
        //public string NumberOfMissedRuns { get; set; } = string.Empty;
        public bool Enabled { get; set; }
        public string State { get; set; } = string.Empty;
        //public string TaskService { get; set; } = string.Empty;
        //public string TaskServiceToken { get; set; } = string.Empty;
        //public string TaskServiceTargetServer { get; set; } = string.Empty;
        //public bool TaskServiceConnected { get; set; }
        //public string TaskServiceSite { get; set; } = string.Empty;
    }
}
