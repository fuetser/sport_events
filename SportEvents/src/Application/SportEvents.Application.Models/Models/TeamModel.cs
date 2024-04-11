﻿namespace SportEvents.Application.Models.Models;
public class TeamModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid SportId { get; set; }
}
