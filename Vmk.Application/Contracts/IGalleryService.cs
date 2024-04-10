using Vmk.Application.Models;

namespace Vmk.Application.Contracts;

public interface IGalleryService
{
    Task<List<Gallery>?> GatAllAsync(CancellationToken cancellation = default);
}
