using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Models;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using SportEvents.Infrastructure.Persistence.Contexts;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class ParticipantRepository(ApplicationDbContext context) : IParticipantRepository
{
    private readonly ApplicationDbContext _context = context;

    public bool CreateParticipant(ParticipantCreateRequest request)
    {
        try
        {
            var participantModel = new ParticipantModel(
                name: request.Name,
                dateOfBirth: request.DateOfBirth,
                email: request.Email,
                phone: request.Phone,
                gender: request.Gender);

            _context.Participants.Add(participantModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteParticipant(int participantId)
    {
        try
        {
            var participantModel = _context.Participants.Find(participantId);
            if (participantModel is null)
                return false;

            _context.Participants.Remove(participantModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public ParticipantResponse? GetParticipantById(int participantId)
    {
        try
        {
            var participantModel = _context.Participants.Find(participantId);
            return participantModel is null
                ? null
                : new ParticipantResponse(
                Id: participantModel.Id,
                Name: participantModel.Name,
                DateOfBirth: participantModel.DateOfBirth,
                Email: participantModel.Email,
                Phone: participantModel.Phone,
                Gender: participantModel.Gender);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public IList<ParticipantResponse> GetParticipants()
    {
        try
        {
            var participantModels = _context.Participants.ToList();
            return ConvertParticipantModelsToResponses(participantModels);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IList<ParticipantResponse> GetParticipantsByEventId(int eventId)
    {
        throw new NotImplementedException();
    }

    public IList<ParticipantResponse> GetParticipantsByTeamId(int teamId)
    {
        try
        {
            var targetTeam = _context.Teams.Find(teamId);
            if (targetTeam is null)
                return [];

            return ConvertParticipantModelsToResponses(targetTeam.Participants);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public bool UpdateParticipant(ParticipantUpdateRequest request)
    {
        try
        {
            var participantModel = _context.Participants.Find(request.Id);
            if (participantModel is null)
                return false;

            participantModel.Name = request.Name;
            participantModel.DateOfBirth = request.DateOfBirth;
            participantModel.Email = request.Email;
            participantModel.Phone = request.Phone;
            participantModel.Gender = request.Gender;

            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private List<ParticipantResponse> ConvertParticipantModelsToResponses(IList<ParticipantModel> participantModels)
    {
        var participantResponses = new List<ParticipantResponse>(participantModels.Count);
        foreach (var participantModel in participantModels)
        {
            if (participantModel is null)
                continue;

            participantResponses.Add(
                new ParticipantResponse(
                    Id: participantModel.Id,
                    Name: participantModel.Name,
                    DateOfBirth: participantModel.DateOfBirth,
                    Email: participantModel.Email,
                    Phone: participantModel.Phone,
                    Gender: participantModel.Gender));
        }

        return participantResponses;
    }
}
