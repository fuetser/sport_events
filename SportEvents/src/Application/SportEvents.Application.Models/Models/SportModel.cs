namespace SportEvents.Application.Models.Models;
public class SportModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
}
