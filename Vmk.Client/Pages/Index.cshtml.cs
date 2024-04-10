using Microsoft.AspNetCore.Mvc.RazorPages;
using Vmk.Application.Contracts;

namespace Vmk.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGalleryService _galleryService;
        private readonly ITestimonialService _testimonialService;

        public IndexModel(
            ILogger<IndexModel> logger,
            IGalleryService galleryService,
            ITestimonialService testimonialService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _galleryService = galleryService ?? throw new ArgumentNullException(nameof(galleryService));
            _testimonialService = testimonialService ?? throw new ArgumentNullException(nameof(testimonialService));
        }


        public async Task OnGet()
        {
            var galleries = await _galleryService.GetVisibleAsync();
            var testimonials = await _testimonialService.GetVisibleAsync();

            ViewData["Galleries"] = galleries ?? [];
            ViewData["Testimonials"] = testimonials ?? [];
        }
    }
}
