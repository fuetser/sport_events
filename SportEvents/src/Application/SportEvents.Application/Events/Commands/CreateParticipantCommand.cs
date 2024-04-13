using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;

public class CreateParticipantCommand : IRequest<ParticipantModel>
{
    public ParticipantCreateRequest ParticipantCreateRequest { get; set; } = null!;
}