namespace SportEvents.Application.Models;
public class ParticipantModel(string name, DateOnly dateOfBirth, string email, string phone, string gender)
{
    public int Id { get; set; }

    public string Name { get; set; } = name;

    public DateOnly DateOfBirth { get; set; } = dateOfBirth;

    public string Email { get; set; } = email;

    public string Phone { get; set; } = phone;

    public string Gender { get; set; } = gender;

    public IList<EventModel> Events { get; } = [];

    public IList<TeamModel> Teams { get; } = [];
}