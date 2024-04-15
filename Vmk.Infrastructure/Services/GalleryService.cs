using Microsoft.Extensions.Logging;
using Vmk.Application.Contracts;
using Vmk.Application.Models;
using Vmk.Infrastructure.Constants;

namespace Vmk.Infrastructure.Services;

public class GalleryService : IGalleryService
{
    private readonly ILogger<GalleryService> _logger;
    private readonly IFileReader _fileReader;


    public GalleryService(
        ILogger<GalleryService> logger,
        IFileReader fileReader)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
    }
    

    public async Task<List<Gallery>?> GatAllAsync(CancellationToken cancellationToken = default)
    {
        var galleries = await _fileReader.GetDataAsync<List<Gallery>>(DataFilePaths.GALLERIES);

        galleries = galleries?
            .OrderBy(x => x.SortNumber)
            .ThenBy(x => x.Name)
            .ToList();

        return galleries;
    }


    public async Task<List<Gallery>?> GetVisibleAsync(CancellationToken cancellationToken = default)
    {
        var galleries = await GatAllAsync(cancellationToken);

        galleries = galleries?
            .FindAll(x => x.IsInvisible == false);

        foreach(var gallery in galleries ?? [])
        {
            gallery.Photos = gallery.Photos
                .FindAll(x => x.IsInvisible == false)
                .OrderBy(x => x.SortNumber)
                    .ThenBy(x => x.Filename)
                .ToList();
        }

        return galleries;
    }
}
