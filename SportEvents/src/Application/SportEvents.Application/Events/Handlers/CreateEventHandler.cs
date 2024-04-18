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
        if (request.EventCreateRequest.StartTime.CompareTo(request.EventCreateRequest.EndTime) >= 0)
        {
            throw new ArgumentException("Start time must be less than end time");
        }

        var eventModel = new EventModel
        {
            Id = Guid.NewGuid(),
            Title = request.EventCreateRequest.Title,
            Description = request.EventCreateRequest.Description,
            StartTime = request.EventCreateRequest.StartTime,
            EndTime = request.EventCreateRequest.EndTime,
            VenueId = request.EventCreateRequest.VenueId,
            SportId = request.EventCreateRequest.SportId,
            OrganizerId = request.EventCreateRequest.OrganizerId,
        };
        return _eventRepository.CreateEvent(eventModel);
    }
}
