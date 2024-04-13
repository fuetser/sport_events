namespace SportEvents.Presentation.Http.Middlewares;

public class RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> logger) : IMiddleware
{
    private readonly ILogger<RequestLoggerMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var request = new
        {
            ip = context.Connection.RemoteIpAddress?.MapToIPv4() + ":" + context.Connection.RemotePort,
            method = context.Request.Method,
            endpoint = context.Request.Path,
        };

        _logger.LogInformation($"Got Request: {request.ip} {request.method} {request.endpoint}");
        await next(context);
    }
}
