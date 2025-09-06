using System;
using System.Threading;
using System.Threading.Tasks;
using Cronos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetCore.Scheduler
{
    public class SchedulerJobService : BackgroundService
    {
        private readonly ILogger<SchedulerJobService> _logger;
        private readonly IScheduledTask _scheduler;
        private readonly CronExpression _cronExpression;
        private readonly TimeZoneInfo _timeZone;

        public SchedulerJobService(string cronExpression, IScheduledTask scheduler, ILogger<SchedulerJobService> logger, TimeZoneInfo timeZone = null)
        {
            _logger = logger;
            _scheduler = scheduler;
            _cronExpression = CronExpression.Parse(cronExpression);
            _timeZone = timeZone ?? TimeZoneInfo.Local;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Scheduler job started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                var next = _cronExpression.GetNextOccurrence(DateTimeOffset.Now, _timeZone);
                if (!next.HasValue)
                    break;

                var delay = next.Value - DateTimeOffset.Now;
                if (delay.TotalMilliseconds <= 0)
                    continue;

                await Task.Delay(delay, stoppingToken);

                try
                {
                    await _scheduler.ExecuteAsync(stoppingToken);
                    _logger.LogInformation("Scheduler job executed at {time}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error executing scheduler job.");
                }
            }
        }
    }
}


