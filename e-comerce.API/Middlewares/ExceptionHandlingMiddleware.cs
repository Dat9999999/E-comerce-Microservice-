namespace e_comerce.Web.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private ILogger<ExceptionHandlingMiddleware> _logger;
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.GetType()}: {e.Message}");
            if (e.InnerException is not null)
            {
                _logger.LogError($"{e.InnerException.GetType()}: {e.InnerException.Message}");
            }
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new
            {
                message = e.Message,
                type = e.GetType().Name,
            });
        }
    }
}

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}