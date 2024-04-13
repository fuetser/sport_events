using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;

namespace SportEvents.Application.Events.Handlers;

public class DeleteSportHandler(ISportRepository sportRepository) : IRequestHandler<DeleteSportCommand, Guid>
{
    private readonly ISportRepository _sportRepository = sportRepository;

    public Task<Guid> Handle(DeleteSportCommand request, CancellationToken cancellationToken)
    {
        return _sportRepository.DeleteSport(request.SportId);
    }
}
