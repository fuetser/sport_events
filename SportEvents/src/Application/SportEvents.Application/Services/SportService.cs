using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class SportService(ISportRepository sportRepository) : ISportService
{
    private readonly ISportRepository _sportRepository = sportRepository;

    public Task<SportModel> CreateSport(SportModel model)
    {
        return _sportRepository.CreateSport(model);
    }

    public void DeleteSport(Guid sportId)
    {
        _sportRepository.DeleteSport(sportId);
    }

    public Task<SportModel> GetSportById(Guid sportId)
    {
        return _sportRepository.GetSportById(sportId);
    }

    public Task<SportModel> GetSportByTeamId(Guid teamId)
    {
        return _sportRepository.GetSportByTeamId(teamId);
    }

    public Task<IList<SportModel>> GetSports()
    {
        return _sportRepository.GetSports();
    }

    public Task<IList<SportModel>> GetSportsByEventId(Guid eventId)
    {
        return _sportRepository.GetSportsByEventId(eventId);
    }

    public Task<SportModel> UpdateSport(Guid sportId, SportModel model)
    {
        return _sportRepository.UpdateSport(sportId, model);
    }
}
