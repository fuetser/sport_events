using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class CreateSportHandler(ISportRepository sportRepository) : IRequestHandler<CreateSportCommand, SportModel>
{
    private readonly ISportRepository _sportRepository = sportRepository;

    public Task<SportModel> Handle(CreateSportCommand request, CancellationToken cancellationToken)
    {
        var sportModel = new SportModel
        {
            Id = Guid.NewGuid(),
            Name = request.SportCreateRequest.Name,
            Description = request.SportCreateRequest.Description,
        };
        return _sportRepository.CreateSport(sportModel);
    }
}
