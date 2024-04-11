namespace SportEvents.Application.Models.DTOs;
public record VenueResponse(
    Guid Id,
    string Name,
    string Description,
    string Address,
    int Capacity);
