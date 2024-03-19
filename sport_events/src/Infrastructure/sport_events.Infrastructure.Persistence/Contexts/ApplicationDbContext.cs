using Microsoft.EntityFrameworkCore;
using SportEvents.Application.Models;

namespace SportEvents.Infrastructure.Persistence.Contexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    required public DbSet<OrganizerModel> Organizers { get; set; }

    required public DbSet<ParticipantModel> Participants { get; set; }

    required public DbSet<EventModel> Events { get; set; }

    required public DbSet<SportModel> Sports { get; set; }

    required public DbSet<TeamModel> Teams { get; set; }

    required public DbSet<VenueModel> Venues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Сюда добавлять различные конфигурации ваших файлов
        base.OnModelCreating(modelBuilder);
    }
}
