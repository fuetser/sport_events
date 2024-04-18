namespace SportEvents.Application.Models.DTOs;
public record EventCreateRequest(
     string Title,
     string Description,
     DateTime StartTime,
     DateTime EndTime,
     Guid VenueId,
     Guid SportId,
     Guid OrganizerId);
