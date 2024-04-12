using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

#nullable disable

namespace SportEvents.Infrastructure.Persistence.Migrations;

[Migration(2)]
public partial class Sample : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider)
    {
        string upSql = @"
                CREATE TABLE events (
                    id UUID PRIMARY KEY,
                    title VARCHAR(255) NOT NULL,
                    description TEXT NOT NULL,
                    start_time TIMESTAMP WITHOUT TIME ZONE NOT NULL,
                    end_time TIMESTAMP WITHOUT TIME ZONE NOT NULL
                );

                CREATE TABLE organizers (
                    id UUID PRIMARY KEY,
                    name VARCHAR(255) NOT NULL,
                    description TEXT NOT NULL,
                    email VARCHAR(255) NOT NULL,
                    phone VARCHAR(255) NOT NULL
                );

                CREATE TABLE participants (
                    id UUID PRIMARY KEY,
                    name VARCHAR(255) NOT NULL,
                    date_of_birth DATE NOT NULL,
                    email VARCHAR(255) NOT NULL,
                    phone VARCHAR(255) NOT NULL,
                    gender VARCHAR(255) NOT NULL
                );

                CREATE TABLE sports (
                    id UUID PRIMARY KEY,
                    name VARCHAR(255) NOT NULL,
                    description TEXT NOT NULL
                );

                CREATE TABLE venues (
                    id UUID PRIMARY KEY,
                    name VARCHAR(255) NOT NULL,
                    description TEXT NOT NULL,
                    address VARCHAR(255) NOT NULL,
                    capacity INT NOT NULL
                );

                CREATE TABLE EEventOrganizer (
                    EventsId UUID NOT NULL,
                    OrganizersId UUID NOT NULL,
                    PRIMARY KEY (EventsId, OrganizersId),
                    CONSTRAINT FK_EEventOrganizer_events_EventsId FOREIGN KEY (EventsId) REFERENCES events(id) ON DELETE CASCADE,
                    CONSTRAINT FK_EEventOrganizer_organizers_OrganizersId FOREIGN KEY (OrganizersId) REFERENCES organizers(id) ON DELETE CASCADE
                );

                CREATE TABLE EEventParticipant (
                    EventsId UUID NOT NULL,
                    ParticipantsId UUID NOT NULL,
                    PRIMARY KEY (EventsId, ParticipantsId),
                    CONSTRAINT FK_EEventParticipant_events_EventsId FOREIGN KEY (EventsId) REFERENCES events(id) ON DELETE CASCADE,
                    CONSTRAINT FK_EEventParticipant_participants_ParticipantsId FOREIGN KEY (ParticipantsId) REFERENCES participants(id) ON DELETE CASCADE
                );

                CREATE TABLE EEventSport (
                    EventsId UUID NOT NULL,
                    SportsId UUID NOT NULL,
                    PRIMARY KEY (EventsId, SportsId),
                    CONSTRAINT FK_EEventSport_events_EventsId FOREIGN KEY (EventsId) REFERENCES events(id) ON DELETE CASCADE,
                    CONSTRAINT FK_EEventSport_sports_SportsId FOREIGN KEY (SportsId) REFERENCES sports(id) ON DELETE CASCADE
                );

                CREATE TABLE teams (
                    id UUID PRIMARY KEY,
                    name VARCHAR(255) NOT NULL,
                    description TEXT NOT NULL,
                    SportId UUID NOT NULL,
                    CONSTRAINT FK_teams_sports_SportId FOREIGN KEY (SportId) REFERENCES sports(id) ON DELETE CASCADE
                );

                CREATE TABLE EEventVenue (
                    EventsId UUID NOT NULL,
                    VenuesId UUID NOT NULL,
                    PRIMARY KEY (EventsId, VenuesId),
                    CONSTRAINT FK_EEventVenue_events_EventsId FOREIGN KEY (EventsId) REFERENCES events(id) ON DELETE CASCADE,
                    CONSTRAINT FK_EEventVenue_venues_VenuesId FOREIGN KEY (VenuesId) REFERENCES venues(id) ON DELETE CASCADE
                );

                CREATE TABLE ParticipantTeam (
                    ParticipantsId UUID NOT NULL,
                    TeamsId UUID NOT NULL,
                    PRIMARY KEY (ParticipantsId, TeamsId),
                    CONSTRAINT FK_ParticipantTeam_participants_ParticipantsId FOREIGN KEY (ParticipantsId) REFERENCES participants(id) ON DELETE CASCADE,
                    CONSTRAINT FK_ParticipantTeam_teams_TeamsId FOREIGN KEY (TeamsId) REFERENCES teams(id) ON DELETE CASCADE
                );
            ";

        return upSql;
    }

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        string downSql = @"
                DROP TABLE IF EXISTS ParticipantTeam;
                DROP TABLE IF EXISTS EEventVenue;
                DROP TABLE IF EXISTS teams;
                DROP TABLE IF EXISTS EEventSport;
                DROP TABLE IF EXISTS EEventParticipant;
                DROP TABLE IF EXISTS EEventOrganizer;
                DROP TABLE IF EXISTS venues;
                DROP TABLE IF EXISTS sports;
                DROP TABLE IF EXISTS participants;
                DROP TABLE IF EXISTS organizers;
                DROP TABLE IF EXISTS events;
            ";

        return downSql;
    }
}