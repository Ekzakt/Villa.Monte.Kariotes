using Microsoft.AspNetCore.Mvc;
using Vmk.Application.Contracts;

namespace Vmk.Client.Views;

public class AccomodationsViewComponent : ViewComponent
{
    private readonly ILogger<AccomodationsViewComponent> _logger;
    private readonly IAccomodationsService _accomodationsService;

    public AccomodationsViewComponent(
        ILogger<AccomodationsViewComponent> logger, 
        IAccomodationsService accomodationsService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _accomodationsService = accomodationsService ?? throw new ArgumentNullException(nameof(accomodationsService));
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _accomodationsService.GetVisibleAsync();
        
        return View(model);
    }
}
