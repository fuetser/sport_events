namespace SportEvents.Application.Models.Entities;

public class Sport
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public IList<EEvent> Events { get; } = [];

    public IList<Team> Teams { get; } = [];
}
