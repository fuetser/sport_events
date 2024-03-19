namespace SportEvents.Application.Models.Responses;
public record TeamResponse(
    int Id,
    string Name,
    string Description,
    int SportId);
