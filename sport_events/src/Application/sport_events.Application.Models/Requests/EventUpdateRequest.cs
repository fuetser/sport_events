namespace SportEvents.Application.Models.Requests;
public record EventUpdateRequest(
     int Id,
     string Title,
     string Description,
     DateTime StartTime,
     DateTime EndTime);