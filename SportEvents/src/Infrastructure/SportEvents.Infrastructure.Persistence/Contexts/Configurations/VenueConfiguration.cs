using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEvents.Application.Models.Entities;

namespace SportEvents.Infrastructure.Persistence.Contexts.Configurations;

public class VenueConfiguration : IEntityTypeConfiguration<Venue>
{
    public void Configure(EntityTypeBuilder<Venue> builder)
    {
        builder.HasKey(v => v.Id).HasName("venue_pkey");
        builder.Property(v => v.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder.Property(v => v.Name)
            .HasColumnName("name")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(v => v.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();
        builder.Property(v => v.Address)
            .HasColumnName("address")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(v => v.Capacity)
            .HasColumnName("capacity")
            .HasColumnType("integer")
            .IsRequired();
        builder.ToTable("venues");
    }
}
