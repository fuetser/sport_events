using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;
public class UpdateEventCommand : IRequest<EventModel>
{
    public Guid EventId { get; set; }

    public EventUpdateRequest EventUpdateRequest { get; set; } = null!;
}
