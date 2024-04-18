namespace Vmk.Infrastructure.ScopedServices;

public interface IScopedService
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}
