using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Queries;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class GetEventHandler(IEventRepository eventRepository) : IRequestHandler<GetEventQuery, EventModel>
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<EventModel> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        return await _eventRepository.GetEventById(request.EventId);
    }
}
