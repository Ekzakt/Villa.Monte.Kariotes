using Microsoft.AspNetCore.Mvc.RazorPages;
using Vmk.Application.Contracts;
using Vmk.Application.Models;

namespace Vmk.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGalleryService _galleryService;

        public IndexModel(
            ILogger<IndexModel> logger,
            IGalleryService galleryService)
        {
            _logger = logger;
            _galleryService = galleryService;
        }

        public async void OnGet()
        {
            var galleries = await _galleryService.GatAllAsync();

            ViewData["Galleries"] = galleries ?? [];
        }
    }
}
