using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class SportService(ISportRepository sportRepository) : ISportService
{
    private readonly ISportRepository _sportRepository = sportRepository;

    public SportModel CreateSport(SportModel model)
    {
        return _sportRepository.CreateSport(model);
    }

    public void DeleteSport(Guid sportId)
    {
        _sportRepository.DeleteSport(sportId);
    }

    public SportModel GetSportById(Guid sportId)
    {
        return _sportRepository.GetSportById(sportId);
    }

    public SportModel GetSportByTeamId(Guid teamId)
    {
        return _sportRepository.GetSportByTeamId(teamId);
    }

    public IList<SportModel> GetSports()
    {
        return _sportRepository.GetSports();
    }

    public IList<SportModel> GetSportsByEventId(Guid eventId)
    {
        return _sportRepository.GetSportsByEventId(eventId);
    }

    public SportModel UpdateSport(Guid sportId, SportModel model)
    {
        return _sportRepository.UpdateSport(sportId, model);
    }
}
