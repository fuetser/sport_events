namespace SportEvents.Application.Models.DTOs;
public record OrganizerUpdateRequest(
    string Name,
    string Description,
    string Email,
    string Phone);
