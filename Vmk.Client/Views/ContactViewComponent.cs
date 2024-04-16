using Microsoft.AspNetCore.Mvc;

namespace Vmk.Client.Views;

public class ContactViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        await Task.CompletedTask;

        return View();
    }
}
