
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public class OptionsMiddleware

{
    private readonly RequestDelegate _next;

    public OptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext context)
    {
        return BeginInvoke(context);
    }

    private Task BeginInvoke(HttpContext context)
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
        context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "*" });
        context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "*" });
        context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });

        if (context.Request.Method == "OPTIONS")
        {
            context.Response.StatusCode = 200;
            return context.Response.WriteAsync("OK");
        }

        return _next.Invoke(context);
    }
}