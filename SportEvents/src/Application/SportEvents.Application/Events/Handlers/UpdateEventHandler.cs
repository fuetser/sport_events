using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class UpdateEventHandler(IEventRepository eventRepository) : IRequestHandler<UpdateEventCommand, EventModel>
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public Task<EventModel> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        if (request.EventUpdateRequest.StartTime.CompareTo(request.EventUpdateRequest.EndTime) >= 0)
        {
            throw new ArgumentException("Start time must be less than end time");
        }

        var eventModel = new EventModel
        {
            Id = Guid.Empty,
            Title = request.EventUpdateRequest.Title,
            Description = request.EventUpdateRequest.Description,
            StartTime = request.EventUpdateRequest.StartTime,
            EndTime = request.EventUpdateRequest.EndTime,
            VenueId = request.EventUpdateRequest.VenueId,
            SportId = request.EventUpdateRequest.SportId,
            OrganizerId = request.EventUpdateRequest.OrganizerId,
        };
        return _eventRepository.UpdateEvent(request.EventId, eventModel);
    }
}
