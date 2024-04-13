using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;

public class UpdateTeamCommand : IRequest<TeamModel>
{
    public Guid TeamId { get; set; }

    public TeamUpdateRequest TeamUpdateRequest { get; set; } = null!;
}
