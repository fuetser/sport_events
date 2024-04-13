using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;

public class UpdateVenueCommand : IRequest<VenueModel>
{
    public Guid VenueId { get; set; }

    public VenueUpdateRequest VenueUpdateRequest { get; set; } = null!;
}
