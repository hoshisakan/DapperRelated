using Microsoft.Win32.TaskScheduler;
using Models.DataModel.WindowsTaskSchedulerRelated;



namespace Utilities.Helper
{
    public class WindowsTaskSchedulerHelper
    {
        public WindowsTaskSchedulerHelper() { }

        public static List<WindowsTaskSchedulerDetails> GetSpecficFolderAllTask(string folderName)
        {
            List<WindowsTaskSchedulerDetails> taskScheduler = new List<WindowsTaskSchedulerDetails>();

            try
            {
                if (string.IsNullOrEmpty(folderName))
                {
                    throw new Exception("Folder name is empty.");
                }

                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    List<Microsoft.Win32.TaskScheduler.Task> readAllTasks = ts.RootFolder.AllTasks.ToList();

                    taskScheduler = (
                        from task in ts.GetFolder(folderName).AllTasks
                        select new WindowsTaskSchedulerDetails
                        {
                            FolderName = task.Folder.Name,
                            TaskName = task.Name,
                            LastRunTime = task.LastRunTime,
                            NextRunTime = task.NextRunTime,
                            LastRunTimeStr = DateTimeHelper.GetFormatDateTime(task.LastRunTime, "yyyy-MM-dd HH:mm:ss.fff"),
                            NextRunTimeStr = DateTimeHelper.GetFormatDateTime(task.NextRunTime, "yyyy-MM-dd HH:mm:ss.fff"),
                            LastTaskResultCode = task.LastTaskResult,
                            IsActive = task.IsActive,
                            Definition = task.Definition?.ToString() ?? string.Empty,
                            Action = task.Definition?.Actions != null ? task.Definition?.Actions.FirstOrDefault()?.ToString() : string.Empty,
                            Trigger = task.Definition.Triggers != null ? task.Definition?.Triggers.FirstOrDefault()?.ToString() : string.Empty,
                            //Principal = task.Definition.Principal.ToString(),
                            //Settings = task.Definition.Settings.ToString(),
                            //NumberOfMissedRuns = task.NumberOfMissedRuns.ToString(),
                            Enabled = task.Enabled,
                            State = task.State.ToString(),
                        }
                    ).ToList();
                }
            } 
            catch (Exception ex)
            {
                DebugHelper.ReadItemsOutputRawText(
                    $"GetSpecficFolderAllTask error!\nMessage: {ex.Message}\nStackTrace: {ex.StackTrace}",
                    $"{SystemHelper.GetApplicationName()}-Error",
                    DateTimeHelper.GetNowDateTimeFormat("yyyyMMdd")
                );
            }
            return taskScheduler;
        }

        public static List<WindowsTaskScheduler> GetAllTaskList()
        {
            List<WindowsTaskScheduler> taskScheduler = new List<WindowsTaskScheduler>();

            try
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    List<Microsoft.Win32.TaskScheduler.Task> readAllTasks = ts.RootFolder.AllTasks.ToList();

                    taskScheduler = (
                        from task in readAllTasks
                        select new WindowsTaskScheduler
                        {
                            TaskName = task.Name,
                            LastRunTime = task.LastRunTime,
                            NextRunTime = task.NextRunTime,
                            LastRunTimeStr = DateTimeHelper.GetFormatDateTime(task.LastRunTime, "yyyy-MM-dd HH:mm:ss.fff"),
                            NextRunTimeStr = DateTimeHelper.GetFormatDateTime(task.NextRunTime, "yyyy-MM-dd HH:mm:ss.fff"),
                            LastTaskResultCode = task.LastTaskResult,
                            IsActive = task.IsActive,
                            Enabled = task.Enabled,
                            State = task.State.ToString(),
                        }
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                DebugHelper.ReadItemsOutputRawText(
                    $"GetAllTaskList error!\nMessage: {ex.Message}\nStackTrace: {ex.StackTrace}",
                    $"{SystemHelper.GetApplicationName()}-Error",
                    DateTimeHelper.GetNowDateTimeFormat("yyyyMMdd")
                );
            }
            return taskScheduler;
        }

        public void CreateTaskToSpecificFolder()
        {
            //// Create a new task definition and assign properties
            //TaskDefinition td = ts.NewTask();
            //td.RegistrationInfo.Description = "Does something";

            //// Create a trigger that will fire the task at this time every other day
            //td.Triggers.Add(new DailyTrigger { DaysInterval = 2 });

            //// Create an action that will launch Notepad whenever the trigger fires
            //td.Actions.Add(new ExecAction("notepad.exe", "c:\\test.log", null));

            //// Register the task in the root folder
            //ts.RootFolder.RegisterTaskDefinition(@"Test", td);

            //// Remove the task we just created
            //ts.RootFolder.DeleteTask("Test");
        }
    }
}
