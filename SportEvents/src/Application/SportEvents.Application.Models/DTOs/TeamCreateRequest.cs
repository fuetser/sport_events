namespace SportEvents.Application.Models.DTOs;
public record TeamCreateRequest(
    string Name,
    string Description,
    Guid SportId);
