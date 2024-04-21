using Microsoft.Extensions.Logging;
using Vmk.Application.Contracts;
using Vmk.Application.Models.Domain;
using Vmk.Infrastructure.Constants;

namespace Vmk.Infrastructure.Services;

public class FaqService : IFaqService
{
    private readonly ILogger<FaqService> _logger;
    private readonly IFileReader _fileReader;

    public FaqService(
        ILogger<FaqService> logger, 
        IFileReader fileReader)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
    }

    public async Task<List<Faq>?> GatAllAsync(CancellationToken cancellationToken = default)
    {
        var faqs = await _fileReader.GetDataAsync<List<Faq>>(DataFilePaths.FAQS);

        faqs = faqs?
            .OrderBy(x => x.SortNumber)
            .ToList();

        return faqs;
    }

    public async Task<List<Faq>?> GetVisibleAsync(CancellationToken cancellationToken = default)
    {
        var faqs = await GatAllAsync(cancellationToken);

        faqs = faqs?
            .FindAll(x => x.IsInvisible == false);

        return faqs;
    }
}
