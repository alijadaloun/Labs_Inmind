using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Exceptions;

public class GlobalExceptionHandler: IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError($"An error has occured while sending your request.\n{exception.Message}");
        var statusCode = httpContext.Response.StatusCode;

        switch (exception)
        {
            case UserNotFoundException:
                statusCode = 404; break;
            case UserExistException:
                statusCode = 409; break;
            case YearNotValidException:
                statusCode = 400; break;
            case PageOutOfRangeException:
                statusCode = 407; break;
            default:
                statusCode = 500; break;//internal server error
                
                
        }

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = "An error occured.",
            Detail = exception.Message,
            Type = exception.GetType().FullName
            
        };
        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";
        //async-await to not block the request thread
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}