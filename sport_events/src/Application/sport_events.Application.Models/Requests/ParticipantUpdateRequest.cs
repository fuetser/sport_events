namespace SportEvents.Application.Models.Requests;
public record ParticipantUpdateRequest(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Email,
    string Phone,
    string Gender);
