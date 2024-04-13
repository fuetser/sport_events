using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class CreateEventHandler(IEventRepository eventRepository) : IRequestHandler<CreateEventCommand, EventModel>
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public Task<EventModel> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var eventModel = new EventModel
        {
            Id = Guid.NewGuid(),
            Title = request.EventCreateRequest.Title,
            Description = request.EventCreateRequest.Description,
            StartTime = request.EventCreateRequest.StartTime,
            EndTime = request.EventCreateRequest.EndTime,
        };
        return _eventRepository.CreateEvent(eventModel);
    }
}
