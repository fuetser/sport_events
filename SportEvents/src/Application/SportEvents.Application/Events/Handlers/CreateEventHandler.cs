using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class CreateEventHandler(IEventRepository eventRepository) : IRequestHandler<EventCreateRequest, EventModel>
{
    private readonly IEventRepository _eventRepository = eventRepository;
}
