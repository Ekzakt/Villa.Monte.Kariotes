using Vmk.Infrastructure.Configuration;

namespace Vmk.Client.Configuration;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddVmkOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<VmkOptions>(
            builder.Configuration.GetSection(VmkOptions.SectionName));

        return builder;
    }
}
