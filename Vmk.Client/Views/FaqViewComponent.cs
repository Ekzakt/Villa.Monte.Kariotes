using Microsoft.AspNetCore.Mvc;
using Vmk.Application.Contracts;
using Vmk.Application.Models;

namespace Vmk.Client.Views;

public class FaqViewComponent : ViewComponent
{
    private readonly ILogger<FaqViewComponent> _logger;
    private readonly IFaqService _faqService;

    public FaqViewComponent(
        ILogger<FaqViewComponent> logger, 
        IFaqService faqService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _faqService = faqService ?? throw new ArgumentNullException(nameof(faqService));
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var faqs = await _faqService.GetVisibleAsync();
        var model = new FaqModel();

        model.Faqs = faqs ?? [];

        return View(model);
    }
}
