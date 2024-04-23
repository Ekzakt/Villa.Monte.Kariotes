using Vmk.Application.Models.Domain;

namespace Vmk.Application.Contracts;

public interface IFaqService
{
    Task<List<Faq>?> GatAllAsync(CancellationToken cancellationToken = default);

    Task<List<Faq>?> GetVisibleAsync(CancellationToken cancellationToken = default);
}
