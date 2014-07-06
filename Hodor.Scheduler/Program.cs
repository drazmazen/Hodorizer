using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;
using System.Threading;
using System.IO;

namespace Hodor.Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Hodorizer service startup";


                LogonTrigger lt = new LogonTrigger();
                lt.Enabled = true;
                lt.Id = Thread.CurrentPrincipal.Identity.Name;
                lt.UserId = Thread.CurrentPrincipal.Identity.Name;                
                td.Triggers.Add(lt);


                td.Principal.RunLevel = TaskRunLevel.Highest;
                td.Principal.UserId = Thread.CurrentPrincipal.Identity.Name;
                td.Principal.LogonType = TaskLogonType.InteractiveToken;
                td.Settings.AllowDemandStart = true;
                td.Settings.Enabled = true;                
                td.Settings.StartWhenAvailable = true;
                td.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;
                td.Settings.RestartInterval = new TimeSpan(0, 5, 0);
                td.Settings.RestartCount = 3;
                

                //create path 
                var pathToExecutable = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Hodor.ConsoleServiceHost.exe");

                // Create an action that will launch the service host whenever the trigger fires
                td.Actions.Add(new ExecAction(pathToExecutable));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition("Hodorizer Service Starter", td);                
            }
        }
    }
}
