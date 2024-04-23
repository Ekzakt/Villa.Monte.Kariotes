using Microsoft.Extensions.Logging;
using Vmk.Application.Contracts;
using Vmk.Application.Models;
using Vmk.Application.Models.Domain;
using Vmk.Infrastructure.Constants;

namespace Vmk.Infrastructure.Services;

public class AccomodationService : IAccomodationsService
{
    private readonly ILogger<AccomodationService> _logger;
    private readonly IFileReader _fileReader;

    public AccomodationService(
        ILogger<AccomodationService> logger, 
        IFileReader fileReader)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
    }


    public async Task<AccomodationsModel?> GatAllAsync(CancellationToken cancellationToken = default)
    {
        var model = await _fileReader.GetDataAsync<AccomodationsModel>(DataFilePaths.ACCOMODATIONS);

        if (model is not null)
        {
            var accomodations = model?.Accomodations?
                .OrderBy(x => x.SortNumber)
                .ToList();

            model!.Accomodations = accomodations ?? [];
        }

        return model;
    }


    public async Task<AccomodationsModel?> GetVisibleAsync(CancellationToken cancellationToken = default)
    {
        var model = await GatAllAsync(cancellationToken);

        if (model is not null)
        {
            var accomodations = model?.Accomodations?
                .FindAll(x => x.IsInvisible == false);

            model!.Accomodations = accomodations ?? [];
        }
        
        return model;
    }
}
