using Vmk.Application.Contracts;
using Vmk.Client.Configuration;
using Vmk.Infrastructure.Services;

namespace Vmk.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddVmkOptions();

        builder.Services.AddRazorPages();
        builder.Services.AddFileProvider();
        builder.Services.AddScoped<IFileReader, FileReader>();
        builder.Services.AddScoped<IGalleryService, GalleryService>();
        builder.Services.AddScoped<ITestimonialService, TestimonialService>();
        builder.Services.AddScoped<IDosAndDontsService, DosAndDontsService>();

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
