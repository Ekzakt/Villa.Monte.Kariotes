using Vmk.Application.Models;

namespace Vmk.Application.Contracts;

public interface IAccomodationsService
{
    Task<AccomodationsModel?> GatAllAsync(CancellationToken cancellationToken = default);

    Task<AccomodationsModel?> GetVisibleAsync(CancellationToken cancellationToken = default);
}
