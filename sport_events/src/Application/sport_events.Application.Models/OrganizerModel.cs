namespace SportEvents.Application.Models;

public class OrganizerModel(string name, string description, string email, string phone)
{
    private static int _organizerId = 0;

    public int Id { get; set; } = _organizerId++;

    public string Name { get; set; } = name;

    public string Description { get; set; } = description;

    public string Email { get; set; } = email;

    public string Phone { get; set; } = phone;

    public IList<EventModel> Events { get; } = [];
}
