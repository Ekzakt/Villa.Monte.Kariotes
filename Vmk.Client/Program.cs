using Microsoft.Extensions.FileProviders;
using Vmk.Application.Contracts;
using Vmk.Infrastructure.Services;

namespace Vmk.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        IFileProvider physicalProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());

        builder.Services.AddSingleton<IFileProvider>(physicalProvider);

        builder.Services.AddRazorPages();
        builder.Services.AddScoped<IGalleryService, GalleryService>();



        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
