public class TimeMiddlwWare
{
    readonly RequestDelegate next;

    public TimeMiddlwWare(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        await next(context);

        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
    }
}

public static class TimeMiddlwWareExtension
{
    public static IApplicationBuilder UseTimeMiddleWare(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddlwWare>();
    }
}
