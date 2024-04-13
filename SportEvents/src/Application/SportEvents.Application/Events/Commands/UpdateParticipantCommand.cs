using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;

public class UpdateParticipantCommand : IRequest<ParticipantModel>
{
    public Guid ParticipantId { get; set; }

    public ParticipantUpdateRequest ParticipantUpdateRequest { get; set; } = null!;
}