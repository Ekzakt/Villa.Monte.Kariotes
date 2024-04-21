using Vmk.Application.Models.Domain;

namespace Vmk.Application.Contracts;

public interface IGalleryService
{
    Task<List<Gallery>?> GatAllAsync(CancellationToken cancellationToken = default);

    Task<List<Gallery>?> GetVisibleAsync(CancellationToken cancellationToken = default);
}
