namespace SportEvents.Application.Models.Models;
public class VenueModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Capacity { get; set; }
}
