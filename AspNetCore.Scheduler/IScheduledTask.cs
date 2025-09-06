using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.Scheduler 
{
    public interface IScheduledTask
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }

}

