using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;

namespace SportEvents.Application.Events.Handlers;
public class DeleteEventHandler(IEventRepository eventRepository) : IRequestHandler<DeleteEventCommand, string>
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public Task<string> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        _eventRepository.DeleteEvent(request.EventId);
        return Task.FromResult(request.EventId.ToString());
    }
}
