namespace SportEvents.Application.Models.Entities;

public class Team
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid SportId { get; set; }

    public Sport Sport { get; set; } = null!;

    public IList<Participant> Participants { get; } = [];
}