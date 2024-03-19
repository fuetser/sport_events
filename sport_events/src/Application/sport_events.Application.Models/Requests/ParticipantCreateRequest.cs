namespace SportEvents.Application.Models.Requests;
public record ParticipantCreateRequest(
    string Name,
    DateOnly DateOfBirth,
    string Email,
    string Phone,
    string Gender);
