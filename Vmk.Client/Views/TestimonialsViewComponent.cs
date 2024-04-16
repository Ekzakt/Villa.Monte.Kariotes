using Microsoft.AspNetCore.Mvc;
using Vmk.Application.Contracts;
using Vmk.Client.Models;

namespace Vmk.Client.Views;

public class TestimonialsViewComponent : ViewComponent
{
    private readonly ILogger<TestimonialsViewComponent> _logger;
    private readonly ITestimonialService _testimonialsService;

    public TestimonialsViewComponent(ILogger<TestimonialsViewComponent> logger, ITestimonialService testimonialsService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _testimonialsService = testimonialsService ?? throw new ArgumentNullException(nameof(testimonialsService));
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var testimonials = await _testimonialsService.GetVisibleAsync();
        var model = new TestimonialsModel();

        model.Testimonials = testimonials;

        return View(model);
    }
}
