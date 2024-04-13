using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;
public class CreateEventCommand : IRequest<EventModel>
{
    public EventCreateRequest EventCreateRequest { get; set; } = null!;
}
