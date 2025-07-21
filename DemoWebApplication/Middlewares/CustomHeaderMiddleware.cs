namespace DemoWebApplication.Middlewares;

public class CustomHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public CustomHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        if (endpoint?.Metadata.GetMetadata<AddCustomHeaderAttribute>() != null)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add("X-User-Role", "Admin");
                return Task.CompletedTask;
            });
        }
        await _next(context);
    }
}