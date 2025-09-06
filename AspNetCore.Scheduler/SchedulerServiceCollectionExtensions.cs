using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCore.Scheduler
{
    public static class SchedulerServiceCollectionExtensions
    {
        public static void AddScheduler<TJob>(this IServiceCollection services, string cronExpression, TimeZoneInfo timeZone = null)
            where TJob : class, IScheduledTask
        {
            services.AddSingleton<IScheduledTask, TJob>();
            services.AddHostedService(provider =>
            {
                var job = provider.GetRequiredService<IScheduledTask>();
                var logger = provider.GetRequiredService<ILogger<SchedulerJobService>>();
                return new SchedulerJobService(cronExpression, job, logger, timeZone);
            });
        }
    }
}


