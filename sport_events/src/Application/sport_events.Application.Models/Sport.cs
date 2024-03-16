namespace sport_events.Application.Models;

public class Sport
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<Event> Events { get; } = [];

    public List<Team> Teams { get; } = [];
}
