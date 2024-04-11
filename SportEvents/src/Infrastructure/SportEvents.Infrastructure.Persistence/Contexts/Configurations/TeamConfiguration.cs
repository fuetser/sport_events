using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEvents.Application.Models.Entities;

namespace SportEvents.Infrastructure.Persistence.Contexts.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id).HasName("team_pkey");
        builder.Property(t => t.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder.Property(t => t.Name)
            .HasColumnName("name")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(t => t.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();
        builder.HasOne(t => t.Sport)
            .WithMany(s => s.Teams)
            .HasForeignKey(t => t.SportId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("teams");
    }
}
