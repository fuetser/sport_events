using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface ISportRepository
{
    Task<IList<SportModel>> GetSports();

    Task<SportModel> GetSportById(Guid sportId);

    Task<IList<SportModel>> GetSportsByEventId(Guid eventId);

    Task<SportModel> GetSportByTeamId(Guid teamId);

    Task<SportModel> CreateSport(SportModel model);

    Task<SportModel> UpdateSport(Guid sportId, SportModel model);

    Task<Guid> DeleteSport(Guid sportId);
}
