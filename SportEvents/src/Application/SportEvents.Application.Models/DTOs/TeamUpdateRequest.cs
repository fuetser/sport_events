namespace SportEvents.Application.Models.DTOs;
public record TeamUpdateRequest(
    string Name,
    string Description,
    Guid SportId);
