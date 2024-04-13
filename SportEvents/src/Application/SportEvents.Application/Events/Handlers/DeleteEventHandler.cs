using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;

namespace SportEvents.Application.Events.Handlers;
public class DeleteEventHandler(IEventRepository eventRepository) : IRequestHandler<DeleteEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public Task<Guid> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        return _eventRepository.DeleteEvent(request.EventId);
    }
}
