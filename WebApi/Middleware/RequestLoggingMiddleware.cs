namespace WebApi.Middleware;

public class RequestLoggingMiddleware(RequestDelegate request, ILogger<RequestLoggingMiddleware> logger)
{
    private RequestDelegate _request = request;
    private ILogger<RequestLoggingMiddleware> logger1 = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        logger1.LogInformation($"Request: {context.Request.Path} {DateTime.Now}");
        await _request(context);
        logger1.LogInformation($"Request: {context.Response.StatusCode} {DateTime.Now}");
    }
}
