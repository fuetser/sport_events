namespace SportEvents.Application.Models.Models;
public class ParticipantModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public Guid EventId { get; set; }

    public Guid TeamId { get; set; }
}
