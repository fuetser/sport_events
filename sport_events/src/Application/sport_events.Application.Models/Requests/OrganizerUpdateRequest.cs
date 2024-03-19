namespace SportEvents.Application.Models.Requests;
public record OrganizerUpdateRequest(
    int Id,
    string Name,
    string Description,
    string Email,
    string Phone);
