using Vmk.Application.Models;

namespace Vmk.Application.Contracts;

public interface ITestimonialService
{
    Task<List<Testimonal>?> GetAllAsync(CancellationToken cancellationToken = default);

    Task<List<Testimonal>?> GetVisibleAsync(CancellationToken cancellation = default);
}
