using System;
using Microsoft.Win32.TaskScheduler;

namespace VetisLog.Agent.Code
{
    public class TashSchedulerAddCommandHandler
    {
        public void Execute(TashSchedulerAddCommand addCommand)
        {
            addCommand.Validate();

            using (var ts = new TaskService())
            {
                var td = ts.NewTask();
                td.RegistrationInfo.Description = addCommand.Description;
                td.Settings.Hidden = true;
                td.Triggers.Add(new DailyTrigger
                {
                    DaysInterval = 1,
                    Enabled = true,
                    Repetition =
                        new RepetitionPattern(TimeSpan.FromMinutes(addCommand.MinutesInterval), TimeSpan.FromHours(24))
                });
                td.Actions.Add(new ExecAction(addCommand.PathToStart, addCommand.Args, addCommand.WorkingDirPath));
                ts.RootFolder.RegisterTaskDefinition(addCommand.TaskName, td);
            }
        }
    }
}