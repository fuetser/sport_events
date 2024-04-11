namespace SportEvents.Application.Models.Entities;

public class Venue
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Capacity { get; set; }

    public IList<EEvent> Events { get; } = [];
}