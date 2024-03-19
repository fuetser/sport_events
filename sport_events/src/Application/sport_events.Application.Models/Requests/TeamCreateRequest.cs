namespace SportEvents.Application.Models.Requests;
public record TeamCreateRequest(
    string Name,
    string Description,
    int SportId);
