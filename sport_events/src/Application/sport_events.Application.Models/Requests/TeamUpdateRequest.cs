namespace SportEvents.Application.Models.Requests;
public record TeamUpdateRequest(
    int Id,
    string Name,
    string Description,
    int SportId);
