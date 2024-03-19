namespace SportEvents.Application.Models;
public class EventModel(string title, string description, DateTime startTime, DateTime endTime)
{
    private static int _eventId = 0;

    public int Id { get; set; } = _eventId++;

    public string Title { get; set; } = title;

    public string Description { get; set; } = description;

    public DateTime StartTime { get; set; } = startTime;

    public DateTime EndTime { get; set; } = endTime;

    public IList<VenueModel> Venues { get; } = [];

    public IList<SportModel> Sports { get; } = [];

    public IList<OrganizerModel> Organizers { get; } = [];

    public IList<SportModel> Participants { get; } = [];
}