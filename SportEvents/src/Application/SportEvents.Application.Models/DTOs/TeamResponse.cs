namespace SportEvents.Application.Models.DTOs;
public record TeamResponse(
    Guid Id,
    string Name,
    string Description,
    Guid SportId);
