namespace SportEvents.Application.Models;

public class TeamModel
{
    private static int _teamId = 0;

    public int Id { get; set; } = _teamId++;

    public string Name { get; set; }

    public string Description { get; set; }

    public int SportId { get; set; }

    public SportModel Sport { get; set; }

    public IList<ParticipantModel> Participants { get; } = [];

    public TeamModel(string name, string description, int sportId)
    {
        Name = name;
        Description = description;
        SportId = sportId;
        Sport = new SportModel("name", "description");
    }

    public TeamModel(string name, string description, int sportId, SportModel sport)
    {
        Name = name;
        Description = description;
        SportId = sportId;
        Sport = sport;
    }
}