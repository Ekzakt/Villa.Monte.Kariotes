using Microsoft.Extensions.FileProviders;

namespace Vmk.Client.Configuration;

public static class DependendyInjection
{
    public static IServiceCollection AddFileProvider(this IServiceCollection services)
    {
        IFileProvider physicalProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());

        services.AddSingleton(physicalProvider);

        return services;
    }
}
