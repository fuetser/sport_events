using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Services;
public class SportService(ISportRepository sportRepository) : ISportService
{
    private readonly ISportRepository _sportRepository = sportRepository;

    public bool CreateSport(SportCreateRequest request)
    {
        return _sportRepository.CreateSport(request);
    }

    public bool DeleteSport(int sportId)
    {
        return _sportRepository.DeleteSport(sportId);
    }

    public SportResponse? GetSportById(int sportId)
    {
        return _sportRepository.GetSportById(sportId);
    }

    public SportResponse? GetSportByTeamId(int teamId)
    {
        return _sportRepository.GetSportByTeamId(teamId);
    }

    public IList<SportResponse> GetSports()
    {
        return _sportRepository.GetSports();
    }

    public IList<SportResponse> GetSportsByEventId(int eventId)
    {
        return _sportRepository.GetSportsByEventId(eventId);
    }

    public bool UpdateSport(SportUpdateRequest request)
    {
        return _sportRepository.UpdateSport(request);
    }
}
