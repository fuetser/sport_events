namespace SportEvents.Application.Models.Requests;
public record VenueUpdateRequest(
    int Id,
    string Name,
    string Description,
    string Address,
    int Capacity);
