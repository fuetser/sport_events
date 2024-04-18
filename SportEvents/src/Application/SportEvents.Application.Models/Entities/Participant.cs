namespace SportEvents.Application.Models.Entities;
public class Participant
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public Guid EventId { get; set; }

    public Guid TeamId { get; set; }

    public EEvent Event { get; set; } = null!;

    public Team Team { get; set; } = null!;
}