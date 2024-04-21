using Microsoft.Extensions.Logging;
using Vmk.Application.Contracts;
using Vmk.Application.Models.Domain;
using Vmk.Infrastructure.Constants;

namespace Vmk.Infrastructure.Services;

public class TestimonialService : ITestimonialService
{
    private readonly ILogger<GalleryService> _logger;
    private readonly IFileReader _fileReader;


    public TestimonialService(ILogger<GalleryService> logger, IFileReader fileReader)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(logger));  
    }


    public async Task<List<Testimonal>?> GetAllAsync(bool forceReload = false, CancellationToken cancellationToken = default)
    {
        var testimonials = await _fileReader.GetDataAsync<List<Testimonal>>(DataFilePaths.TESTIMONIALS, cancellationToken);

        testimonials = testimonials?
            .OrderByDescending(x => x.DateWritten)
            .ToList();

        return testimonials;
    }


    public async Task<List<Testimonal>?> GetVisibleAsync(bool forceReload = false, CancellationToken cancellationToken = default)
    {
        var testimonals = await GetAllAsync(forceReload, cancellationToken);

        return testimonals?.FindAll(x => x.IsInvisible == false);
    }
}
