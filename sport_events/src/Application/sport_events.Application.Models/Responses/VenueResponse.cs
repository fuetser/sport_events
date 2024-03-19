namespace SportEvents.Application.Models.Responses;
public record VenueResponse(
    int Id,
    string Name,
    string Description,
    string Address,
    int Capacity);
