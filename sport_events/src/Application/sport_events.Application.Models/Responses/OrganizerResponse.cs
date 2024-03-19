namespace SportEvents.Application.Models.Responses;
public record OrganizerResponse(
    int Id,
    string Name,
    string Description,
    string Email,
    string Phone);
