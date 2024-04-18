namespace SportEvents.Application.Models.DTOs;
public record EventUpdateRequest(
     string Title,
     string Description,
     DateTime StartTime,
     DateTime EndTime,
     Guid VenueId,
     Guid SportId,
     Guid OrganizerId);