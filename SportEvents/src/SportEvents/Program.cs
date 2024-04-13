#pragma warning disable CA1506
using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Logging.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using SportEvents.Application.Extensions;
using SportEvents.Infrastructure.Persistence.Extensions;
using SportEvents.Presentation.Http.Extensions;
using SportEvents.Presentation.Http.Middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddApplication();
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File("Logs/info_log.log", rollingInterval: RollingInterval.Day)
    .WriteTo.File(
        "Logs/error_log.log",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: LogEventLevel.Error)
    .CreateLogger();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

builder.Host.AddPlatformSerilog(builder.Configuration);
builder.Services.AddUtcDateTimeProvider();

WebApplication app = builder.Build();

app.UseMiddleware<RequestLoggerMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

await app.RunAsync();