using Microsoft.AspNetCore.Mvc;
using Vmk.Client.Models;

namespace Vmk.Client.Views;

public class ContactViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        await Task.CompletedTask;

        return View(new ContactModel());
    }
}
