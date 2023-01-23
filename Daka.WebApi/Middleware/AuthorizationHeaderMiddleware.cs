namespace Daka.WebApi.Middleware;

public class AuthorizationHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizationHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var auth = context.Request.Headers["Authorization"];
        if (!string.IsNullOrWhiteSpace(auth))
        {
            await _next(context);
        }
        
        throw new InvalidOperationException("Missing header !!");
    }
}