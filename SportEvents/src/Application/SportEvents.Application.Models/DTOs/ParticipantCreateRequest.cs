namespace SportEvents.Application.Models.DTOs;
public record ParticipantCreateRequest(
    string Name,
    DateOnly DateOfBirth,
    string Email,
    string Phone,
    string Gender);
