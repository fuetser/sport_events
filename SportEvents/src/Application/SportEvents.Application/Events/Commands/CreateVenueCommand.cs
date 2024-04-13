using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;

public class CreateVenueCommand : IRequest<VenueModel>
{
    public VenueCreateRequest VenueCreateRequest { get; set; } = null!;
}
