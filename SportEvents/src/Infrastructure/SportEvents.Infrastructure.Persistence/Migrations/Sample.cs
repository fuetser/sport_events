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
            CREATE TABLE organizers (
                id UUID PRIMARY KEY,
                name VARCHAR NOT NULL,
                description TEXT NOT NULL,
                email VARCHAR NOT NULL,
                phone VARCHAR NOT NULL
            );

            CREATE TABLE sports (
                id UUID PRIMARY KEY,
                name VARCHAR NOT NULL,
                description TEXT NOT NULL
            );

            CREATE TABLE venues (
                id UUID PRIMARY KEY,
                name VARCHAR NOT NULL,
                description TEXT NOT NULL,
                address VARCHAR NOT NULL,
                capacity INT NOT NULL
            );

            CREATE TABLE teams (
                id UUID PRIMARY KEY,
                name VARCHAR NOT NULL,
                description TEXT NOT NULL,
                SportId UUID NOT NULL,
                FOREIGN KEY (SportId) REFERENCES sports(id) ON DELETE CASCADE
            );

            CREATE TABLE events (
                id UUID PRIMARY KEY,
                title VARCHAR NOT NULL,
                description TEXT NOT NULL,
                start_time TIMESTAMP WITH TIME ZONE NOT NULL,
                end_time TIMESTAMP WITH TIME ZONE NOT NULL,
                VenueId UUID NOT NULL,
                SportId UUID NOT NULL,
                OrganizerId UUID NOT NULL,
                FOREIGN KEY (VenueId) REFERENCES venues(id) ON DELETE CASCADE,
                FOREIGN KEY (SportId) REFERENCES sports(id) ON DELETE CASCADE,
                FOREIGN KEY (OrganizerId) REFERENCES organizers(id) ON DELETE CASCADE
            );

            CREATE TABLE participants (
                id UUID PRIMARY KEY,
                name VARCHAR NOT NULL,
                date_of_birth DATE NOT NULL,
                email VARCHAR NOT NULL,
                phone VARCHAR NOT NULL,
                gender VARCHAR NOT NULL,
                EventId UUID NOT NULL,
                TeamId UUID NOT NULL,
                FOREIGN KEY (EventId) REFERENCES events(id) ON DELETE CASCADE,
                FOREIGN KEY (TeamId) REFERENCES teams(id) ON DELETE CASCADE
            );

            CREATE INDEX IX_events_OrganizerId ON events (OrganizerId);
            CREATE INDEX IX_events_SportId ON events (SportId);
            CREATE INDEX IX_events_VenueId ON events (VenueId);
            CREATE INDEX IX_participants_EventId ON participants (EventId);
            CREATE INDEX IX_participants_TeamId ON participants (TeamId);
            CREATE INDEX IX_teams_SportId ON teams (SportId);

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