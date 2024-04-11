using Microsoft.EntityFrameworkCore;
using SportEvents.Application.Models.Entities;

namespace SportEvents.Infrastructure.Persistence.Contexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    required public DbSet<Organizer> Organizers { get; set; }

    required public DbSet<Participant> Participants { get; set; }

    required public DbSet<EEvent> Events { get; set; }

    required public DbSet<Sport> Sports { get; set; }

    required public DbSet<Team> Teams { get; set; }

    required public DbSet<Venue> Venues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Сюда добавлять различные конфигурации ваших файлов
        base.OnModelCreating(modelBuilder);
    }
}
