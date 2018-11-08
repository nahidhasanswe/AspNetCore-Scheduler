using AspNetCore.Scheduler.ScheduleTask;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.Worker
{
    public class ScheduleTask : IScheduledTask
    {
        public string Schedule => "* * * * *";

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Working....");
            await Task.CompletedTask;
        }
    }
}
