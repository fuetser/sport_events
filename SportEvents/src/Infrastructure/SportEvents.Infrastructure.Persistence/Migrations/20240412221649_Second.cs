using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportEvents.Infrastructure.Persistence.Migrations;

/// <inheritdoc />
public partial class Second : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "events",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                title = table.Column<string>(type: "character varying", nullable: false),
                description = table.Column<string>(type: "text", nullable: false),
                start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("event_pkey", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "organizers",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying", nullable: false),
                description = table.Column<string>(type: "text", nullable: false),
                email = table.Column<string>(type: "character varying", nullable: false),
                phone = table.Column<string>(type: "character varying", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("organizer_pkey", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "participants",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying", nullable: false),
                date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                email = table.Column<string>(type: "character varying", nullable: false),
                phone = table.Column<string>(type: "character varying", nullable: false),
                gender = table.Column<string>(type: "character varying", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("participant_pkey", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "sports",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying", nullable: false),
                description = table.Column<string>(type: "text", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("sport_pkey", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "venues",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying", nullable: false),
                description = table.Column<string>(type: "text", nullable: false),
                address = table.Column<string>(type: "character varying", nullable: false),
                capacity = table.Column<int>(type: "integer", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("venue_pkey", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "EEventOrganizer",
            columns: table => new
            {
                EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                OrganizersId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EEventOrganizer", x => new { x.EventsId, x.OrganizersId });
                table.ForeignKey(
                    name: "FK_EEventOrganizer_events_EventsId",
                    column: x => x.EventsId,
                    principalTable: "events",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EEventOrganizer_organizers_OrganizersId",
                    column: x => x.OrganizersId,
                    principalTable: "organizers",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "EEventParticipant",
            columns: table => new
            {
                EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                ParticipantsId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EEventParticipant", x => new { x.EventsId, x.ParticipantsId });
                table.ForeignKey(
                    name: "FK_EEventParticipant_events_EventsId",
                    column: x => x.EventsId,
                    principalTable: "events",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EEventParticipant_participants_ParticipantsId",
                    column: x => x.ParticipantsId,
                    principalTable: "participants",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "EEventSport",
            columns: table => new
            {
                EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                SportsId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EEventSport", x => new { x.EventsId, x.SportsId });
                table.ForeignKey(
                    name: "FK_EEventSport_events_EventsId",
                    column: x => x.EventsId,
                    principalTable: "events",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EEventSport_sports_SportsId",
                    column: x => x.SportsId,
                    principalTable: "sports",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "teams",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying", nullable: false),
                description = table.Column<string>(type: "text", nullable: false),
                SportId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("team_pkey", x => x.id);
                table.ForeignKey(
                    name: "SportId",
                    column: x => x.SportId,
                    principalTable: "sports",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "EEventVenue",
            columns: table => new
            {
                EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                VenuesId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EEventVenue", x => new { x.EventsId, x.VenuesId });
                table.ForeignKey(
                    name: "FK_EEventVenue_events_EventsId",
                    column: x => x.EventsId,
                    principalTable: "events",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EEventVenue_venues_VenuesId",
                    column: x => x.VenuesId,
                    principalTable: "venues",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ParticipantTeam",
            columns: table => new
            {
                ParticipantsId = table.Column<Guid>(type: "uuid", nullable: false),
                TeamsId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ParticipantTeam", x => new { x.ParticipantsId, x.TeamsId });
                table.ForeignKey(
                    name: "FK_ParticipantTeam_participants_ParticipantsId",
                    column: x => x.ParticipantsId,
                    principalTable: "participants",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ParticipantTeam_teams_TeamsId",
                    column: x => x.TeamsId,
                    principalTable: "teams",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_EEventOrganizer_OrganizersId",
            table: "EEventOrganizer",
            column: "OrganizersId");

        migrationBuilder.CreateIndex(
            name: "IX_EEventParticipant_ParticipantsId",
            table: "EEventParticipant",
            column: "ParticipantsId");

        migrationBuilder.CreateIndex(
            name: "IX_EEventSport_SportsId",
            table: "EEventSport",
            column: "SportsId");

        migrationBuilder.CreateIndex(
            name: "IX_EEventVenue_VenuesId",
            table: "EEventVenue",
            column: "VenuesId");

        migrationBuilder.CreateIndex(
            name: "IX_ParticipantTeam_TeamsId",
            table: "ParticipantTeam",
            column: "TeamsId");

        migrationBuilder.CreateIndex(
            name: "IX_teams_SportId",
            table: "teams",
            column: "SportId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "EEventOrganizer");

        migrationBuilder.DropTable(
            name: "EEventParticipant");

        migrationBuilder.DropTable(
            name: "EEventSport");

        migrationBuilder.DropTable(
            name: "EEventVenue");

        migrationBuilder.DropTable(
            name: "ParticipantTeam");

        migrationBuilder.DropTable(
            name: "organizers");

        migrationBuilder.DropTable(
            name: "events");

        migrationBuilder.DropTable(
            name: "venues");

        migrationBuilder.DropTable(
            name: "participants");

        migrationBuilder.DropTable(
            name: "teams");

        migrationBuilder.DropTable(
            name: "sports");
    }
}
