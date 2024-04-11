namespace SportEvents.Application.Models.DTOs;
public record OrganizerUpdateRequest(
    Guid Id,
    string Name,
    string Description,
    string Email,
    string Phone);
