namespace SportEvents.Application.Models.DTOs;
public record ParticipantResponse(
    Guid Id,
    string Name,
    DateOnly DateOfBirth,
    string Email,
    string Phone,
    string Gender,
    Guid EventId,
    Guid TeamId);
