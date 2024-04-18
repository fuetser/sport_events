﻿using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface ITeamService
{
    TeamModel GetTeamById(Guid teamId);

    TeamModel CreateTeam(TeamModel model);

    TeamModel UpdateTeam(Guid teamId, TeamModel model);

    void DeleteTeam(Guid teamId);
}
