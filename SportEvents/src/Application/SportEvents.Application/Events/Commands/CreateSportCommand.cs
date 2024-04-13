using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;

public class CreateSportCommand : IRequest<SportModel>
{
    public SportCreateRequest SportCreateRequest { get; set; } = null!;
}
