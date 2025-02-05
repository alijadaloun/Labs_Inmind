using System.Web;
namespace Lab1.Middleware;

public class RequestLoggingMiddleware
{
    private ILogger<RequestLoggingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware( RequestDelegate next , ILogger<RequestLoggingMiddleware> logger )
    {
        _next = next;
        _logger = logger;

    }

    public async Task Invoke(HttpContext context)
    {
        //request:
        _logger.LogInformation(context.Request.Method);
        _logger.LogInformation(context.Request.Path);
        _logger.LogInformation(context.Request.QueryString.ToString());
        _logger.LogInformation(context.Request.Headers.ToString());
        _logger.LogInformation(context.Request.Body.ToString());
        await _next(context);
        //responses:
        _logger.LogInformation(context.Response.Headers.Date.ToString());
        _logger.LogInformation(context.Response.StatusCode.ToString());
        // _logger.LogInformation(context.Request.pa);
        
    }
}