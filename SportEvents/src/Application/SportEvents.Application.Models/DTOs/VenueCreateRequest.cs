namespace SportEvents.Application.Models.DTOs;
public record VenueCreateRequest(
    string Name,
    string Description,
    string Address,
    int Capacity);
