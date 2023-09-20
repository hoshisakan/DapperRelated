using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModel.WindowsTaskSchedulerRelated
{
    public class WindowsTaskScheduler
    {
        public string TaskName { get; set; }
        public DateTime? LastRunTime { get; set; }
        public DateTime? NextRunTime { get; set; }
        public string LastRunTimeStr { get; set; }
        public string NextRunTimeStr { get; set; }
        public int LastTaskResultCode { get; set; }
        public string LastTaskResult { get; set; }
        public bool IsActive { get; set; }
        public bool Enabled { get; set; }
        public string State { get; set; }
    }
}
