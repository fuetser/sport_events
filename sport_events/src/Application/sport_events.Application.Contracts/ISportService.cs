using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Contracts;
public interface ISportService
{
    IList<SportResponse> GetSports();

    SportResponse? GetSportById(int sportId);

    IList<SportResponse> GetSportsByEventId(int eventId);

    SportResponse? GetSportByTeamId(int teamId);

    bool CreateSport(SportCreateRequest request);

    bool UpdateSport(SportUpdateRequest request);

    bool DeleteSport(int sportId);
}
