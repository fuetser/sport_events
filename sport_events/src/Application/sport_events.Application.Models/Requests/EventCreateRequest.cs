namespace SportEvents.Application.Models.Requests;
public record EventCreateRequest(
     string Title,
     string Description,
     DateTime StartTime,
     DateTime EndTime);
