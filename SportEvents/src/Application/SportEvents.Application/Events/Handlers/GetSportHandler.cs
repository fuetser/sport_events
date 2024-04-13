using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Queries;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class GetSportHandler(ISportRepository sportRepository) : IRequestHandler<GetSportQuery, SportModel>
{
    private readonly ISportRepository _sportRepository = sportRepository;

    public async Task<SportModel> Handle(GetSportQuery request, CancellationToken cancellationToken)
    {
        return await _sportRepository.GetSportById(request.SportId);
    }
}
