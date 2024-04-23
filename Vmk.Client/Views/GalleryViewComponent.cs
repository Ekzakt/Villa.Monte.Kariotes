using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vmk.Application.Contracts;
using Vmk.Infrastructure.Configuration;

namespace Vmk.Client.Views;

public class GalleryViewComponent : ViewComponent
{
    private readonly ILogger<GalleryViewComponent> _logger;
    private readonly IGalleryService _galleryService;
    private readonly BunnyCdnOptions _bunnyOptions;
    private readonly GalleryOptions _galleryOptions;

    public GalleryViewComponent(
        ILogger<GalleryViewComponent> logger, 
        IGalleryService galleryService,
        IOptions<VmkOptions> options)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _galleryService = galleryService ?? throw new ArgumentNullException(nameof(galleryService));
        _bunnyOptions = options?.Value.BunnyCdn ?? throw new ArgumentNullException(nameof(options));
        _galleryOptions = options?.Value.Gallery ?? throw new ArgumentNullException(nameof(options));
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewData["BunnyCdnOptions"] = _bunnyOptions;
        ViewData["GalleryOptions"] = _galleryOptions;

        var galleries = await _galleryService.GetVisibleAsync();

        return View(galleries ?? []);
    }
}
