namespace SportEvents.Application.Models.DTOs;
public record TeamUpdateRequest(
    Guid Id,
    string Name,
    string Description,
    Guid SportId);
