using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface ISportService
{
    Task<IList<SportModel>> GetSports();

    Task<SportModel> GetSportById(Guid sportId);

    Task<IList<SportModel>> GetSportsByEventId(Guid eventId);

    Task<SportModel> GetSportByTeamId(Guid teamId);

    Task<SportModel> CreateSport(SportModel model);

    Task<SportModel> UpdateSport(Guid sportId, SportModel model);

    void DeleteSport(Guid sportId);
}
