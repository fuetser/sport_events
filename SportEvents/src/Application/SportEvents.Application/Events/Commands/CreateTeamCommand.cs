using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;

public class CreateTeamCommand : IRequest<TeamModel>
{
    public TeamCreateRequest TeamCreateRequest { get; set; } = null!;
}
