using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Vmk.Application.Contracts;
using Vmk.Application.Models;

namespace Vmk.Infrastructure.Services;

public class GalleryService : IGalleryService
{
    private const string ROOT_DATA_PATH = "wwwroot/data";

    private readonly ILogger<GalleryService> _logger;
    private readonly IFileProvider _fileProvider;

    public GalleryService(
        ILogger<GalleryService> logger,
        IFileProvider fileProvider)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
    }

    public async Task<List<Gallery>?> GatAllAsync(CancellationToken cancellation = default)
    {
        var fileInfo = _fileProvider.GetFileInfo(Path.Combine(ROOT_DATA_PATH, "galleries-data.json"));

        if (!fileInfo.Exists)
        {
            return null;
        }

        try
        {
            var galleriesString = await File.ReadAllTextAsync(fileInfo?.PhysicalPath!);
            var galleries = JsonSerializer.Deserialize<List<Gallery>>(galleriesString);

            return galleries;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error while retrieving galleries data.");
            return null;
        }
    }
}
