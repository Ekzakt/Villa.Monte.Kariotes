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
}
