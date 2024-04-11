using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts.Persistence;
using SportEvents.Infrastructure.Persistence.Contexts;
using SportEvents.Infrastructure.Persistence.Migrations;
using SportEvents.Infrastructure.Persistence.Plugins;
using SportEvents.Infrastructure.Persistence.Repositories;

namespace SportEvents.Infrastructure.Persistence.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        AddContext(collection, configuration);

        collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));
        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);
        collection.AddHostedService<MigrationRunnerService>();

        collection.AddScoped<IPersistenceContext, PersistenceContext>();
        collection.AddScoped<IEventRepository, EventRepository>();
        collection.AddScoped<IOrganizerRepository, OrganizerRepository>();
        collection.AddScoped<IParticipantRepository, ParticipantRepository>();
        collection.AddScoped<ISportRepository, SportRepository>();
        collection.AddScoped<ITeamRepository, TeamRepository>();
        collection.AddScoped<IVenueRepository, VenueRepository>();

        return collection;
    }

    private static IServiceCollection AddContext(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));

        return collection;
    }
}