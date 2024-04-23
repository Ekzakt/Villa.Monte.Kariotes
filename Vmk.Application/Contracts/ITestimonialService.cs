using Vmk.Application.Models.Domain;

namespace Vmk.Application.Contracts;

public interface ITestimonialService
{
    Task<List<Testimonal>?> GetAllAsync(bool forceReload = false, CancellationToken cancellationToken = default);

    Task<List<Testimonal>?> GetVisibleAsync(bool forceReload = false, CancellationToken cancellation = default);
}
