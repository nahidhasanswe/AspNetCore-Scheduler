# AspNet Core Scheduler

The library is used for running schedule task on asp.net core app

## Getting Started

First Install the Scheduler package from [Nuget](https://www.nuget.org/packages/AspNetCore.Scheduler/).


### Installing

After installing the package from nuget in your asp.net core app, you need to implement **_IScheduledTask_** interface to your class and write your own tasks.

The implemented class looks like below:

```csharp
public class ScheduleTask : IScheduledTask
{
    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Write After 1 min");
        await Task.CompletedTask;
    }
}
```

**Schedule** is represent your schedule task and time format is crontab. For more information about [CronTab](https://support.acquia.com/hc/en-us/articles/360004224494-Cron-time-string-format) and you may also test your crontab format into [CronTab Guru](https://crontab.guru)

Now you will implement your own business logic schedule task into **_ExecuteAsync_** method.

And finally add scheduler services into startup.cs class

```csharp
services.AddScheduler<TestScheduler>("*/1 * * * *");
```

Now run your app and this scheduler is working

