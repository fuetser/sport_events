namespace SportEvents.Application.Models.DTOs;
public record ParticipantUpdateRequest(
    Guid Id,
    string Name,
    DateOnly DateOfBirth,
    string Email,
    string Phone,
    string Gender);
