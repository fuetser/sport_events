namespace SportEvents.Application.Models.DTOs;
public record OrganizerCreateRequest(
    string Name,
    string Description,
    string Email,
    string Phone);
