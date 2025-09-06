using AspNetCore.Scheduler;

namespace AspNetCore.Worker;

public class TestScheduler : IScheduledTask
{
    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Scheduled task executed at: {DateTimeOffset.Now}");
        return Task.CompletedTask;
    }
}
