using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface ISportRepository
{
    SportModel GetSportById(Guid sportId);

    SportModel CreateSport(SportModel model);

    SportModel UpdateSport(Guid sportId, SportModel model);

    void DeleteSport(Guid sportId);
}
