using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface ISportRepository
{
    IList<SportModel> GetSports();

    SportModel GetSportById(Guid sportId);

    IList<SportModel> GetSportsByEventId(Guid eventId);

    SportModel GetSportByTeamId(Guid teamId);

    SportModel CreateSport(SportModel model);

    SportModel UpdateSport(Guid sportId, SportModel model);

    void DeleteSport(Guid sportId);
}
