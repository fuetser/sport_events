namespace SportEvents.Application.Models.Entities;

public class Organizer
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public IList<EEvent> Events { get; } = [];
}
