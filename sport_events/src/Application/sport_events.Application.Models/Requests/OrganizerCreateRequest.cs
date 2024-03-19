namespace SportEvents.Application.Models.Requests;
public record OrganizerCreateRequest(
    string Name,
    string Description,
    string Email,
    string Phone);
