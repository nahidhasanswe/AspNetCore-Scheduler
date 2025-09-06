namespace AspNetCore.Worker;

public class Worker : IHostedService, IDisposable
{
    private readonly ILogger<Worker> _logger;
    private Timer? _timer;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public void Dispose()
    {
         _timer?.Dispose();
    }

    private void DoWork(object? state)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        // Your background task logic here
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Worker starting at: {time}", DateTimeOffset.Now);

        // Run immediately, then every 10 seconds
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Worker stopping at: {time}", DateTimeOffset.Now);
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }
}
