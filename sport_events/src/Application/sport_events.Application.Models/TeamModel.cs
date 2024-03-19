namespace SportEvents.Application.Models;

public class TeamModel(string name, string description, int sportId, SportModel sport)
{
    private static int _teamId = 0;

    public int Id { get; set; } = _teamId++;

    public string Name { get; set; } = name;

    public string Description { get; set; } = description;

    public int SportId { get; set; } = sportId;

    public SportModel Sport { get; set; } = sport;

    public IList<ParticipantModel> Participants { get; } = [];
}