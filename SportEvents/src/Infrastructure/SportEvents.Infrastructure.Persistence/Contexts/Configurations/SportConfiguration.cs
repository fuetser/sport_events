using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEvents.Application.Models.Entities;

namespace SportEvents.Infrastructure.Persistence.Contexts.Configurations;

public class SportConfiguration : IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> builder)
    {
        builder.HasKey(s => s.Id).HasName("sport_pkey");
        builder.Property(s => s.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder.Property(s => s.Name)
            .HasColumnName("name")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(s => s.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();
        builder.ToTable("sports");
    }
}
