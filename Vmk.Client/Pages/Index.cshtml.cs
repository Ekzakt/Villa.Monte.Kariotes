using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Vmk.Application.Contracts;
using Vmk.Infrastructure.Configuration;

namespace Vmk.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGalleryService _galleryService;
        private readonly ITestimonialService _testimonialService;
        private readonly IDosAndDontsService _dosAndDontsService;
        private readonly BunnyCdnOptions _options;

        public IndexModel(
            ILogger<IndexModel> logger,
            IGalleryService galleryService,
            ITestimonialService testimonialService,
            IDosAndDontsService dosAndDontsService,
            IOptions<VmkOptions> options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _galleryService = galleryService ?? throw new ArgumentNullException(nameof(galleryService));
            _testimonialService = testimonialService ?? throw new ArgumentNullException(nameof(testimonialService));
            _dosAndDontsService = dosAndDontsService ?? throw new ArgumentNullException(nameof(dosAndDontsService));
            _options = options?.Value.BunnyCdn ?? throw new AbandonedMutexException(nameof(options));
        }


        public async Task OnGet()
        {
            var galleries = await _galleryService.GetVisibleAsync();
            var testimonials = await _testimonialService.GetVisibleAsync();
            var dosanddonts = await _dosAndDontsService.GetVisibleAsync();

            ViewData["BunnyCdnOptions"] = _options;
            ViewData["Galleries"] = galleries ?? [];
            ViewData["Testimonials"] = testimonials ?? [];
            ViewData["Dos"] = dosanddonts?.FindAll(x => x.IsDoNot == false) ?? [];
            ViewData["Donts"] = dosanddonts?.FindAll(x => x.IsDoNot == true) ?? [];
        }
    }
}
