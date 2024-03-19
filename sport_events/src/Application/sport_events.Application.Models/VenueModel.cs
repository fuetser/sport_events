namespace SportEvents.Application.Models;

public class VenueModel(string name, string description, string address, int capacity)
{
    private static int _venueId = 0;

    public int Id { get; set; } = _venueId++;

    public string Name { get; set; } = name;

    public string Description { get; set; } = description;

    public string Address { get; set; } = address;

    public int Capacity { get; set; } = capacity;

    public IList<EventModel> Events { get; } = [];
}