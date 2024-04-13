using SportEvents.Presentation.Http.Middlewares;

namespace SportEvents.Presentation.Http.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddPresentationHttp(this IMvcBuilder builder)
    {
        builder.Services.AddSingleton<RequestLoggerMiddleware>();
        builder.Services.AddSingleton<ExceptionHandlerMiddleware>();

        return builder.AddApplicationPart(typeof(IAssemblyMarker).Assembly);
    }
}