namespace sport_events.Application.Models;

public class Team
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int SportId { get; set; }

    public Sport Sport { get; set; }
}