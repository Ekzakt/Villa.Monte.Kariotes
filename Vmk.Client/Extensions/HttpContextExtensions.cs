namespace Vmk.Client.Extensions;

public static class HttpContextExtensions
{
    public static bool ForceReload(this HttpContext context)
    {
        var forceReload = context.Request.Query
            .Where(x => x.Key.Equals("forceReload"))
            .FirstOrDefault()
            .Value.Equals("true");

        return forceReload;
    }

    public static string? GetIpAddress(this HttpContext httpContext)
    {
        var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();

        return ipAddress;
    }


    public static string? GetUserAgent(this HttpContext httpContext)
    {
        var userAgent = httpContext.Request.Headers.UserAgent.FirstOrDefault()?.ToString();

        return userAgent;
    }
}
