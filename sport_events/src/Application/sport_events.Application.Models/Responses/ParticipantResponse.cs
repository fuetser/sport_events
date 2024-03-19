namespace SportEvents.Application.Models.Responses;
public record ParticipantResponse(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Email,
    string Phone,
    string Gender);
