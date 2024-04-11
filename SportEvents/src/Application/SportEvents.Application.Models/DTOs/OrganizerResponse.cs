namespace SportEvents.Application.Models.DTOs;
public record OrganizerResponse(
    Guid Id,
    string Name,
    string Description,
    string Email,
    string Phone);
