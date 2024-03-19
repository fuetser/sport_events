namespace SportEvents.Application.Models.Requests;
public record VenueCreateRequest(
    string Name,
    string Description,
    string Address,
    int Capacity);
