using Microsoft.Extensions.Logging;
using Vmk.Application.Contracts;
using Vmk.Application.Models.Domain;
using Vmk.Infrastructure.Constants;

namespace Vmk.Infrastructure.Services;

public class DosAndDontsService : IDosAndDontsService
{
    private readonly ILogger<DosAndDontsService> _logger;
    private readonly IFileReader _fileReader;

    public DosAndDontsService(
        ILogger<DosAndDontsService> logger,
        IFileReader fileReader)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
    }


    public async Task<List<DoAndDont>?> GatAllAsync(CancellationToken cancellationToken = default)
    {
        var dosAndDonts = await _fileReader.GetDataAsync<List<DoAndDont>>(DataFilePaths.DOS_AND_DONTS);

        dosAndDonts = dosAndDonts?
            .OrderBy(x => x.IsDoNot)
            .ThenBy(x => x.SortNumber)
            .ToList();

        return dosAndDonts;
    }


    public async Task<List<DoAndDont>?> GetVisibleAsync(CancellationToken cancellationToken = default)
    {
        var dosanddonts = await GatAllAsync(cancellationToken);

        dosanddonts = dosanddonts?
            .FindAll(x => x.IsInvisible == false);

        return dosanddonts;
    }
}
