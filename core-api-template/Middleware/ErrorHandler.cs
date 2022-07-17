using System.Net;
using System.Text.Json;
using core_api_template.Helpers;

namespace core_api_template.Middleware;
/// <summary>
/// Error handling middle ware will only show app exceptions other exceptions will only be visible in the logs
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerFactory _loggerFactory;

    public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _loggerFactory = loggerFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var logger = _loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
            var result = JsonSerializer.Serialize(new { message = error?.Message });
            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
            logger.LogError(result);

            // var result = "Internal server error";
            switch(error)
            {
                case AppException:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return;
            }

        
            await response.WriteAsync(result);
        }
    }
}