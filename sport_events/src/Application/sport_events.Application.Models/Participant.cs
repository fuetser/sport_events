using static System.Runtime.InteropServices.JavaScript.JSType;

namespace sport_events.Application.Models;
public class Participant
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Date DateOfBirth { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Gender { get; set; }

    public List<Event> Events { get; } = [];

    public List<Team> Teams { get; } = [];
}