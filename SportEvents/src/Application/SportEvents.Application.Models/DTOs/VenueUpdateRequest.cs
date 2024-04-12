namespace SportEvents.Application.Models.DTOs;
public record VenueUpdateRequest(
    string Name,
    string Description,
    string Address,
    int Capacity);
