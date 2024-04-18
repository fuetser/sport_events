namespace SportEvents.Application.Models.Models;
public class EventModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public Guid VenueId { get; set; }

    public Guid SportId { get; set; }

    public Guid OrganizerId { get; set; }
}