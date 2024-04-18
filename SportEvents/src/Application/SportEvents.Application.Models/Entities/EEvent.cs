namespace SportEvents.Application.Models.Entities;
public class EEvent
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public Guid VenueId { get; set; }

    public Guid SportId { get; set; }

    public Guid OrganizerId { get; set; }

    public Venue Venue { get; set; } = null!;

    public Sport Sport { get; set; } = null!;

    public Organizer Organizer { get; set; } = null!;

    public IList<Participant> Participants { get; } = [];
}