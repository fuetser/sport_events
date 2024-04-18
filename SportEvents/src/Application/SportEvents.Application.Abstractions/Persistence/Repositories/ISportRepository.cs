using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface ISportRepository
{
    Task<SportModel> GetSportById(Guid sportId);

    Task<SportModel> CreateSport(SportModel model);

    Task<SportModel> UpdateSport(Guid sportId, SportModel model);

    Task<Guid> DeleteSport(Guid sportId);
}
