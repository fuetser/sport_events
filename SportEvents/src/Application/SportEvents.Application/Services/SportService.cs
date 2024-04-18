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

    public Task<SportModel> UpdateSport(Guid sportId, SportModel model)
    {
        return _sportRepository.UpdateSport(sportId, model);
    }
}
