using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;

public class UpdateSportCommand : IRequest<SportModel>
{
    public Guid SportId { get; set; }

    public SportUpdateRequest SportUpdateRequest { get; set; } = null!;
}
