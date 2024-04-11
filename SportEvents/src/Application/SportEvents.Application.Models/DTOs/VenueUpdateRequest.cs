namespace SportEvents.Application.Models.DTOs;
public record VenueUpdateRequest(
    Guid Id,
    string Name,
    string Description,
    string Address,
    int Capacity);
