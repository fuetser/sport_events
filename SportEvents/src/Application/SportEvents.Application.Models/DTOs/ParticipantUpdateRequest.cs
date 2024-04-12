namespace SportEvents.Application.Models.DTOs;
public record ParticipantUpdateRequest(
    string Name,
    DateOnly DateOfBirth,
    string Email,
    string Phone,
    string Gender);
