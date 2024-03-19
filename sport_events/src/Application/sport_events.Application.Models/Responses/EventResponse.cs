namespace SportEvents.Application.Models.Responses;
public record EventResponse(
    int Id,
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate);
