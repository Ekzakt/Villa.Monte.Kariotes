using Microsoft.AspNetCore.Mvc;
using Vmk.Application.Models;

namespace Vmk.Client.Views;

public class ContactViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        await Task.CompletedTask;

        return View(new ContactModel());
    }
}
