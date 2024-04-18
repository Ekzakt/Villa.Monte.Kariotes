using Microsoft.AspNetCore.Mvc;
using Vmk.Application.Contracts;
using Vmk.Application.Models;

namespace Vmk.Client.Views;

public class YourStayViewComponent : ViewComponent
{
    private readonly ILogger<YourStayViewComponent> _logger;
    private readonly IDosAndDontsService _dosAndDontsService;

    public YourStayViewComponent(ILogger<YourStayViewComponent> logger, IDosAndDontsService dosAndDontsService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dosAndDontsService = dosAndDontsService ?? throw new ArgumentNullException(nameof(dosAndDontsService));
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var dosanddonts = await _dosAndDontsService.GetVisibleAsync();
        var model = new YourStayModel();

        model.Dos = dosanddonts?.FindAll(x => x.IsDoNot == false) ?? [];
        model.Donts = dosanddonts?.FindAll(x => x.IsDoNot == true) ?? [];

        return View(model);
    }
}
