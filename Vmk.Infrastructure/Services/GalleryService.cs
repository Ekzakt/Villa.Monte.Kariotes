using Microsoft.Extensions.Logging;
using Vmk.Application.Contracts;
using Vmk.Application.Models;

namespace Vmk.Infrastructure.Services;

public class GalleryService : IGalleryService
{
    private const string DATA_FILE_NAME = "galleries-data.json";

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
        var galleries = await _fileReader.GetDataAsync<List<Gallery>>(DATA_FILE_NAME);

        return galleries;
    }


    public async Task<List<Gallery>?> GetVisibleAsync(CancellationToken cancellationToken = default)
    {
        var galleries = await GatAllAsync(cancellationToken);

        if (galleries is null)
        { 
            return null; 
        }

        return galleries.FindAll(x => x.IsInvisible == false);
    }
}
