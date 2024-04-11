namespace SportEvents.Application.Models.Entities;
public class EEvent
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public IList<Venue> Venues { get; } = [];

    public IList<Sport> Sports { get; } = [];

    public IList<Organizer> Organizers { get; } = [];

    public IList<Participant> Participants { get; } = [];
}