﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportEvents.Application.Models.Entities;

namespace SportEvents.Infrastructure.Persistence.Contexts.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<EEvent>
{
    public void Configure(EntityTypeBuilder<EEvent> builder)
    {
        builder.HasKey(e => e.Id).HasName("event_pkey");
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasColumnType("uuid");
        builder.Property(e => e.Title)
            .HasColumnName("title")
            .HasColumnType("character varying")
            .IsRequired();
        builder.Property(e => e.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();
        builder.Property(e => e.StartTime)
            .HasColumnName("start_time")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        builder.Property(e => e.EndTime)
            .HasColumnName("end_time")
            .HasColumnType("timestamp with time zone");
        builder.HasOne(t => t.Venue)
            .WithMany(s => s.Events)
            .HasForeignKey(t => t.VenueId)
            .IsRequired()
            .HasConstraintName("VenueId")
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(t => t.Sport)
            .WithMany(s => s.Events)
            .HasForeignKey(t => t.SportId)
            .IsRequired()
            .HasConstraintName("SportId")
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(t => t.Organizer)
            .WithMany(s => s.Events)
            .HasForeignKey(t => t.OrganizerId)
            .IsRequired()
            .HasConstraintName("OrganizerId")
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("events");
    }
}
