using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEvents.Application.Models.Entities;

namespace SportEvents.Infrastructure.Persistence.Contexts.Configurations;

public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.HasKey(p => p.Id).HasName("participant_pkey");
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(p => p.DateOfBirth)
            .HasColumnName("date_of_birth")
            .HasColumnType("date")
            .IsRequired();
        builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(p => p.Phone)
            .HasColumnName("phone")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(p => p.Gender)
            .HasColumnName("gender")
            .HasColumnType("character varying")
            .IsRequired();
        builder.ToTable("participants");
    }
}
