using Ekzakt.EmailSender.Smtp.Configuration;
using Ekzakt.EmailTemplateProvider.Io.Configuration;
using Ekzakt.FileManager.AzureBlob.Configuration;
using Vmk.Application.Contracts;
using Vmk.Client.Configuration;
using Vmk.Infrastructure.BackgroundServices;
using Vmk.Infrastructure.Constants;
using Vmk.Infrastructure.Queueing;
using Vmk.Infrastructure.ScopedServices;
using Vmk.Infrastructure.Services;

namespace Vmk.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddOpenTelemetry();

        builder.Services.AddEkzaktFileManagerAzure();
        builder.Services.AddEkzaktEmailTemplateProviderIo();
        builder.Services.AddEkzaktSmtpEmailSender();

        builder.Services.AddRazorPages();
        builder.Services.AddFileProvider();

        builder.Services.AddScoped<IFileReader, FileReader>();
        builder.Services.AddScoped<IGalleryService, GalleryService>();
        builder.Services.AddScoped<ITestimonialService, TestimonialService>();
        builder.Services.AddScoped<IFaqService, FaqService>();
        builder.Services.AddScoped<IAccomodationsService, AccomodationService>();
        builder.Services.AddScoped<IQueueService, QueueService>();

        builder.Services.AddHostedService<ContactFormQueueBgService>();
        builder.Services.AddHostedService<EmailBgService>();
        builder.Services.AddKeyedScoped<IScopedService, ContactFormService>(ProcessingServiceKeys.CONTACT_FORM);
        builder.Services.AddKeyedScoped<IScopedService, EmailService>(ProcessingServiceKeys.EMAILS);

        builder.AddVmkOptions();
        builder.AddAzureClientServices();
        builder.AddAzureKeyVault();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error/500");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.Use(async (context, next) =>
        {
            await next();
            if (context.Response.StatusCode == 404)
            {
                context.Request.Path = "/error/404";
                await next();
            }
        });

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
