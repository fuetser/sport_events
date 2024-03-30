using Microsoft.Extensions.DependencyInjection;
using SportEvents.Application.Contracts;
using SportEvents.Application.Services;

namespace SportEvents.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IEventService, EventService>();
        collection.AddScoped<IOrganizerService, OrganizerService>();
        collection.AddScoped<IParticipantService, ParticipantService>();
        collection.AddScoped<ISportService, SportService>();
        collection.AddScoped<ITeamService, TeamService>();
        collection.AddScoped<IVenueService, VenueService>();
        return collection;
    }
}