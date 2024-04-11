namespace SportEvents.Application.Models.Entities;
public class Participant
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public IList<EEvent> Events { get; } = [];

    public IList<Team> Teams { get; } = [];
}