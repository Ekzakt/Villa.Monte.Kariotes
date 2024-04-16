using Microsoft.AspNetCore.Mvc.RazorPages;
using Vmk.Application.Contracts;

namespace Vmk.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITestimonialService _testimonialService;

        public IndexModel(
            ILogger<IndexModel> logger,
            ITestimonialService testimonialService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _testimonialService = testimonialService ?? throw new ArgumentNullException(nameof(testimonialService));
        }


        public async Task OnGet()
        {
            var testimonials = await _testimonialService.GetVisibleAsync();

            ViewData["Testimonials"] = testimonials ?? [];
        }
    }
}
