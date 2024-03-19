namespace SportEvents.Application.Models.Requests;
public record SportUpdateRequest(
    int Id,
    string Name,
    string Description);