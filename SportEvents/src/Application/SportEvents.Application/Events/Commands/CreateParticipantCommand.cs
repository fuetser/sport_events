using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;

public class CreateParticipantCommand : IRequest<PatricipantModel>
{
    public ParticipantCreateRequest ParticipantCreateRequest { get; set; } = null!;
}