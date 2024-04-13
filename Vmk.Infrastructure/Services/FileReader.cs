using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Vmk.Application.Contracts;
using Vmk.Infrastructure.Constants;

namespace Vmk.Infrastructure.Services;

public class FileReader : IFileReader
{
    private readonly ILogger<FileReader> _logger;
    private readonly IFileProvider _fileProvider;


    public FileReader(
        ILogger<FileReader> logger, 
        IFileProvider fileProvider)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
    }


    public async Task<TData?> GetDataAsync<TData>(string filePath, CancellationToken cancellationToken = default) where TData : class
    {
        var fileInfo = _fileProvider.GetFileInfo(filePath);

        if (!fileInfo.Exists)
        {
            _logger.LogError("The file {FilePath} could not be found. A null value is returned.", filePath);
            return null;
        }

        try
        {
            var stringData = await File.ReadAllTextAsync(fileInfo?.PhysicalPath!);
            var data = JsonSerializer.Deserialize<TData>(stringData);

            return data;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error while retrieving data from {FilePath}. A null value is returned.", filePath);
            return null;
        }
    }
}
