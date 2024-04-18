using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportEvents.Infrastructure.Persistence.Migrations;

/// <inheritdoc />
public partial class Simple : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
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
            name: "events",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                title = table.Column<string>(type: "character varying", nullable: false),
                description = table.Column<string>(type: "text", nullable: false),
                start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                VenueId = table.Column<Guid>(type: "uuid", nullable: false),
                SportId = table.Column<Guid>(type: "uuid", nullable: false),
                OrganizerId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("event_pkey", x => x.id);
                table.ForeignKey(
                    name: "OrganizerId",
                    column: x => x.OrganizerId,
                    principalTable: "organizers",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "SportId",
                    column: x => x.SportId,
                    principalTable: "sports",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "VenueId",
                    column: x => x.VenueId,
                    principalTable: "venues",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
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
                EventId = table.Column<Guid>(type: "uuid", nullable: false),
                TeamId = table.Column<Guid>(type: "uuid", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("participant_pkey", x => x.id);
                table.ForeignKey(
                    name: "EventId",
                    column: x => x.EventId,
                    principalTable: "events",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "TeamId",
                    column: x => x.TeamId,
                    principalTable: "teams",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_events_OrganizerId",
            table: "events",
            column: "OrganizerId");

        migrationBuilder.CreateIndex(
            name: "IX_events_SportId",
            table: "events",
            column: "SportId");

        migrationBuilder.CreateIndex(
            name: "IX_events_VenueId",
            table: "events",
            column: "VenueId");

        migrationBuilder.CreateIndex(
            name: "IX_participants_EventId",
            table: "participants",
            column: "EventId");

        migrationBuilder.CreateIndex(
            name: "IX_participants_TeamId",
            table: "participants",
            column: "TeamId");

        migrationBuilder.CreateIndex(
            name: "IX_teams_SportId",
            table: "teams",
            column: "SportId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "participants");

        migrationBuilder.DropTable(
            name: "events");

        migrationBuilder.DropTable(
            name: "teams");

        migrationBuilder.DropTable(
            name: "organizers");

        migrationBuilder.DropTable(
            name: "venues");

        migrationBuilder.DropTable(
            name: "sports");
    }
}
