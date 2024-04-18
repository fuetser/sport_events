using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface ISportService
{
    Task<SportModel> GetSportById(Guid sportId);

    Task<SportModel> CreateSport(SportModel model);

    Task<SportModel> UpdateSport(Guid sportId, SportModel model);

    void DeleteSport(Guid sportId);
}
