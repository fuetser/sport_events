namespace SportEvents.Application.Models;

public class SportModel(string name, string description)
{
    private static int _sportId = 0;

    public int Id { get; set; } = _sportId++;

    public string Name { get; set; } = name;

    public string Description { get; set; } = description;

    public IList<EventModel> Events { get; } = [];

    public IList<TeamModel> Teams { get; } = [];
}
