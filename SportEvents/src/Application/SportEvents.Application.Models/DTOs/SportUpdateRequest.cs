namespace SportEvents.Application.Models.DTOs;
public record SportUpdateRequest(
    Guid Id,
    string Name,
    string Description);