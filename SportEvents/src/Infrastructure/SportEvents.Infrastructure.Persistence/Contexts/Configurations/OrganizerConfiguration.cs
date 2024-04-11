using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEvents.Application.Models.Entities;

namespace SportEvents.Infrastructure.Persistence.Contexts.Configurations;

public class OrganizerConfiguration : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.HasKey(o => o.Id).HasName("organizer_pkey");
        builder.Property(o => o.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder.Property(o => o.Name)
            .HasColumnName("name")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(o => o.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();
        builder.Property(o => o.Email)
            .HasColumnName("email")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(o => o.Phone)
            .HasColumnName("phone")
            .HasColumnType("character varying")
            .IsRequired();
        builder.ToTable("organizers");
    }
}
