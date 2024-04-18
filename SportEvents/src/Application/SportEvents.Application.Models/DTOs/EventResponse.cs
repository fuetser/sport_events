namespace SportEvents.Application.Models.DTOs;
public record EventResponse(
    Guid Id,
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    Guid VenueId,
    Guid SportId,
    Guid OrganizerId);
