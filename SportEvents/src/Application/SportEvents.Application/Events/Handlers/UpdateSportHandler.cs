using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class UpdateSportHandler(ISportRepository sportRepository) : IRequestHandler<UpdateSportCommand, SportModel>
{
    private readonly ISportRepository _sportRepository = sportRepository;

    public Task<SportModel> Handle(UpdateSportCommand request, CancellationToken cancellationToken)
    {
        var sportModel = new SportModel
        {
            Id = Guid.Empty,
            Name = request.SportUpdateRequest.Name,
            Description = request.SportUpdateRequest.Description,
        };
        return _sportRepository.UpdateSport(request.SportId, sportModel);
    }
}
