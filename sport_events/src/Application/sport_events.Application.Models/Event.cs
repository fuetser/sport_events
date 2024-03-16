namespace sport_events.Application.Models;
public class Event
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public List<Venue> Venues { get; } = [];

    public List<Sport> Sports { get; } = [];

    public List<Organizer> Organizers { get; } = [];

    public List<Participant> Participants { get; } = [];
}