using Vmk.Application.Models;

namespace Vmk.Application.Contracts;

public interface IDosAndDontsService
{
    Task<List<DosAndDonts>?> GatAllAsync(CancellationToken cancellationToken = default);

    Task<List<DosAndDonts>?> GetVisibleAsync(CancellationToken cancellationToken = default);
}
