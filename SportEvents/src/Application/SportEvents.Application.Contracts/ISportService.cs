using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface ISportService
{
    SportModel GetSportById(Guid sportId);

    SportModel CreateSport(SportModel model);

    SportModel UpdateSport(Guid sportId, SportModel model);

    void DeleteSport(Guid sportId);
}
