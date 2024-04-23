namespace Vmk.Client.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(
        RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Response.StatusCode == 404)
        {
            context.Response.Redirect("/Error/404");
        }

        if (context.Response.StatusCode >= 500)
        {
            context.Response.Redirect("/Error/500");
        }

        await _next(context);
    }
}
